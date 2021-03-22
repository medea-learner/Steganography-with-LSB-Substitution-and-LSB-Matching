using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    class M_Text
    {
        public static int initValue = 0;
        public static bool gpsn = true;
        public static Bitmap embed(string t, string fileName, int initialValue)
        {
            int r = 0, g = 0, b = 0;
            Bitmap bmp = (Bitmap)Image.FromFile(fileName);
            if (t.Length > NbCaracStored(bmp))
            {
                if (main.english)
                {
                    MessageBox.Show("We can't store this Message because it has a big length", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Ce message est de grand taille veuillez essayer avec un autre de taille plus petite!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                Color pixel = bmp.GetPixel(0, 0);
                byte[] textB = Encoding.UTF8.GetBytes(t);
                int countByte = 0, countBit = 0, i = 0, j = 0, taille = textB.Length;


                //insertion de 00 * 2pixels + taille du texte en 4pixels(3bytes)
                //*1
                r = pixel.R - pixel.R % 2;
                g = pixel.G - pixel.G % 2;
                b = pixel.B - pixel.B % 2;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));

                j++;

                pixel = bmp.GetPixel(j, i);

                r = pixel.R - pixel.R % 2;
                g = pixel.G - pixel.G % 2;
                b = pixel.B - pixel.B % 2;
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

                // insertion du texte
                r = 1; g = 0; b = 0;
            beginWhile:
                while (countByte < textB.Length)
                {
                    // MessageBox.Show(generatePseudoRandomNumber().ToString());
                    if (countBit <= 7)
                    {
                        //r8v7b8 r7v8b7 r8v7b si il y a un changement alors next lsb = 0 sinon 1
                        if (r == 1)
                        {
                            if (bmp.GetPixel(j, i).R % 2 != textB[countByte] % 2)
                            {
                                // set the next lsb on 0 <il y a un changement>
                                if (bmp.GetPixel(j, i).G % 2 != 0)
                                {
                                    if (generatePseudoRandomNumber() == 1)
                                    {
                                        if (bmp.GetPixel(j, i).G != 255)
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G + 1, bmp.GetPixel(j, i).B));
                                        }
                                        else
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G - 1, bmp.GetPixel(j, i).B));
                                        }
                                    }
                                    else
                                    {
                                        // le lsb = 1 donc pixel != 0 => ce n'est pas la peine de tester si le pixel != 0 ou non
                                        bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G - 1, bmp.GetPixel(j, i).B));
                                    }

                                }

                            } //end if (bmp.GetP
                            else
                            {   // set the next lsb on 1 <pas de changement>
                                if (bmp.GetPixel(j, i).G % 2 != 1)
                                {
                                    if (generatePseudoRandomNumber() == 1)
                                    {
                                        // le lsb = 0 donc pixel != 255 => ce n'est pas la peine de tester si le pixel != 255 ou non
                                        bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G + 1, bmp.GetPixel(j, i).B));
                                    }
                                    else
                                    {
                                        if (bmp.GetPixel(j, i).G == 0)
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G + 1, bmp.GetPixel(j, i).B));
                                        }
                                        else
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G - 1, bmp.GetPixel(j, i).B));
                                        }
                                    }

                                }
                            } //end else if (bmp.GetP

                            textB[countByte] /= 2;
                            countBit++;
                            r = 0;
                            b = 1;
                            goto beginWhile;
                        }
                        if (b == 1)
                        {
                            if (bmp.GetPixel(j, i).B % 2 != textB[countByte] % 2)
                            {
                                // passer vers le prochain pixel
                                if (j < bmp.Width - 1)
                                {
                                    j++;
                                }
                                else
                                {
                                    if (i < bmp.Height - 1)
                                    {
                                        i++;
                                        j = 0;
                                    }
                                    else
                                    {
                                        return null;
                                    }
                                } // end if(j < bmp.Width-1) // passer vers le prochain pixel

                                // set the next lsb on 0 <il y a un changement>
                                if (bmp.GetPixel(j, i).R % 2 != 0)
                                {
                                    if (generatePseudoRandomNumber() == 1)
                                    {
                                        if (bmp.GetPixel(j, i).R == 255)
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R - 1, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B));
                                        }
                                        else
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R + 1, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B));
                                        }

                                    }
                                    else
                                    {
                                        bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R - 1, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B));
                                    }

                                }//// set the next lsb on 0 <il y a un changement>

                            } //end if (bmp.GetPixel(j, i).B % 2 != textB[countByte] % 2)
                            else
                            {
                                // passer vers le prochain pixel
                                if (j < bmp.Width - 1)
                                {
                                    j++;
                                }
                                else
                                {
                                    // cette verification est en plus car si j = bmp.width - 1 alors on doit incrementer le i sans passer par la verification
                                    if (i < bmp.Height - 1)
                                    {
                                        i++;
                                        j = 0;
                                    }
                                    else
                                    {
                                        return null;
                                    }
                                } // end if(j < bmp.Width-1)
                                // set the next lsb on 1 <pas de changement>
                                if (bmp.GetPixel(j, i).R % 2 != 1)
                                {
                                    if (generatePseudoRandomNumber() == 1)
                                    {
                                        bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R + 1, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B));
                                    }
                                    else
                                    {
                                        if (bmp.GetPixel(j, i).R == 0)
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R + 1, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B));
                                        }
                                        else
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R - 1, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B));
                                        }
                                    }

                                }
                            } //end else if (bmp.GetP
                            textB[countByte] /= 2;
                            countBit++;
                            g = 1;
                            b = 0;
                            goto beginWhile;
                        }
                        if (g == 1)
                        {
                            if (bmp.GetPixel(j, i).G % 2 != textB[countByte] % 2)
                            {
                                // set the next lsb on 0 <il y a un changement>
                                if (bmp.GetPixel(j, i).B % 2 != 0)
                                {
                                    if (generatePseudoRandomNumber() == 1)
                                    {
                                        if (bmp.GetPixel(j, i).B == 255)
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B - 1));
                                        }
                                        else
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B + 1));
                                        }
                                    }
                                    else
                                    {
                                        bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B - 1));
                                    }

                                }

                            } //end if (bmp.GetP
                            else
                            {   // set the next lsb on 1 <pas de changement>
                                if (bmp.GetPixel(j, i).B % 2 != 1)
                                {
                                    if (generatePseudoRandomNumber() == 1)
                                    {
                                        bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B + 1));
                                    }
                                    else
                                    {
                                        if (bmp.GetPixel(j, i).B == 0)
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B + 1));
                                        }
                                        else
                                        {
                                            bmp.SetPixel(j, i, Color.FromArgb(bmp.GetPixel(j, i).R, bmp.GetPixel(j, i).G, bmp.GetPixel(j, i).B - 1));
                                        }
                                    }

                                }
                            } //end else if (bmp.GetP

                            textB[countByte] /= 2;
                            countBit++;
                            r = 1;
                            g = 0;
                            // passer vers le prochain pixel
                            if (j < bmp.Width - 1)
                            {
                                j++;
                            }
                            else
                            {
                                if (i < bmp.Height - 1)
                                {
                                    i++;
                                    j = 0;
                                }
                                else
                                {
                                    return null;
                                }
                            } // end if(j < bmp.Width-1)
                        }

                    } // end if(countBit < 7)
                    else
                    {
                         countBit = 0;
                         countByte++;

                    } // end else if(countBit < 7)   

                } // end while


            }
            return bmp;
            
        }
        //this Method return the number of caracters which can be stored in the image 
        public static int NbCaracStored(Bitmap bmp)
        {
            return (bmp.Width * bmp.Height - 6) * 3 / 16;// 3 pixels pour la taille du text en byte
        }
        public static int generatePseudoRandomNumber()
        {
            int rb = initValue % 2;
            initValue -= initValue % 2;
            
            if (gpsn)
            {
                initValue += 5;
                initValue += (initValue % (int)Math.Pow(31,2) + initValue % (int)Math.Pow(30,2) + initValue % (int)Math.Pow(29,2) + initValue % (int)Math.Pow(27,2) + initValue % (int)Math.Pow(25,2) + initValue % (int)Math.Pow(21,2)) % 2;
                gpsn = false;
            }
            else
            {
                initValue += 4;
                initValue += (initValue % (int)Math.Pow(19,2) + initValue % (int)Math.Pow(15,2) + initValue % (int)Math.Pow(13,2) + initValue % (int)Math.Pow(9,2) + initValue % (int)Math.Pow(3,2) + initValue % (int)Math.Pow(1,2)) % 2;
                gpsn = true;
            }
            return rb;
        }

        public static string extract(Bitmap bmp)
        {
            string text = "";
            Color pixel = bmp.GetPixel(0, 0);
            int countByte = 0, countBit = 0, i = 0, j = 0, taille = 0;

            //on vérifie si l'image respecte les normes prédifinies
            //*1
            if (pixel.R % 2 != 0 || pixel.G % 2 != 0 || pixel.B % 2 != 0)
            {
                if (main.english)
                {
                    MessageBox.Show("This image doesn't contain any message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Cette image ne contient aucun message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return null;
            }
            pixel = bmp.GetPixel(1, 0);
            if (pixel.R % 2 != 0 || pixel.G % 2 != 0 || pixel.B % 2 != 0)
            {
                if (main.english)
                {
                    MessageBox.Show("This image doesn't contain any message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            int facteur = 1, bit = 0;
            int r = 1,
                g = 0,
                b = 0;
           
          beginWhile:
            while (countByte < taille)
            {

                if (countBit < 8)
                {
                    if (r == 1)
                    {
                        bit = bmp.GetPixel(j, i).R % 2;
                        if (bmp.GetPixel(j, i).G % 2 == 0)
                        {
                            // dans ce cas il y a un changement
                            bit = (bit + 1) % 2;
                        }
                        value += (byte)(bit * facteur);
                        countBit++;
                        facteur *= 2;
                        r = 0;
                        b = 1;
                        goto beginWhile;
                    }
                    if (b == 1)
                    {
                        bit = bmp.GetPixel(j, i).B % 2;
                        // passer vers le prochain pixel
                        if (j < bmp.Width - 1)
                        {
                            j++;
                        }
                        else
                        {
                            if (i < bmp.Height - 1)
                            {
                                i++;
                                j = 0;
                            }
                            else
                            {
                                return null;
                            }
                        } // end if(j < bmp.Width-1)

                        if (bmp.GetPixel(j, i).R % 2 == 0)
                        {
                            // dans ce cas il y a un changement
                            bit = (bit + 1) % 2;
                        }
                        value += (byte)(bit * facteur);
                        countBit++;
                        facteur *= 2;
                        b = 0;
                        g = 1;
                        goto beginWhile;
                    }
                    if (g == 1)
                    {
                        bit = bmp.GetPixel(j, i).G % 2;
                        if (bmp.GetPixel(j, i).B % 2 == 0)
                        {
                            // dans ce cas il y a un changement
                            bit = (bit + 1) % 2;
                        }
                        value += (byte)(bit * facteur);
                        countBit++;
                        facteur *= 2;
                        g = 0;
                        r = 1;
                        // passer vers le prochain pixel
                        if (j < bmp.Width - 1)
                        {
                            j++;
                        }
                        else
                        {
                            if (i < bmp.Height - 1)
                            {
                                i++;
                                j = 0;
                            }
                            else
                            {
                                return null;
                            }
                        } // end if(j < bmp.Width-1)
                        goto beginWhile;
                    }
                }
                else
                {
                    textB[countByte] = value;
                    value = 0;
                    countByte++;
                    facteur = 1;
                    countBit = 0;
                }
                 
            }//end while
            text = Encoding.UTF8.GetString(textB);

            return text;
        }

    }
}
