namespace Steganography
{
    partial class form_psnr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_psnr));
            this.Calculate = new System.Windows.Forms.Button();
            this.textImageStego = new System.Windows.Forms.Label();
            this.PSNR1 = new System.Windows.Forms.Label();
            this.textImageOrigin = new System.Windows.Forms.Label();
            this.ImageStego1 = new System.Windows.Forms.PictureBox();
            this.ImageOrigin1 = new System.Windows.Forms.PictureBox();
            this.result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageStego1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageOrigin1)).BeginInit();
            this.SuspendLayout();
            // 
            // Calculate
            // 
            this.Calculate.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calculate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.Calculate.Location = new System.Drawing.Point(247, 27);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(90, 30);
            this.Calculate.TabIndex = 0;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // textImageStego
            // 
            this.textImageStego.AutoSize = true;
            this.textImageStego.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textImageStego.Location = new System.Drawing.Point(420, 139);
            this.textImageStego.Name = "textImageStego";
            this.textImageStego.Size = new System.Drawing.Size(93, 16);
            this.textImageStego.TabIndex = 1;
            this.textImageStego.Text = "Stego Image";
            // 
            // PSNR1
            // 
            this.PSNR1.AutoSize = true;
            this.PSNR1.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PSNR1.Location = new System.Drawing.Point(184, 77);
            this.PSNR1.Name = "PSNR1";
            this.PSNR1.Size = new System.Drawing.Size(63, 21);
            this.PSNR1.TabIndex = 2;
            this.PSNR1.Text = "PSNR = ";
            // 
            // textImageOrigin
            // 
            this.textImageOrigin.AutoSize = true;
            this.textImageOrigin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textImageOrigin.Location = new System.Drawing.Point(110, 139);
            this.textImageOrigin.Name = "textImageOrigin";
            this.textImageOrigin.Size = new System.Drawing.Size(93, 16);
            this.textImageOrigin.TabIndex = 3;
            this.textImageOrigin.Text = "Origin Image";
            // 
            // ImageStego1
            // 
            this.ImageStego1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ImageStego1.BackgroundImage")));
            this.ImageStego1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImageStego1.Location = new System.Drawing.Point(321, 159);
            this.ImageStego1.Name = "ImageStego1";
            this.ImageStego1.Size = new System.Drawing.Size(290, 290);
            this.ImageStego1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageStego1.TabIndex = 4;
            this.ImageStego1.TabStop = false;
            this.ImageStego1.Click += new System.EventHandler(this.ImageStego1_Click);
            // 
            // ImageOrigin1
            // 
            this.ImageOrigin1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ImageOrigin1.BackgroundImage")));
            this.ImageOrigin1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImageOrigin1.Location = new System.Drawing.Point(12, 159);
            this.ImageOrigin1.Name = "ImageOrigin1";
            this.ImageOrigin1.Size = new System.Drawing.Size(290, 290);
            this.ImageOrigin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageOrigin1.TabIndex = 5;
            this.ImageOrigin1.TabStop = false;
            this.ImageOrigin1.Click += new System.EventHandler(this.ImageOrigin1_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(250, 81);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(16, 13);
            this.result.TabIndex = 6;
            this.result.Text = "   ";
            // 
            // form_psnr
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(622, 466);
            this.Controls.Add(this.result);
            this.Controls.Add(this.ImageOrigin1);
            this.Controls.Add(this.ImageStego1);
            this.Controls.Add(this.textImageOrigin);
            this.Controls.Add(this.PSNR1);
            this.Controls.Add(this.textImageStego);
            this.Controls.Add(this.Calculate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_psnr";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSNR";
            ((System.ComponentModel.ISupportInitialize)(this.ImageStego1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageOrigin1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureStego;
        private System.Windows.Forms.PictureBox pictureOrigin;
        private System.Windows.Forms.TextBox resultPSNR;
        private System.Windows.Forms.Button CalculatePSNR;
        private System.Windows.Forms.Button ImageOrigin;
        private System.Windows.Forms.Button ImageStego;
        private System.Windows.Forms.Label PSNR;
        private System.Windows.Forms.Label textStegoImage;
        private System.Windows.Forms.Label textOriginImage;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.Label textImageStego;
        private System.Windows.Forms.Label PSNR1;
        private System.Windows.Forms.Label textImageOrigin;
        private System.Windows.Forms.PictureBox ImageStego1;
        private System.Windows.Forms.PictureBox ImageOrigin1;
        private System.Windows.Forms.Label result;

    }
}