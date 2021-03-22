namespace Steganography
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.buttonExtract = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.messageText = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imagePathText = new System.Windows.Forms.Label();
            this.filePathtext = new System.Windows.Forms.Label();
            this.radioChoice_t = new System.Windows.Forms.RadioButton();
            this.radioChoice_d = new System.Windows.Forms.RadioButton();
            this.le_type = new System.Windows.Forms.Label();
            this.notification = new System.Windows.Forms.TextBox();
            this.MethodChoice = new System.Windows.Forms.ComboBox();
            this.method = new System.Windows.Forms.Label();
            this.Imagepath = new System.Windows.Forms.Label();
            this.filepathbutton = new System.Windows.Forms.Label();
            this.OpenFile = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSNRToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.image = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExtract
            // 
            this.buttonExtract.AllowDrop = true;
            this.buttonExtract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.buttonExtract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExtract.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExtract.ForeColor = System.Drawing.Color.SaddleBrown;
            this.buttonExtract.Location = new System.Drawing.Point(381, 482);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(154, 51);
            this.buttonExtract.TabIndex = 0;
            this.buttonExtract.Text = "Extract";
            this.buttonExtract.UseVisualStyleBackColor = false;
            this.buttonExtract.Click += new System.EventHandler(this.button_Extract);
            // 
            // buttonHide
            // 
            this.buttonHide.AllowDrop = true;
            this.buttonHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.buttonHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHide.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHide.ForeColor = System.Drawing.Color.SaddleBrown;
            this.buttonHide.Location = new System.Drawing.Point(150, 482);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(154, 51);
            this.buttonHide.TabIndex = 1;
            this.buttonHide.Text = "Hide";
            this.buttonHide.UseVisualStyleBackColor = false;
            this.buttonHide.Click += new System.EventHandler(this.button_Hide);
            // 
            // messageText
            // 
            this.messageText.AutoSize = true;
            this.messageText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.messageText.Location = new System.Drawing.Point(51, 396);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(188, 16);
            this.messageText.TabIndex = 2;
            this.messageText.Text = "Write your message here :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 415);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(225, 46);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // imagePathText
            // 
            this.imagePathText.AutoSize = true;
            this.imagePathText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagePathText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.imagePathText.Location = new System.Drawing.Point(159, 298);
            this.imagePathText.Name = "imagePathText";
            this.imagePathText.Size = new System.Drawing.Size(91, 14);
            this.imagePathText.TabIndex = 7;
            this.imagePathText.Text = "Image Path :";
            // 
            // filePathtext
            // 
            this.filePathtext.AutoSize = true;
            this.filePathtext.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathtext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.filePathtext.Location = new System.Drawing.Point(382, 441);
            this.filePathtext.Name = "filePathtext";
            this.filePathtext.Size = new System.Drawing.Size(84, 14);
            this.filePathtext.TabIndex = 8;
            this.filePathtext.Text = "File Path :";
            // 
            // radioChoice_t
            // 
            this.radioChoice_t.AutoSize = true;
            this.radioChoice_t.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioChoice_t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.radioChoice_t.Location = new System.Drawing.Point(213, 351);
            this.radioChoice_t.Name = "radioChoice_t";
            this.radioChoice_t.Size = new System.Drawing.Size(44, 19);
            this.radioChoice_t.TabIndex = 11;
            this.radioChoice_t.Text = "text";
            this.radioChoice_t.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioChoice_t.UseVisualStyleBackColor = true;
            this.radioChoice_t.CheckedChanged += new System.EventHandler(this.radioChoice_t_CheckedChanged);
            // 
            // radioChoice_d
            // 
            this.radioChoice_d.AutoSize = true;
            this.radioChoice_d.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioChoice_d.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.radioChoice_d.Location = new System.Drawing.Point(385, 351);
            this.radioChoice_d.Name = "radioChoice_d";
            this.radioChoice_d.Size = new System.Drawing.Size(41, 19);
            this.radioChoice_d.TabIndex = 12;
            this.radioChoice_d.TabStop = true;
            this.radioChoice_d.Text = "file";
            this.radioChoice_d.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioChoice_d.UseVisualStyleBackColor = true;
            // 
            // le_type
            // 
            this.le_type.AutoSize = true;
            this.le_type.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.le_type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.le_type.Location = new System.Drawing.Point(12, 335);
            this.le_type.Name = "le_type";
            this.le_type.Size = new System.Drawing.Size(177, 16);
            this.le_type.TabIndex = 13;
            this.le_type.Text = "The type of your message :";
            // 
            // notification
            // 
            this.notification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.notification.Cursor = System.Windows.Forms.Cursors.Default;
            this.notification.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notification.ForeColor = System.Drawing.Color.Olive;
            this.notification.Location = new System.Drawing.Point(213, 576);
            this.notification.Multiline = true;
            this.notification.Name = "notification";
            this.notification.ReadOnly = true;
            this.notification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.notification.Size = new System.Drawing.Size(315, 54);
            this.notification.TabIndex = 14;
            this.notification.Tag = "";
            this.notification.Text = "Note :";
            this.notification.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MethodChoice
            // 
            this.MethodChoice.FormattingEnabled = true;
            this.MethodChoice.Items.AddRange(new object[] {
            "LSB Matching",
            "LSB Replacement"});
            this.MethodChoice.Location = new System.Drawing.Point(330, 41);
            this.MethodChoice.Name = "MethodChoice";
            this.MethodChoice.Size = new System.Drawing.Size(121, 21);
            this.MethodChoice.TabIndex = 23;
            this.MethodChoice.SelectedIndexChanged += new System.EventHandler(this.MethodChoice_SelectedIndexChanged);
            // 
            // method
            // 
            this.method.AutoSize = true;
            this.method.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.method.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.method.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.method.Location = new System.Drawing.Point(209, 42);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(115, 20);
            this.method.TabIndex = 24;
            this.method.Text = "Method used :";
            // 
            // Imagepath
            // 
            this.Imagepath.AutoSize = true;
            this.Imagepath.Location = new System.Drawing.Point(280, 298);
            this.Imagepath.Name = "Imagepath";
            this.Imagepath.Size = new System.Drawing.Size(0, 13);
            this.Imagepath.TabIndex = 25;
            // 
            // filepathbutton
            // 
            this.filepathbutton.AutoSize = true;
            this.filepathbutton.Location = new System.Drawing.Point(430, 455);
            this.filepathbutton.Name = "filepathbutton";
            this.filepathbutton.Size = new System.Drawing.Size(0, 13);
            this.filepathbutton.TabIndex = 26;
            // 
            // OpenFile
            // 
            this.OpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.OpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenFile.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.OpenFile.Location = new System.Drawing.Point(385, 410);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(71, 22);
            this.OpenFile.TabIndex = 10;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = false;
            this.OpenFile.Click += new System.EventHandler(this.button_OpenFile);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.LanguageToolStripMenuItem1,
            this.helpToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(726, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.optionToolStripMenuItem.Text = "&File";
            // 
            // OpenImageToolStripMenuItem
            // 
            this.OpenImageToolStripMenuItem.Name = "OpenImageToolStripMenuItem";
            this.OpenImageToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.OpenImageToolStripMenuItem.Text = "&Open image";
            this.OpenImageToolStripMenuItem.Click += new System.EventHandler(this.pSNRToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pSNRToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.helpToolStripMenuItem.Text = "&Evaluate";
            // 
            // pSNRToolStripMenuItem1
            // 
            this.pSNRToolStripMenuItem1.Name = "pSNRToolStripMenuItem1";
            this.pSNRToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.pSNRToolStripMenuItem1.Text = "&PSNR";
            this.pSNRToolStripMenuItem1.Click += new System.EventHandler(this.pSNRToolStripMenuItem1_Click);
            // 
            // LanguageToolStripMenuItem1
            // 
            this.LanguageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.frenchToolStripMenuItem});
            this.LanguageToolStripMenuItem1.Name = "LanguageToolStripMenuItem1";
            this.LanguageToolStripMenuItem1.Size = new System.Drawing.Size(71, 20);
            this.LanguageToolStripMenuItem1.Text = "&Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "&English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // frenchToolStripMenuItem
            // 
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            this.frenchToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.frenchToolStripMenuItem.Text = "&French";
            this.frenchToolStripMenuItem.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem2
            // 
            this.helpToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
            this.helpToolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem2.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.White;
            this.image.BackgroundImage = global::Steganography.Properties.Resources.mainChoose;
            this.image.Cursor = System.Windows.Forms.Cursors.Hand;
            this.image.Location = new System.Drawing.Point(203, 81);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(336, 210);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 22;
            this.image.TabStop = false;
            this.image.Click += new System.EventHandler(this.image_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(230)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(726, 639);
            this.Controls.Add(this.filepathbutton);
            this.Controls.Add(this.Imagepath);
            this.Controls.Add(this.method);
            this.Controls.Add(this.MethodChoice);
            this.Controls.Add(this.image);
            this.Controls.Add(this.notification);
            this.Controls.Add(this.le_type);
            this.Controls.Add(this.radioChoice_d);
            this.Controls.Add(this.radioChoice_t);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.filePathtext);
            this.Controls.Add(this.imagePathText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonExtract);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steganography";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Label messageText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label imagePathText;
        private System.Windows.Forms.Label filePathtext;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.RadioButton radioChoice_t;
        private System.Windows.Forms.RadioButton radioChoice_d;
        private System.Windows.Forms.Label le_type;
        private System.Windows.Forms.TextBox notification;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.ComboBox MethodChoice;
        private System.Windows.Forms.Label method;
        private System.Windows.Forms.Label Imagepath;
        private System.Windows.Forms.Label filepathbutton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pSNRToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

