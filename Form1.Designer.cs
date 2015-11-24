
partial class Form1
{
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.NoiseButton = new System.Windows.Forms.Button();
        this.TikhonovButton = new System.Windows.Forms.Button();
        this.Gaussian5x5Button = new System.Windows.Forms.Button();
        this.Gaussian3x3Button = new System.Windows.Forms.Button();
        this.WienerButton = new System.Windows.Forms.Button();
        this.LoadButton = new System.Windows.Forms.Button();
        this.sourcePictureBox = new System.Windows.Forms.PictureBox();
        this.blurPictureBox = new System.Windows.Forms.PictureBox();
        this.noisePictureBox = new System.Windows.Forms.PictureBox();
        this.recoveredPictureBox = new System.Windows.Forms.PictureBox();
        this.sourceGroupBox = new System.Windows.Forms.GroupBox();
        this.sourceSizeText = new System.Windows.Forms.Label();
        this.sourceSizeLabel = new System.Windows.Forms.Label();
        this.blurGroupBox = new System.Windows.Forms.GroupBox();
        this.blurKernalPictureBox = new System.Windows.Forms.PictureBox();
        this.blurKernalLabel = new System.Windows.Forms.Label();
        this.bluredSizeText = new System.Windows.Forms.Label();
        this.bluredSizeLabel = new System.Windows.Forms.Label();
        this.noiseGroupBox = new System.Windows.Forms.GroupBox();
        this.noiseMaskPictureBox = new System.Windows.Forms.PictureBox();
        this.noiseKernalLabel = new System.Windows.Forms.Label();
        this.noiseSizeText = new System.Windows.Forms.Label();
        this.noiseSizeNoise = new System.Windows.Forms.Label();
        this.RecoveryGroupBox = new System.Windows.Forms.GroupBox();
        this.recoveryKernalPictureBox = new System.Windows.Forms.PictureBox();
        this.recoveryKernalLabel = new System.Windows.Forms.Label();
        this.recoveredSizeText = new System.Windows.Forms.Label();
        this.recoveredSizeLabel = new System.Windows.Forms.Label();
        this.InverseButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.blurPictureBox)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.noisePictureBox)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.recoveredPictureBox)).BeginInit();
        this.sourceGroupBox.SuspendLayout();
        this.blurGroupBox.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.blurKernalPictureBox)).BeginInit();
        this.noiseGroupBox.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.noiseMaskPictureBox)).BeginInit();
        this.RecoveryGroupBox.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.recoveryKernalPictureBox)).BeginInit();
        this.SuspendLayout();
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(6, 22);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(115, 20);
        this.textBox1.TabIndex = 7;
        this.textBox1.Text = "0";
        this.textBox1.Leave += new System.EventHandler(this.NoizeCheckBoxLeave);
        // 
        // NoiseButton
        // 
        this.NoiseButton.Location = new System.Drawing.Point(127, 20);
        this.NoiseButton.Name = "NoiseButton";
        this.NoiseButton.Size = new System.Drawing.Size(121, 23);
        this.NoiseButton.TabIndex = 6;
        this.NoiseButton.Text = "Добавить";
        this.NoiseButton.UseVisualStyleBackColor = true;
        this.NoiseButton.Click += new System.EventHandler(this.AddNoise);
        // 
        // TikhonovButton
        // 
        this.TikhonovButton.Location = new System.Drawing.Point(170, 19);
        this.TikhonovButton.Name = "TikhonovButton";
        this.TikhonovButton.Size = new System.Drawing.Size(78, 23);
        this.TikhonovButton.TabIndex = 5;
        this.TikhonovButton.Text = "Тихонов";
        this.TikhonovButton.UseVisualStyleBackColor = true;
        this.TikhonovButton.Click += new System.EventHandler(this.Recovery);
        // 
        // Gaussian5x5Button
        // 
        this.Gaussian5x5Button.Location = new System.Drawing.Point(131, 19);
        this.Gaussian5x5Button.Name = "Gaussian5x5Button";
        this.Gaussian5x5Button.Size = new System.Drawing.Size(120, 23);
        this.Gaussian5x5Button.TabIndex = 4;
        this.Gaussian5x5Button.Text = "5x5";
        this.Gaussian5x5Button.Click += new System.EventHandler(this.AddBlur);
        // 
        // Gaussian3x3Button
        // 
        this.Gaussian3x3Button.Location = new System.Drawing.Point(9, 19);
        this.Gaussian3x3Button.Name = "Gaussian3x3Button";
        this.Gaussian3x3Button.Size = new System.Drawing.Size(116, 23);
        this.Gaussian3x3Button.TabIndex = 3;
        this.Gaussian3x3Button.Text = "3х3";
        this.Gaussian3x3Button.UseVisualStyleBackColor = true;
        this.Gaussian3x3Button.Click += new System.EventHandler(this.AddBlur);
        // 
        // WienerButton
        // 
        this.WienerButton.Location = new System.Drawing.Point(85, 19);
        this.WienerButton.Name = "WienerButton";
        this.WienerButton.Size = new System.Drawing.Size(84, 23);
        this.WienerButton.TabIndex = 1;
        this.WienerButton.Text = "Винер";
        this.WienerButton.UseVisualStyleBackColor = true;
        this.WienerButton.Click += new System.EventHandler(this.Recovery);
        // 
        // LoadButton
        // 
        this.LoadButton.Location = new System.Drawing.Point(9, 19);
        this.LoadButton.Name = "LoadButton";
        this.LoadButton.Size = new System.Drawing.Size(242, 23);
        this.LoadButton.TabIndex = 0;
        this.LoadButton.Text = "Загрузить";
        this.LoadButton.UseVisualStyleBackColor = true;
        this.LoadButton.Click += new System.EventHandler(this.LoadImage);
        // 
        // sourcePictureBox
        // 
        this.sourcePictureBox.InitialImage = null;
        this.sourcePictureBox.Location = new System.Drawing.Point(9, 48);
        this.sourcePictureBox.Name = "sourcePictureBox";
        this.sourcePictureBox.Size = new System.Drawing.Size(242, 256);
        this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.sourcePictureBox.TabIndex = 0;
        this.sourcePictureBox.TabStop = false;
        this.sourcePictureBox.Click += new System.EventHandler(this.LoadImage);
        // 
        // blurPictureBox
        // 
        this.blurPictureBox.Location = new System.Drawing.Point(9, 48);
        this.blurPictureBox.Name = "blurPictureBox";
        this.blurPictureBox.Size = new System.Drawing.Size(242, 256);
        this.blurPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.blurPictureBox.TabIndex = 0;
        this.blurPictureBox.TabStop = false;
        // 
        // noisePictureBox
        // 
        this.noisePictureBox.Location = new System.Drawing.Point(6, 49);
        this.noisePictureBox.Name = "noisePictureBox";
        this.noisePictureBox.Size = new System.Drawing.Size(242, 256);
        this.noisePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.noisePictureBox.TabIndex = 0;
        this.noisePictureBox.TabStop = false;
        // 
        // recoveredPictureBox
        // 
        this.recoveredPictureBox.Location = new System.Drawing.Point(6, 48);
        this.recoveredPictureBox.Name = "recoveredPictureBox";
        this.recoveredPictureBox.Size = new System.Drawing.Size(242, 256);
        this.recoveredPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.recoveredPictureBox.TabIndex = 0;
        this.recoveredPictureBox.TabStop = false;
        // 
        // sourceGroupBox
        // 
        this.sourceGroupBox.Controls.Add(this.sourceSizeText);
        this.sourceGroupBox.Controls.Add(this.sourceSizeLabel);
        this.sourceGroupBox.Controls.Add(this.sourcePictureBox);
        this.sourceGroupBox.Controls.Add(this.LoadButton);
        this.sourceGroupBox.Location = new System.Drawing.Point(12, 12);
        this.sourceGroupBox.Name = "sourceGroupBox";
        this.sourceGroupBox.Size = new System.Drawing.Size(257, 433);
        this.sourceGroupBox.TabIndex = 3;
        this.sourceGroupBox.TabStop = false;
        this.sourceGroupBox.Text = "Исходное";
        // 
        // sourceSizeText
        // 
        this.sourceSizeText.AutoSize = true;
        this.sourceSizeText.Location = new System.Drawing.Point(61, 323);
        this.sourceSizeText.Name = "sourceSizeText";
        this.sourceSizeText.Size = new System.Drawing.Size(10, 13);
        this.sourceSizeText.TabIndex = 2;
        this.sourceSizeText.Text = "-";
        // 
        // sourceSizeLabel
        // 
        this.sourceSizeLabel.AutoSize = true;
        this.sourceSizeLabel.Location = new System.Drawing.Point(6, 323);
        this.sourceSizeLabel.Name = "sourceSizeLabel";
        this.sourceSizeLabel.Size = new System.Drawing.Size(49, 13);
        this.sourceSizeLabel.TabIndex = 1;
        this.sourceSizeLabel.Text = "Размер:";
        // 
        // blurGroupBox
        // 
        this.blurGroupBox.Controls.Add(this.blurKernalPictureBox);
        this.blurGroupBox.Controls.Add(this.blurKernalLabel);
        this.blurGroupBox.Controls.Add(this.bluredSizeText);
        this.blurGroupBox.Controls.Add(this.blurPictureBox);
        this.blurGroupBox.Controls.Add(this.bluredSizeLabel);
        this.blurGroupBox.Controls.Add(this.Gaussian3x3Button);
        this.blurGroupBox.Controls.Add(this.Gaussian5x5Button);
        this.blurGroupBox.Location = new System.Drawing.Point(275, 12);
        this.blurGroupBox.Name = "blurGroupBox";
        this.blurGroupBox.Size = new System.Drawing.Size(257, 433);
        this.blurGroupBox.TabIndex = 4;
        this.blurGroupBox.TabStop = false;
        this.blurGroupBox.Text = "Смазанное";
        // 
        // blurKernalPictureBox
        // 
        this.blurKernalPictureBox.Location = new System.Drawing.Point(64, 345);
        this.blurKernalPictureBox.Name = "blurKernalPictureBox";
        this.blurKernalPictureBox.Size = new System.Drawing.Size(82, 82);
        this.blurKernalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.blurKernalPictureBox.TabIndex = 6;
        this.blurKernalPictureBox.TabStop = false;
        // 
        // blurKernalLabel
        // 
        this.blurKernalLabel.AutoSize = true;
        this.blurKernalLabel.Location = new System.Drawing.Point(6, 345);
        this.blurKernalLabel.Name = "blurKernalLabel";
        this.blurKernalLabel.Size = new System.Drawing.Size(36, 13);
        this.blurKernalLabel.TabIndex = 5;
        this.blurKernalLabel.Text = "Ядро:";
        // 
        // bluredSizeText
        // 
        this.bluredSizeText.AutoSize = true;
        this.bluredSizeText.Location = new System.Drawing.Point(61, 323);
        this.bluredSizeText.Name = "bluredSizeText";
        this.bluredSizeText.Size = new System.Drawing.Size(10, 13);
        this.bluredSizeText.TabIndex = 4;
        this.bluredSizeText.Text = "-";
        // 
        // bluredSizeLabel
        // 
        this.bluredSizeLabel.AutoSize = true;
        this.bluredSizeLabel.Location = new System.Drawing.Point(6, 323);
        this.bluredSizeLabel.Name = "bluredSizeLabel";
        this.bluredSizeLabel.Size = new System.Drawing.Size(49, 13);
        this.bluredSizeLabel.TabIndex = 3;
        this.bluredSizeLabel.Text = "Размер:";
        // 
        // noiseGroupBox
        // 
        this.noiseGroupBox.Controls.Add(this.noiseMaskPictureBox);
        this.noiseGroupBox.Controls.Add(this.noiseKernalLabel);
        this.noiseGroupBox.Controls.Add(this.noiseSizeText);
        this.noiseGroupBox.Controls.Add(this.NoiseButton);
        this.noiseGroupBox.Controls.Add(this.noiseSizeNoise);
        this.noiseGroupBox.Controls.Add(this.textBox1);
        this.noiseGroupBox.Controls.Add(this.noisePictureBox);
        this.noiseGroupBox.Location = new System.Drawing.Point(538, 12);
        this.noiseGroupBox.Name = "noiseGroupBox";
        this.noiseGroupBox.Size = new System.Drawing.Size(257, 433);
        this.noiseGroupBox.TabIndex = 5;
        this.noiseGroupBox.TabStop = false;
        this.noiseGroupBox.Text = "Зашумленное";
        // 
        // noiseMaskPictureBox
        // 
        this.noiseMaskPictureBox.Location = new System.Drawing.Point(64, 345);
        this.noiseMaskPictureBox.Name = "noiseMaskPictureBox";
        this.noiseMaskPictureBox.Size = new System.Drawing.Size(82, 82);
        this.noiseMaskPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.noiseMaskPictureBox.TabIndex = 12;
        this.noiseMaskPictureBox.TabStop = false;
        // 
        // noiseKernalLabel
        // 
        this.noiseKernalLabel.AutoSize = true;
        this.noiseKernalLabel.Location = new System.Drawing.Point(6, 345);
        this.noiseKernalLabel.Name = "noiseKernalLabel";
        this.noiseKernalLabel.Size = new System.Drawing.Size(32, 13);
        this.noiseKernalLabel.TabIndex = 11;
        this.noiseKernalLabel.Text = "Шум:";
        // 
        // noiseSizeText
        // 
        this.noiseSizeText.AutoSize = true;
        this.noiseSizeText.Location = new System.Drawing.Point(61, 323);
        this.noiseSizeText.Name = "noiseSizeText";
        this.noiseSizeText.Size = new System.Drawing.Size(10, 13);
        this.noiseSizeText.TabIndex = 8;
        this.noiseSizeText.Text = "-";
        // 
        // noiseSizeNoise
        // 
        this.noiseSizeNoise.AutoSize = true;
        this.noiseSizeNoise.Location = new System.Drawing.Point(6, 323);
        this.noiseSizeNoise.Name = "noiseSizeNoise";
        this.noiseSizeNoise.Size = new System.Drawing.Size(49, 13);
        this.noiseSizeNoise.TabIndex = 7;
        this.noiseSizeNoise.Text = "Размер:";
        // 
        // RecoveryGroupBox
        // 
        this.RecoveryGroupBox.Controls.Add(this.InverseButton);
        this.RecoveryGroupBox.Controls.Add(this.recoveryKernalPictureBox);
        this.RecoveryGroupBox.Controls.Add(this.recoveryKernalLabel);
        this.RecoveryGroupBox.Controls.Add(this.recoveredSizeText);
        this.RecoveryGroupBox.Controls.Add(this.TikhonovButton);
        this.RecoveryGroupBox.Controls.Add(this.recoveredSizeLabel);
        this.RecoveryGroupBox.Controls.Add(this.WienerButton);
        this.RecoveryGroupBox.Controls.Add(this.recoveredPictureBox);
        this.RecoveryGroupBox.Location = new System.Drawing.Point(801, 12);
        this.RecoveryGroupBox.Name = "RecoveryGroupBox";
        this.RecoveryGroupBox.Size = new System.Drawing.Size(257, 433);
        this.RecoveryGroupBox.TabIndex = 6;
        this.RecoveryGroupBox.TabStop = false;
        this.RecoveryGroupBox.Text = "Восстановленное";
        // 
        // recoveryKernalPictureBox
        // 
        this.recoveryKernalPictureBox.Location = new System.Drawing.Point(64, 345);
        this.recoveryKernalPictureBox.Name = "recoveryKernalPictureBox";
        this.recoveryKernalPictureBox.Size = new System.Drawing.Size(82, 82);
        this.recoveryKernalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.recoveryKernalPictureBox.TabIndex = 8;
        this.recoveryKernalPictureBox.TabStop = false;
        // 
        // recoveryKernalLabel
        // 
        this.recoveryKernalLabel.AutoSize = true;
        this.recoveryKernalLabel.Location = new System.Drawing.Point(6, 345);
        this.recoveryKernalLabel.Name = "recoveryKernalLabel";
        this.recoveryKernalLabel.Size = new System.Drawing.Size(36, 13);
        this.recoveryKernalLabel.TabIndex = 7;
        this.recoveryKernalLabel.Text = "Ядро:";
        // 
        // recoveredSizeText
        // 
        this.recoveredSizeText.AutoSize = true;
        this.recoveredSizeText.Location = new System.Drawing.Point(61, 323);
        this.recoveredSizeText.Name = "recoveredSizeText";
        this.recoveredSizeText.Size = new System.Drawing.Size(10, 13);
        this.recoveredSizeText.TabIndex = 10;
        this.recoveredSizeText.Text = "-";
        // 
        // recoveredSizeLabel
        // 
        this.recoveredSizeLabel.AutoSize = true;
        this.recoveredSizeLabel.Location = new System.Drawing.Point(6, 323);
        this.recoveredSizeLabel.Name = "recoveredSizeLabel";
        this.recoveredSizeLabel.Size = new System.Drawing.Size(49, 13);
        this.recoveredSizeLabel.TabIndex = 9;
        this.recoveredSizeLabel.Text = "Размер:";
        // 
        // InverseButton
        // 
        this.InverseButton.Location = new System.Drawing.Point(6, 19);
        this.InverseButton.Name = "InverseButton";
        this.InverseButton.Size = new System.Drawing.Size(78, 23);
        this.InverseButton.TabIndex = 11;
        this.InverseButton.Text = "Инверсная";
        this.InverseButton.UseVisualStyleBackColor = true;
        this.InverseButton.Click += new System.EventHandler(this.Recovery);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1067, 457);
        this.Controls.Add(this.RecoveryGroupBox);
        this.Controls.Add(this.noiseGroupBox);
        this.Controls.Add(this.blurGroupBox);
        this.Controls.Add(this.sourceGroupBox);
        this.Name = "Form1";
        this.Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.blurPictureBox)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.noisePictureBox)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.recoveredPictureBox)).EndInit();
        this.sourceGroupBox.ResumeLayout(false);
        this.sourceGroupBox.PerformLayout();
        this.blurGroupBox.ResumeLayout(false);
        this.blurGroupBox.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.blurKernalPictureBox)).EndInit();
        this.noiseGroupBox.ResumeLayout(false);
        this.noiseGroupBox.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.noiseMaskPictureBox)).EndInit();
        this.RecoveryGroupBox.ResumeLayout(false);
        this.RecoveryGroupBox.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.recoveryKernalPictureBox)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button WienerButton;
    private System.Windows.Forms.Button LoadButton;
    private System.Windows.Forms.PictureBox sourcePictureBox;
    private System.Windows.Forms.PictureBox blurPictureBox;
    private System.Windows.Forms.Button Gaussian3x3Button;
    private System.Windows.Forms.Button Gaussian5x5Button;
    private System.Windows.Forms.Button TikhonovButton;
    private System.Windows.Forms.PictureBox noisePictureBox;
    private System.Windows.Forms.Button NoiseButton;
    private System.Windows.Forms.PictureBox recoveredPictureBox;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.GroupBox sourceGroupBox;
    private System.Windows.Forms.GroupBox blurGroupBox;
    private System.Windows.Forms.Label sourceSizeLabel;
    private System.Windows.Forms.GroupBox noiseGroupBox;
    private System.Windows.Forms.GroupBox RecoveryGroupBox;
    private System.Windows.Forms.Label sourceSizeText;
    private System.Windows.Forms.Label bluredSizeText;
    private System.Windows.Forms.Label bluredSizeLabel;
    private System.Windows.Forms.Label noiseSizeText;
    private System.Windows.Forms.Label noiseSizeNoise;
    private System.Windows.Forms.Label recoveredSizeText;
    private System.Windows.Forms.Label recoveredSizeLabel;
    private System.Windows.Forms.PictureBox blurKernalPictureBox;
    private System.Windows.Forms.Label blurKernalLabel;
    private System.Windows.Forms.PictureBox noiseMaskPictureBox;
    private System.Windows.Forms.Label noiseKernalLabel;
    private System.Windows.Forms.PictureBox recoveryKernalPictureBox;
    private System.Windows.Forms.Label recoveryKernalLabel;
    private System.Windows.Forms.Button InverseButton;
}

