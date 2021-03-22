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
    class M_Document
    {
        
        public static Bitmap hide(byte[] contents, string fileName, int initialValue)
        {
            int r = 0, g = 0, b = 0;

            Bitmap bmp = (Bitmap)Image.FromFile(fileName);
            if (contents.Length > NbByteStored(bmp))
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
                int countByte = 0, countBit = 0, i = 0, j = 0, taille = contents.Length;

                //insertion de 11 * 2pixels + taille du document en 4pixels(3bytes)
                /* **** 1 **** */
                r = pixel.R - pixel.R % 2 + 1;
                g = pixel.G - pixel.G % 2 + 1;
                b = pixel.B - pixel.B % 2 + 1;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));

                j++;
                pixel = bmp.GetPixel(j, i);

                r = pixel.R - pixel.R % 2 + 1;
                g = pixel.G - pixel.G % 2 + 1;
                b = pixel.B - pixel.B % 2 + 1;
                bmp.SetPixel(j, i, Color.FromArgb(r, g, b));

                j++;
                pixel = bmp.GetPixel(j, i);

                /* **** 2 **** */

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
                // insertion du message
                r = 1; g = 0; b = 0;
            beginWhile:
                while (countByte < contents.Length)
                {
                    // MessageBox.Show(generatePseudoRandomNumber().ToString());
                    if (countBit < 8)
                    {
                        //r8v7b8 r7v8b7 r8v7b si il y a un changement alors next lsb = 0 sinon 1
                        if (r == 1)
                        {
                            if (bmp.GetPixel(j, i).R % 2 != contents[countByte] % 2)
                            {
                                // set the next lsb on 0 <il y a un changement>
                                if (bmp.GetPixel(j, i).G % 2 != 0)
                                {
                                    if (M_Text.generatePseudoRandomNumber() == 1) // incrementation
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
                                    if (M_Text.generatePseudoRandomNumber() == 1)
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

                            contents[countByte] /= 2;
                            countBit++;
                            r = 0;
                            b = 1;
                            goto beginWhile;
                        }
                        if (b == 1)
                        {
                            if (bmp.GetPixel(j, i).B % 2 != contents[countByte] % 2)
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
                                    if (M_Text.generatePseudoRandomNumber() == 1)
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
                                    if (M_Text.generatePseudoRandomNumber() == 1)
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
                            contents[countByte] /= 2;
                            countBit++;
                            g = 1;
                            b = 0;
                            goto beginWhile;
                        }
                        if (g == 1)
                        {
                            if (bmp.GetPixel(j, i).G % 2 != contents[countByte] % 2)
                            {
                                // set the next lsb on 0 <il y a un changement>
                                if (bmp.GetPixel(j, i).B % 2 != 0)
                                {
                                    if (M_Text.generatePseudoRandomNumber() == 1)
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
                                    if (M_Text.generatePseudoRandomNumber() == 1)
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

                            contents[countByte] /= 2;
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
        public static int NbByteStored(Bitmap bmp)
        {
            return (bmp.Width * bmp.Height - 6) * 3 / 16;// 4 pixels pour la taille du document en byte(3bytes) & 2 pixels refer to a document 
        }

        public static byte[] extract(Bitmap bmp)
        {
            Color pixel = bmp.GetPixel(0, 0);
            int countByte = 0, countBit = 0, i = 0, j = 0, taille = 0, r, g, b;


            //on vérifie si l'image respecte les normes prédifinies
            //*1
            if (pixel.R % 2 != 1 || pixel.G % 2 != 1 || pixel.B % 2 != 1)
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
            pixel = bmp.GetPixel(1, 0);
            if (pixel.R % 2 != 1 || pixel.G % 2 != 1 || pixel.B % 2 != 1)
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

            byte[] contents = new Byte[taille];
            byte value = 0;
            int facteur = 1, bit = 0;
            r = 1;
            g = 0;
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
                    contents[countByte] = value;
                    value = 0;
                    countByte++;
                    facteur = 1;
                    countBit = 0;
                }

            }//end while

            return contents;
        }
    }
}
