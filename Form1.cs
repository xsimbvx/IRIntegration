using System;
using System.Drawing;
using System.Windows.Forms;
using ImageEditor;
using ImageRecovery;
using System.Threading;

public partial class Form1 : Form
{
    private Image sourceImage;                                      //исходное изображение
    private byte[,] noize = null;                                   //шум
    private ConvolutionFilter blur;                                 //искажающий
    //потоки 
    private Thread blurThread;                                      //для искажения изображения
    private Thread noiseThread;                                     //для добавления шума
    private Thread reconstructionThread;                            //для восстановления изображения

    /// <summary>
    /// Изменения текста на форме из любого потока.
    /// </summary>
    /// <param name="label">Метка, текст которой надо изменить</param>
    /// <param name="text">Новый текст</param>
    private void ChangeText(Label label, string text)
    {
        if (label.InvokeRequired)
        {
            Action<Label, string> callback = ChangeText;
            try
            {
                Invoke(callback, new object[] { label, text });
            }
            catch
            {
                // ignored
            }
        }
        else
        {
            label.Text = text;
        }
    }
    /// <summary>
    /// Изменения изображения на форме из любого потока.
    /// </summary>
    /// <param name="pictureBox">Picture box, изображение которого надо изменить.</param>
    /// <param name="image">Новое изображение.</param>
    private void ChangeImage(PictureBox pictureBox, Image image)
    {
        if (pictureBox.InvokeRequired)
        {
            Action<PictureBox, Image> callback = ChangeImage;
            try
            {
                Invoke(callback, new object[] { pictureBox, image });
            }
            catch
            {
                // ignored
            }
        }
        else
        {
            pictureBox.Image = image;
        }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="path">Путь к открываемому файлу</param>
    public Form1(string[] path)
    {
        try
        {
            sourceImage = Image.FromFile(path[0]);                  //попытка грузить файл (может выскочить исключение)
            InitializeComponent();                                  //инициализация компонентов
            sourcePictureBox.Image = sourceImage;                   //отрисовка избражения и указывание размеров
            sourceSizeText.Text = sourcePictureBox.Image.Height + " x" + sourcePictureBox.Image.Width;
        }
        catch
        {
            InitializeComponent();                                  //если поймано исключение - инициальзация компонентов
        }
    }

    /// <summary>
    /// Загрузка изображения
    /// </summary>
    private void LoadImage(object sender = null, EventArgs e = null)
    {
        OpenFileDialog ofd = new OpenFileDialog();                  //открытие диалога
        if (ofd.ShowDialog() == DialogResult.OK)                    //если файл был выбран
        {
            try
            {
                sourceImage = Image.FromFile(ofd.FileName);         //попытка его загрузить (может выскочить исключение)
                sourcePictureBox.Image = sourceImage;               //если загружено - отрисовка и вывод размера
                sourceSizeText.Text = sourcePictureBox.Image.Height + " x" + sourcePictureBox.Image.Width;

                blurPictureBox.Image = null;                        //обнуление всех последующих шагов обработки изображения
                noisePictureBox.Image = null;
                recoveredPictureBox.Image = null;

                bluredSizeText.Text = "-";                          //их размеры
                noiseSizeText.Text = "-";
                recoveredSizeText.Text = "-";

                blurKernalPictureBox.Image = null;                  //и вспомогательные изображения (kernel)
                noiseMaskPictureBox.Image = null;
                recoveryKernalPictureBox.Image = null;

            }
            catch
            {                                                       //если исключение поймано - сообщим об этом
                MessageBox.Show("Неверный формат изображения", "Ошибка загрузки");
                sourceImage = sourcePictureBox.Image;               //вернём изображению предыдущее состояние
            }
        }
    }

    /// <summary>
    /// Добавления размытия
    /// </summary>
    private void AddBlur(object sender = null, EventArgs e = null)
    {
        if (blurThread != null)
            blurThread.Abort();
        if (sourceImage == null)                                    //если входного изображения нет
        {
            LoadImage();                                            //грузим его
            if (sourceImage == null)                                //если его всё равно нет (пользователь отказался)
                return;                                             //уходим
        }
        //обнуляем следующие этапы
        ChangeImage(noisePictureBox, null);
        ChangeImage(recoveredPictureBox, null);
        ChangeText(noiseSizeText, "-");
        ChangeText(recoveredSizeText, "-");
        ChangeImage(noiseMaskPictureBox, null);
        ChangeImage(recoveryKernalPictureBox, null);

        if (sender == null)                                         //если функция была вызвана не кнопкой
        {
            blur = Filters.CopyFilter;                              //выставляем фильтр точной копии
            blurPictureBox.Image = sourceImage;                     //сразу скопируем то же изображение
        }
        else
        {
            switch (((Button)sender).Name)                          //выбираем фильтр в зависимости от названия кнопки
            {
                case "Gaussian3x3Button":
                    blur = Filters.Gaussian3x3BlurFilter;
                    break;
                case "Gaussian5x5Button":
                    blur = Filters.Gaussian5x5BlurFilter;
                    break;
            }
        }
        blurThread = new Thread(() =>
        {
            ChangeImage(blurPictureBox, IRIntegration.Properties.Resources.Loading);
            ChangeImage(blurKernalPictureBox, IRIntegration.Properties.Resources.Loading);
            if (noiseThread != null) noiseThread.Abort();
            if (reconstructionThread != null) reconstructionThread.Abort();
            //проводим свёртку
            ChangeImage(blurPictureBox, blur.Convolution(new Bitmap(sourceImage), ConvolutionFilter.ConvolutionMode.expand));
            //выведем размеры и ядро искажения
            ChangeText(bluredSizeText, blurPictureBox.Image.Height + " x" + blurPictureBox.Image.Width);
            ChangeImage(blurKernalPictureBox, Converter.ToImage(Mull(blur.normalizedFilterMatrix, 255)));
        });
        blurThread.Start();
    }

    /// <summary>
    /// Умножение матрицы на число
    /// </summary>
    /// <param name="matrix">матрица</param>
    /// <param name="val">число</param>
    /// <returns>матрица, умноженная на число</returns>
    private double[,] Mull(double[,] matrix, double val)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] *= val;
        return matrix;
    }

    /// <summary>
    /// Добавления шума
    /// </summary>
    private void AddNoise(object sender = null, EventArgs e = null)
    {
        if (noiseThread != null)
            noiseThread.Abort();
        if (blurThread != null)
            if (blurThread.ThreadState == ThreadState.Running)
            {
                MessageBox.Show("Bluring not complete. Please, wait a little.");
                return;
            }
        if (blurPictureBox.Image == null)
        {
            MessageBox.Show("At the firth you need to apply a blur.");
            return;
        }

        //обнуляем следующие этапы
        ChangeImage(recoveredPictureBox, null);
        ChangeText(recoveredSizeText, "-");
        ChangeImage(recoveryKernalPictureBox, null);

        noiseThread = new Thread(() =>
        {
            if (reconstructionThread != null) reconstructionThread.Abort();
            ChangeImage(noisePictureBox, IRIntegration.Properties.Resources.Loading);
            ChangeImage(noiseMaskPictureBox, IRIntegration.Properties.Resources.Loading);

            //применяем одиночный шум
            noize = new byte[blurPictureBox.Image.Height, blurPictureBox.Image.Width];
            ChangeImage(noisePictureBox, blurPictureBox.Image.SingleNoize(float.Parse(textBox1.Text), ref noize));
            //вывлжим дополниетльную информацию
            ChangeText(noiseSizeText, noisePictureBox.Image.Height + " x" + noisePictureBox.Image.Width);
            ChangeImage(noiseMaskPictureBox, Converter.ToImage(noize));
        });
        noiseThread.Start();
    }

    /// <summary>
    /// Проверка, правильно ли задан коэфициент шума
    /// </summary>
    private void NoizeCheckBoxLeave(object sender, EventArgs e)
    {
        float value = 0;                                            //зануляем значение
        textBox1.Text = textBox1.Text.Replace('.', ',');            //заменяем точки на запятые
        try
        {
            float.TryParse(textBox1.Text, out value);               //пробуем распарсить
        }
        catch { }

        if (value < 0)                                              //уложим значения в диапазон от 0 до 1
            value = 0;
        if (value > 1)
            value = 1;
        textBox1.Text = value.ToString();                           //вернём его в текст бокс
    }

    /// <summary>
    /// Восстановление изображения
    /// </summary>
    private void Recovery(object sender, EventArgs e)
    {
        if (noisePictureBox.Image == null)
        {
            MessageBox.Show("At the firth you need to apply a noise.");
            return;
        }
        if (reconstructionThread != null)
            reconstructionThread.Abort();
        if (blurThread != null)
            if (blurThread.ThreadState == ThreadState.Running)
            {
                MessageBox.Show("Bluring not complete. Please, wait a little.");
                return;
            }
        if (noiseThread != null)
            if (noiseThread.ThreadState == ThreadState.Running)
            {
                MessageBox.Show("Noising not complete. Please, wait a little.");
                return;
            }

        ConvolutionFilter filter = null;                            //обнуляем фильтр, возвращающий изображение в нормальный вид
        reconstructionThread = new Thread(() =>
        {
            ChangeImage(recoveredPictureBox, IRIntegration.Properties.Resources.Loading);
            ChangeImage(recoveryKernalPictureBox, IRIntegration.Properties.Resources.Loading);

            switch (((Button)sender).Name)                              //выбираем алгоритм в зависимости от времени
            {
                case "InverseButton":
                    filter = blur;
                    recoveredPictureBox.Image = InverseFiltering.Filtering(noisePictureBox.Image, blur);//filter.Convolution(new Bitmap(noisePictureBox.Image), ConvolutionFilter.ConvolutionMode.expand);
                    break;

            }
            //выводим дополнительную информацию
            try
            {
                ChangeText(recoveredSizeText, "? x ?");
            }
            catch (InvalidOperationException)
            {
                ChangeText(recoveredSizeText, recoveredPictureBox.Image.Height + " x" + recoveredPictureBox.Image.Width);
            }
            ChangeImage(recoveryKernalPictureBox, Converter.ToImage(Mull(filter.normalizedFilterMatrix, 255)));

        });
        reconstructionThread.Start();

    }

}