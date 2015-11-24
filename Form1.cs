using System;
using System.Drawing;
using System.Windows.Forms;
using ImageRecovery.NonBlind;
using ImageEditor;
using ImageRecovery;
using DeblurModification;

public partial class Form1 : Form
{
    private Image sourceImage;                                      //исходное изображение
    private byte[,] noize = null;                                   //шум
    private ConvolutionFilter blur;                                 //искажающий

    /// <summary>
    /// Конструкто
    /// </summary>
    /// <param name="path">Путь к открываемому файлу</param>
    public Form1(string[] path)
    {
        try
        {
            sourceImage = Image.FromFile(path[0]);                  //пытаемся грухить (может выскочить исключение)
            InitializeComponent();                                  //инициализируем компоненты
            sourcePictureBox.Image = sourceImage;                   //отрисуем избражение и укажим размеры
            sourceSizeText.Text = sourcePictureBox.Image.Height + " x" + sourcePictureBox.Image.Width;
        }
        catch
        {
            InitializeComponent();                                  //если поймали исключение - инициализируем компоненты
        }
    }

    /// <summary>
    /// Загрузка изображения
    /// </summary>
    private void LoadImage(object sender = null, EventArgs e = null)
    {
        OpenFileDialog ofd = new OpenFileDialog();                  //открываем диалог
        if (ofd.ShowDialog() == DialogResult.OK)                    //если файл был выбран
        {
            try
            {
                sourceImage = Image.FromFile(ofd.FileName);         //пытаемся его загрузить (может выскочить исключение)
                sourcePictureBox.Image = sourceImage;               //если загружено - отрисуем и выведем размер
                sourceSizeText.Text = sourcePictureBox.Image.Height + " x" + sourcePictureBox.Image.Width;

                blurPictureBox.Image = null;                        //обнулим все следующие шаги обработки изображения
                noisePictureBox.Image = null;
                recoveredPictureBox.Image = null;

                bluredSizeText.Text = "-";                          //их размеры
                noiseSizeText.Text = "-";
                recoveredSizeText.Text = "-";

                blurKernalPictureBox.Image = null;                  //и вспомогательные изображения
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
        if (sourceImage == null)                                    //если входного изображения нет
        {
            LoadImage();                                            //грузим его
            if (sourceImage == null)                                //если его всё равно нет (пользователь отказался)
                return;                                             //уходим
        }
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
            //проводим свёртку
            blurPictureBox.Image = blur.Convolution(new Bitmap(sourceImage), ConvolutionFilter.ConvolutionMode.expand);
        }
        //выведем размеры и ядро искажения
        bluredSizeText.Text = blurPictureBox.Image.Height + " x" + blurPictureBox.Image.Width;
        blurKernalPictureBox.Image = Converter.ToImage(Mull(blur.normalizedFilterMatrix, 255));
        //обнуляем следующие итапы
        noisePictureBox.Image = null;
        recoveredPictureBox.Image = null;
        noiseSizeText.Text = "-";
        recoveredSizeText.Text = "-";
        noiseMaskPictureBox.Image = null;
        recoveryKernalPictureBox.Image = null;
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
        if (blurPictureBox.Image == null)                           //если размытого изображения нет
        {
            AddBlur();                                              //пробуем его сделать
            if (blurPictureBox.Image == null)                       //если не получилось
                return;                                             //уходим
        }
        //применяем одиночный шум
        noize = new byte[blurPictureBox.Image.Height, blurPictureBox.Image.Width];
        noisePictureBox.Image = blurPictureBox.Image.SingleNoize(float.Parse(textBox1.Text), ref noize);

        //вывлжим дополниетльную информацию
        noiseSizeText.Text = noisePictureBox.Image.Height + " x" + noisePictureBox.Image.Width;
        noiseMaskPictureBox.Image = Converter.ToImage(noize);
        //обнуляем следующие итапы
        recoveredPictureBox.Image = null;
        recoveredSizeText.Text = "-";
        recoveryKernalPictureBox.Image = null;
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
        if (noisePictureBox.Image == null)                          //если зашумленного избражения нет
        {
            AddNoise();                                             //пытаемся его создать
            if (noisePictureBox.Image == null)                      //если не удалось
                return;                                             //уходим
        }
        ConvolutionFilter filter = null;                            //обнуляем фильтр, возвращающий изображение в нормальный вид
        double sourceMSDCBlur = sourceImage.MeanSquareDeviationComparator(blurPictureBox.Image);
        double sourceGradientBlur = sourceImage.Comparate(blurPictureBox.Image);
        switch (((Button)sender).Name)                              //выбираем алгоритм в зависимости от времени
        {
            case "InverseButton":
                filter = blur;//InverseFiltering.Filtering(blur);
                long start = System.DateTime.Now.Ticks;
                Image newImage = InverseFiltering.Filtering(blurPictureBox.Image, blur, false);//filter.Convolution(new Bitmap(noisePictureBox.Image), ConvolutionFilter.ConvolutionMode.expand);
                long time1 = System.DateTime.Now.Ticks - start;
                int hashcode1 = newImage.GetHashCode();

                double sourceRecoveryMSDCWithoutInterpolate = sourceImage.MeanSquareDeviationComparator(newImage);
                double sourceRecoveryGradientWithoutInterpolate = sourceImage.Comparate(newImage);
                start = System.DateTime.Now.Ticks;
                recoveredPictureBox.Image = InverseFiltering.Filtering(blurPictureBox.Image, blur, true);//filter.Convolution(new Bitmap(noisePictureBox.Image), ConvolutionFilter.ConvolutionMode.expand);
                long time2 = System.DateTime.Now.Ticks - start;
                double sourceRecoveryMSDCWithInterpolate = sourceImage.MeanSquareDeviationComparator(recoveredPictureBox.Image);
                double sourceRecoveryGradientWithInterpolate = sourceImage.Comparate(recoveredPictureBox.Image);

                string str = "СКО:\nБез восстановления: ";
                str += sourceMSDCBlur;
                str += "\nС восстановлением:\nБез интерполяции: ";
                str += sourceRecoveryMSDCWithoutInterpolate;
                str += "\nС интерполяцией: ";
                str += sourceRecoveryMSDCWithInterpolate;
                str += "\nКоэффициент: ";
                str += sourceRecoveryMSDCWithoutInterpolate / sourceRecoveryMSDCWithInterpolate;
                str += "\nГрадиент:\nБез восстановления: ";
                str += sourceGradientBlur;
                str += "\nС восстановлением:\nБез интерполяции: ";
                str += sourceRecoveryGradientWithoutInterpolate;
                str += "\nС интерполяцией: ";
                str += sourceRecoveryGradientWithInterpolate;
                str += "\nКоэффициент: ";
                str += sourceRecoveryGradientWithoutInterpolate / sourceRecoveryGradientWithInterpolate;
                MessageBox.Show(str);


                break;

            case "WienerButton":
                filter = WienerFiltering.Filtering(blur, sourceImage, noize);
                //производим конволющию
                recoveredPictureBox.Image = filter.Convolution(new Bitmap(noisePictureBox.Image), ConvolutionFilter.ConvolutionMode.expand);
                break;
            case "TikhonovButton":
                filter = TikhonovFiltering.Filtering(blur);
                //производим конволющию
                recoveredPictureBox.Image = filter.Convolution(new Bitmap(noisePictureBox.Image), ConvolutionFilter.ConvolutionMode.expand);
                break;
        }
        //выводим дополнительную информацию
        recoveredSizeText.Text = recoveredPictureBox.Image.Height + " x" + recoveredPictureBox.Image.Width;
        recoveryKernalPictureBox.Image = Converter.ToImage(Mull(filter.normalizedFilterMatrix, 255));


    }

}