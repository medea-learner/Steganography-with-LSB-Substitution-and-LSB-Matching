using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class form_psnr : Form
    {
        private Bitmap bmpStego = null, bmpOrigin = null;
        public double psnr = 0;

        public form_psnr()
        {
            InitializeComponent();
            if (!main.english) 
            {
                Calculate.Text = "Calculer";
                textImageOrigin.Text = "Image Origine";
                textImageStego.Text = "Image Stégo";
                ImageStego1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.psnrChoisir;
                ImageOrigin1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.psnrChoisir;
            }
        }
        public void Calculer()
        {
            if (bmpStego == null || bmpOrigin == null)
            {
                if (main.english)
                {
                    MessageBox.Show("you must choose the stego and origin images!!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("vous devez choisir les deux images -origine & stégo- !!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {

                if (bmpOrigin.Height == bmpStego.Height && bmpStego.Width == bmpOrigin.Width)
                {
                    this.Cursor = System.Windows.Forms.Cursors.AppStarting;

                    double PSNR = 0, MSE;
                    int SN = 0, SMB, SMG, SMR;

                    for (int i = 0; i < bmpOrigin.Height; i++)
                    {
                        SMB = 0; SMG = 0; SMR = 0;
                        for (int j = 0; j < bmpOrigin.Width; j++)
                        {

                            SMR += (int)Math.Pow((bmpOrigin.GetPixel(j, i).R - bmpStego.GetPixel(j, i).R), 2);
                            SMG += (int)Math.Pow((bmpOrigin.GetPixel(j, i).G - bmpStego.GetPixel(j, i).G), 2);
                            SMB += (int)Math.Pow((bmpOrigin.GetPixel(j, i).B - bmpStego.GetPixel(j, i).B), 2);
                        }
                        SN += SMR + SMG + SMB;
                    }
                    MSE = SN;
                    MSE /= (bmpStego.Height * bmpStego.Width * 3);
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;
                    //MessageBox.Show("MSE = "+ MSE.ToString());
                    if (MSE != 0)
                    {
                        PSNR = 10 * Math.Log10(Math.Pow(255, 2) / MSE);
                        result.Text = PSNR.ToString();
                        //psnr = PSNR;
                    }
                    else
                    {
                        if (main.english)
                        {
                            MessageBox.Show("these two images seem similar");
                        }
                        else
                        {
                            MessageBox.Show("Ces deux images semblent pareilles");
                        }
                    }

                    textImageOrigin.ForeColor = System.Drawing.Color.Black;
                    textImageStego.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    if (main.english)
                    {
                        MessageBox.Show("these two images are not correct");
                    }
                    else
                    {
                        MessageBox.Show("Ces deux images ne sont pas correctes");
                    }

                    textImageOrigin.ForeColor = System.Drawing.Color.Black;
                    textImageStego.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
        private void Calculate_Click(object sender, EventArgs e)
        {
            this.Calculer();
        }
        public void setBmpOrigin(Bitmap bmp)
        {
            bmpOrigin = bmp;
            ImageOrigin1.Image = bmp;
            textImageOrigin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            
        }
        public void setBmpStego(Bitmap bmp)
        {
            bmpStego = bmp;
            ImageStego1.Image = bmp;
            textImageStego.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
        }
        private void ImageOrigin1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.png; *.bmp; *.jpg)|*.png; *.bmp; *.jpg";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                bmpOrigin = (Bitmap)Image.FromFile(open_dialog.FileName);
                ImageOrigin1.Image = Image.FromFile(open_dialog.FileName);
                //if we choose the bmpStego then we change the ForeColor of the concerned button
                textImageOrigin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
            }
        }

        private void ImageStego1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.png; *.bmp; *.jpg)|*.png; *.bmp; *.jpg";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bmpStego = (Bitmap)Image.FromFile(open_dialog.FileName);
                    ImageStego1.Image = Image.FromFile(open_dialog.FileName);
                    //if we choose the bmpStego then we change the ForeColor of the concerned button
                    textImageStego.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(35)))), ((int)(((byte)(39)))));
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.StackTrace.ToString());
                }
            }
        }





        public void Calcul(Bitmap bmp, Bitmap bmp_)
        {
            this.setBmpOrigin(bmp);
            this.setBmpStego(bmp_);
            this.Calculer();
        }
    }
}
