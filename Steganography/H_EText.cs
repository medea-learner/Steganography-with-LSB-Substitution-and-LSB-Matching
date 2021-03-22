using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public class H_EText
    {
        public static Bitmap hide(string t, string fileName)
        {
            //bmp.SetPixel(0, 0, Color.FromArgb(25, 30, 35));

            Bitmap bmp = (Bitmap)Image.FromFile(fileName);
            int r = 0, g = 0, b = 0;
            int cp = 0;//color position 
            
            if (t.Length > NbCaracStored(bmp))
            {
                if (main.english)
                {
                    MessageBox.Show("We can't store this Message because it has a big size", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Votre message a une taille plus grande que celle peut insérer dans l'image!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            else
            {
                Color pixel = bmp.GetPixel(0, 0);
                byte[] textB=Encoding.UTF8.GetBytes(t);
                int countByte = 0, bits = 0, countBit = 0, i = 0, j = 0, taille = textB.Length;


                //insertion de 00 * 2pixels + taille du texte en 4pixels(3bytes)
                //*1
                r = pixel.R - pixel.R % 4 ;
                g = pixel.G - pixel.G % 4;
                b = pixel.B - pixel.B % 4;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));

                j++;
                pixel = bmp.GetPixel(j ,i);

                r = pixel.R - pixel.R % 4;
                g = pixel.G - pixel.G % 4;
                b = pixel.B - pixel.B % 4;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));
            
                j++;
                pixel = bmp.GetPixel(j, i);
                
                //*2

                r = pixel.R - pixel.R % 4 + taille % 4;
                taille /= 4;             
                g = pixel.G - pixel.G % 4 + taille % 4;
                taille /= 4;
                b = pixel.B - pixel.B % 4 + taille % 4;
                taille /= 4;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));
            
                j++;
                pixel = bmp.GetPixel(j, i);
               
               
                r = pixel.R - pixel.R % 4 + taille % 4;
                taille /= 4;
                g = pixel.G - pixel.G % 4 + taille % 4;
                taille /= 4;
                b = pixel.B - pixel.B % 4 + taille % 4;
                taille /= 4;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));

                j++;
                pixel = bmp.GetPixel(j, i);

                r = pixel.R - pixel.R % 4 + taille % 4;
                taille /= 4;
                g = pixel.G - pixel.G % 4 + taille % 4;
                taille /= 4;
                b = pixel.B - pixel.B % 4 + taille % 4;
                taille /= 4;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));

                j++;
                pixel = bmp.GetPixel(j, i);

                r = pixel.R - pixel.R % 4 + taille % 4;
                taille /= 4;
                g = pixel.G - pixel.G % 4 + taille % 4;
                taille /= 4;
                b = pixel.B - pixel.B % 4 + taille % 4;
                taille /= 4;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));

                j++;

                
            begWhile :
                while (countByte < textB.Length)
                {
                    if (countBit < 7)
                    {
                        bits = textB[countByte] % 4;
                        textB[countByte] /= 4;
                        countBit += 2;
                    }
                    else
                    {
                        countBit = 0;
                        countByte++;
                        goto begWhile;
                    }
                begin :
                    
                    if (i < bmp.Height) {
                        if (j < bmp.Width)
                        {
                            pixel = bmp.GetPixel(j, i);
                            if (cp == 0)
                            {
                                r = pixel.R - pixel.R % 4 + bits;
                                bits = 0;
                                cp++;
                            }
                            else if (cp == 1)
                            {
                            
                                g = pixel.G - pixel.G % 4 + bits;
                                bits = 0;
                                cp++;
                            }
                            else if (cp == 2)
                            {
                                b = pixel.B - pixel.B % 4 + bits;
                                bits = 0;
                                cp = 0;
                                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));
                                j++;
                            }
                        }
                        else {
                            i++;
                            j = 0;
                            goto begin;
                        }
                    }
                    
                }//end while
                if (cp != 0) {
                    bmp.SetPixel(j, i, Color.FromArgb(r, g, b));
                }
     
            }
            return bmp;
        }
        //this Method return the number of caracters which can be stored in the image 
        public static int NbCaracStored(Bitmap bmp)
        {
            return (bmp.Width * bmp.Height - 6) * 3 / 4;// 3 pixels pour la taille du text en byte
        }

        public static string extract( Bitmap bmp)
        {
            string text = "";
            Color pixel = bmp.GetPixel(0, 0);
            int countByte = 0, countBit = 0, i = 0, j = 2, taille = 0;
            
            //on vérifie si l'image respecte les normes prédifinies
            //*1
            if(pixel.R % 4 != 0 || pixel.G % 4 != 0 || pixel.B % 4 != 0) {

                if (main.english)
                {
                    MessageBox.Show("This image doesn't contains message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Cette image ne contient aucun message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return null;
                
            }
            j++;
            pixel = bmp.GetPixel(1, 0);
            if (pixel.R % 4 != 0 || pixel.G % 4 != 0 || pixel.B % 4 != 0)
            {
                if (main.english)
                {
                    MessageBox.Show("This image doesn't contains message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Cette image ne contient aucun message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return null;
            }
            //*2
            i = 0;
            j = 2;
            
            pixel = bmp.GetPixel(j, i);
            taille = pixel.R % 4;
            taille += (pixel.G % 4) * 4;
            taille += (pixel.B % 4) * 16;
            j++;
            pixel = bmp.GetPixel(j, i);

            taille += (pixel.R % 4) * 64;
            taille += (pixel.G % 4) * 256;
            taille += (pixel.B % 4) * 1024;
           
            j++;
            pixel = bmp.GetPixel(j, i);

            taille += (pixel.R % 4) * 4096;
            taille += (pixel.G % 4) * 16384;
            taille += (pixel.B % 4) * 65536;

            j++;
            pixel = bmp.GetPixel(j, i);

            taille += (pixel.R % 4) * 262144;
            taille += (pixel.G % 4) * 1048576;
            taille += (pixel.B % 4) * 4194304;

            j++;
            byte[] textB = new Byte[taille];
            byte value = 0;
            int facteur = 1;
            while (countByte < taille)
            {
                
                if (i < bmp.Height)
                {
                    if (j < bmp.Width)
                    {
                        pixel = bmp.GetPixel(j, i);
                        value += (byte)((pixel.R % 4) * facteur);
                        facteur *= 4;
                        countBit += 2;
                        if (countBit > 7) {
                            textB[countByte] = value;
                            countByte++;
                            value = 0;
                            facteur = 1;
                            countBit = 0;
                        }
                        if (countByte < taille)
                        {
                            value += (byte)((pixel.G % 4) * facteur);
                            facteur *= 4;
                            countBit += 2;
                            if (countBit > 7)
                            {
                                textB[countByte] = value;
                                value = 0;
                                countByte++;
                                facteur = 1;
                                countBit = 0;
                            }
                        }
                        if (countByte < taille)
                        {
                            value += (byte)((pixel.B % 4) * facteur);
                            facteur *= 4;
                            countBit += 2;
                            if (countBit > 7)
                            {
                                textB[countByte] = value;
                                value = 0;
                                countByte++;
                                facteur = 1;
                                countBit = 0;
                            }
                        }
                        j++;
                    }
                    else {
                        j = 0;
                        i++;
                    }
                }
                
                    
            }//end while
            text = Encoding.UTF8.GetString(textB);
           
            return text;
        }
        
    }
}
