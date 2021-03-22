using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Steganography
{
    public partial class main : Form
    {
        public static bool english = true;
        //
        private Bitmap bmp = null, bmp_ = null; // l'image originale bmp || l'image stego bmp_
        private string ImagefileName = "";
        private string filepath = "";
        private string text = "";
        private string content_t = "";
        private byte[] content_b = null;
        private string password = "";
        
        public main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }


        private void button_Hide(object sender, EventArgs e)
        {
            if (MethodChoice.SelectedIndex == -1) // tester si une méthode est choisie
            {
                if (english) { MessageBox.Show("Please: Choose the method! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else { MessageBox.Show("SVP: Choisir une méthode! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                return; 
            }

            if (bmp != null) // tester si l'image est choisie
            {
                if (radioChoice_t.Checked) // dans le cas de texte
                {
                    text = textBox1.Text; 

                    if (text.Equals("")) // tester si le message texte n'est pas vide
                    {
                        if(english)
                        {
                            MessageBox.Show("The text you want to hide can't be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Le text que vous êtes en train d'insérer ne peut pas être vide", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        

                        return;
                    }
                    else
                    {
                        // la boite de dialogue du cryptage
                        DialogResult dialogueResult = new DialogResult();
                        if (english)
                        {
                            dialogueResult = MessageBox.Show("do you want to crypt your message?", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        else
                        {
                            dialogueResult = MessageBox.Show("Voulez vous crypter votre message?", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        // récupération du password et cryptage
                        if ( dialogueResult == DialogResult.Yes)
                        {
                            Password p = new Password();
                            p.password += this.GetString;
                            p.ShowDialog();
                            if (Password.cancel_) { return; }   
                            text = Crypto.EncryptStringAES(text, password);
                                
                                

                        }//end  if(MessageBox
                        
                        // mettre le curseur à l'état AppStarting - en attend -
                        this.Cursor = System.Windows.Forms.Cursors.AppStarting;

                        // insérer le message texte selon la méthode choisie
                        if (MethodChoice.SelectedIndex == 1)
                        {

                            bmp_ = H_EText.hide(text, ImagefileName);
                            
                        }
                        else
                        {
                            // 255 est juste pour le random generator
                            
                            bmp_ = M_Text.embed(text, ImagefileName, 255);
                            
                        }

                        // remettre le curseur à l'état par défaut
                        this.Cursor = System.Windows.Forms.Cursors.Arrow;

                        // tester si l'image apres le processus d'insertion est n'est pas prête
                        if (bmp_ == null) { return; }

                        // procédure d'enregistrement
                        try
                        {
                            SaveFileDialog save_dialog = new SaveFileDialog();
                            save_dialog.Filter = "Png Image|*.png|Bitmap Image|*.bmp";

                            if (save_dialog.ShowDialog() == DialogResult.OK)
                            {
                                switch (save_dialog.FilterIndex)
                                {
                                    case 1:
                                        {
                                            bmp_.Save(save_dialog.FileName, ImageFormat.Png);
                                            if (english)
                                            {
                                                MessageBox.Show("Your message was hidden in the image successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                            }
                                            else
                                            {
                                                MessageBox.Show("votre message a été inséré dans l'image avec succès", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                            }
                                            
                                        } break;
                                    case 2:
                                        {
                                            bmp_.Save(save_dialog.FileName, ImageFormat.Bmp);
                                            if (english)
                                            {
                                                MessageBox.Show("Your message was hidden in the image successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                            }
                                            else
                                            {
                                                MessageBox.Show("votre message a été inséré dans l'image avec succès", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                            }
                                            
                                        } break;
                                }
                                // affichage du psnr après l'enregistrement d'image stégo
                                form_psnr ps = new form_psnr();


                                ps.Show();
                                ps.Calcul(bmp, bmp_);
                                
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }

                    }//if (text.Equal
                }//if (radio
                else if (radioChoice_d.Checked) // dans le cas où le message est n'est pas un texte
                {
                    // tester si le file est bien choisi
                    if (filepath.Equals(""))
                    {
                        if (english)
                        {
                            MessageBox.Show("The file you want to hide should be specified", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Vous devez spécifié le fichier que vous voulez inclure!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                        return;
                    }
                    else
                    {
                        // mettre le fichier en mémoire
                        byte[] contents = File.ReadAllBytes(filepath);

                        /* (o|n) cryptage */
                        DialogResult dialogueResult = new DialogResult();
                        if (main.english)
                        {
                            dialogueResult = MessageBox.Show("do you want to crypt your message?", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        else
                        {
                            dialogueResult = MessageBox.Show("Voulez vous crypter votre message?", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }

                        // récupérer le password et crypter le fichier
                        if (dialogueResult == DialogResult.Yes)
                        {

                            string fichier = Encoding.UTF8.GetString(contents);

                            Password p = new Password();
                            p.password += this.GetString;
                            p.ShowDialog();
                            if (Password.cancel_) { return; }
                            fichier = Crypto.EncryptStringAES(fichier, password);
                            
                            contents = Encoding.UTF8.GetBytes(fichier);

                        }//end if (dialogueResult ==

                        // mettre le curseur à l'état de AppStarting - en attente -
                        this.Cursor = System.Windows.Forms.Cursors.AppStarting;
                        // insérer le fichier selon la méthode choisie
                            if (MethodChoice.SelectedIndex == 1)
                            {

                                bmp_ = H_EDocument.hide(contents, ImagefileName);
                                
                            }
                            else
                            {

                                bmp_ = M_Document.hide(contents, ImagefileName, 555);
                                
                            }
                            // remettre le curseur à l'état par défaut
                            this.Cursor = System.Windows.Forms.Cursors.Arrow;
                            // engistrement de l'image stégo
                            try
                            {
                                if (bmp_ == null) { return; }
                                SaveFileDialog save_dialog = new SaveFileDialog();
                                save_dialog.Filter = "Png Image(*.png)|*.png|Bitmap Image (*.bmp)|*.bmp";

                                if (save_dialog.ShowDialog() == DialogResult.OK)
                                {
                                    switch (save_dialog.FilterIndex)
                                    {
                                        case 1:
                                            {
                                                bmp_.Save(save_dialog.FileName, ImageFormat.Png);
                                                if (english)
                                                {
                                                    MessageBox.Show("Your message was hidden in the image successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("votre message a été inséré dans l'image avec succès", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                                }
                                                
                                            } break;
                                        case 2:
                                            {
                                                bmp_.Save(save_dialog.FileName, ImageFormat.Bmp);
                                                if (english)
                                                {
                                                    MessageBox.Show("Your message was hidden in the image successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("votre message a été inséré dans l'image avec succès", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                                }
                                            } break;
                                    }// end switch
                                    // l'affichage du psnr après l'enregistrement
                                    form_psnr ps = new form_psnr();
                                    
                                    
                                    ps.Show();
                                    ps.Calcul(bmp, bmp_);

                                }//end if (save_dialog

                            }//end try
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        
                    }//end else --> if(filepath
                }//end else if (radioChoice_d
                else
                {
                    if (english)
                    {
                        MessageBox.Show("You must choose the type of your message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Veuillez choisir le type de votre message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }



            }//end if (bmp!=null
            else
            {
                if (english)
                {
                    MessageBox.Show("Choose an image please!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Choisir une image svp!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }

        }



       

        private void button_Extract(object sender, EventArgs e)
        {
            // tester si une méthode est choisie
            if (MethodChoice.SelectedIndex == -1) 
            {
                if (english)
                {
                    MessageBox.Show("Please: Choose the method! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                }
                else
                {
                    MessageBox.Show("Veillez choisir une méthode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                }
                
                return; 
            
            }
            // tester si l'image est choisie
            if (bmp != null)
            {
                // tester si le message inséré est de type texte
                if (radioChoice_t.Checked)
                {
                    // mettre le curseur à l'état AppStarting - en attente -
                    this.Cursor = System.Windows.Forms.Cursors.AppStarting;

                    // extraire le message inséré
                    if (MethodChoice.SelectedIndex == 1)
                    {
                        
                        content_t = H_EText.extract(bmp);
                        
                    }
                    else
                    {
                        
                        content_t = M_Text.extract(bmp);
                        
                    }

                    // remettre le curseur à l'état par défaut
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;

                    // arrêter la procedure lorsqu'il n'y pas de message dans l'image
                    if (content_t == "") { return; }

                    // tester si le message est chiffrer ou non
                    DialogResult dialogueResult = new DialogResult();
                    if (english)
                    {
                        dialogueResult = MessageBox.Show("are your message crypted or not?", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                    {
                        dialogueResult = MessageBox.Show("est-ce que votre message crypté ou non?", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    // demander le password et décrypter le message après l'extraction
                    if (dialogueResult == DialogResult.Yes)
                    {
                        password = "";
                        Password p = new Password();
                        p.password += this.GetString;
                        p.ShowDialog();
                        if (Password.cancel_) { return; }

                        try
                        {
                            content_t = Crypto.DecryptStringAES(content_t, password);
                        }
                        catch (Exception ex)
                        {
                            string exception = ex.ToString();
                            if (english)
                            {
                                MessageBox.Show("Wrong password");
                            }
                            else
                            {
                                MessageBox.Show("mot de passe invalide");
                            }
                            return;
                        }
                    }
                   // afficher le message texte
                    textBox1.Text = content_t;
                    

                }
                else if (radioChoice_d.Checked) // tester si le message est de type fichier
                {
                    // mettre le curseur à l'état AppStarting - en attente -
                    this.Cursor = System.Windows.Forms.Cursors.AppStarting;

                    // extraire le message selon la méthode choisie
                    if (MethodChoice.SelectedIndex == 1)
                    {
                        
                        content_b = H_EDocument.extract(bmp);
                        
                    }
                    else
                    {
                        
                        content_b = M_Document.extract(bmp);
                       
                    }
                    // remettre le curseur à l'état par défaut
                    this.Cursor = System.Windows.Forms.Cursors.Arrow;


                    // demander si le message est crypter
                    DialogResult dialogueResult = new DialogResult();

                    if (english)
                    {
                        dialogueResult = MessageBox.Show("are your message crypted or not?", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                    {
                        dialogueResult = MessageBox.Show("est-ce que votre message crypté ou non?", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    // demander le password et décrypter le message
                    if (dialogueResult == DialogResult.Yes)
                    {
                        password = "";
                        Password p = new Password();
                        p.password += this.GetString;
                        p.ShowDialog();
                        if (Password.cancel_) { return; }
                        string text = Encoding.UTF8.GetString(content_b);

                        try
                        {
                            text = Crypto.DecryptStringAES(text, password);
                        }
                        catch (Exception ex)
                        {
                            string exception = ex.ToString();
                            if (english)
                            {
                                MessageBox.Show("Wrong password");
                            }
                            else
                            {
                                MessageBox.Show("mot de passe invalide");
                            }


                            return;
                        }

                        content_b = Encoding.UTF8.GetBytes(text);
                    }

                    // sauvegarde du document extrait
                    if (content_b != null)
                    {
                        SaveFileDialog save_dialog = new SaveFileDialog();
                        save_dialog.Filter = "File(*.*)|(*.*)";//"Text File (*.txt)|*.txt | Word File (*.docx)|*.docx | Image File (*.png)|*.png | Image File (*.bmp)|*.bmp";

                        if (save_dialog.ShowDialog() == DialogResult.OK)
                        {
                            switch (save_dialog.FilterIndex)
                            {
                                case 1:
                                    {
                                        File.WriteAllBytes(save_dialog.FileName, content_b);
                                        if (english)
                                        {
                                            MessageBox.Show("successfull operation!", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                        }
                                        else
                                        {
                                            MessageBox.Show("l'opération est effectuée avec succès", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                                        }
                                        
                                    } break;
                                
                            }// end switch

                        }//end if (save_dialog

                    }//end if (content

                }
                else
                {
                    if (english)
                    {
                        MessageBox.Show("You must choose the type of your message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Veuillez choisir le type de votre message!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if (english)
                {
                    MessageBox.Show("Choose an image please!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Choisir une image svp!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button_OpenFile(object sender, EventArgs e)
        {
            if (radioChoice_d.Checked)
            {
                OpenFileDialog open_dialog = new OpenFileDialog();
                open_dialog.Filter = "File(*.*)|*.*";

                if (open_dialog.ShowDialog() == DialogResult.OK)
                {
                    
                    filepath = open_dialog.FileName;
                    filepathbutton.Text = filepath;
                    
                }
            }
            else
            {
                if (english)
                {
                    MessageBox.Show("Choose the file choice firstly!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Choisir le choix de fichier en premier!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void radioChoice_t_CheckedChanged(object sender, EventArgs e)
        {
            if (radioChoice_t.Checked)
            {
                textBox1.ReadOnly = false;
            }
            else
            {
                textBox1.ReadOnly = true;
            }
        }

        private void GetString(string s)
        {
            password = s;
        }



        private void pSNRToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.png; *.jpg;  *.bmp)|*.png; *.jpg; *.bmp;";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                Imagepath.Text = open_dialog.FileName;
                ImagefileName = open_dialog.FileName;

                bmp = (Bitmap)Image.FromFile(open_dialog.FileName);

                image.Image = Image.FromFile(open_dialog.FileName);

                notification.Text = "Note :\n";

                if (MethodChoice.SelectedIndex == 1)
                {

                    if (english)
                    {
                        notification.Text += "\nYour message must be less than : " + H_EText.NbCaracStored(bmp).ToString() + " characters(bytes)";
                    }
                    else
                    {
                        notification.Text += "\nLa taille de votre doit être inférieur à : " + H_EText.NbCaracStored(bmp).ToString() + " caractères(octets)";
                    }
                }
                else if (MethodChoice.SelectedIndex == 0)
                {
                    if (english)
                    {
                        notification.Text += "\nYour message must be less than : " + M_Text.NbCaracStored(bmp).ToString() + "Characters(bytes)";
                    }
                    else
                    {
                        notification.Text += "\nLa taille de votre message doit être inférieur à : " + M_Text.NbCaracStored(bmp).ToString() + "caractères(octets)";
                    }
                }
            }

        }



        private void pSNRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form_psnr ps = new form_psnr();
            ps.ShowDialog();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            english = true;
            method.Text = "Method used :";

            int index = -1;
            if (MethodChoice.SelectedIndex == 0)
            {
                index = 0;
            }
            else
            {
                index = 1;
            }
            this.MethodChoice.Items.Clear();
            this.MethodChoice.Items.AddRange(new object[] {
            "LSB Matching",
            "LSB Replacement"});
            this.MethodChoice.SelectedIndex = index;
            method.Left = 209;
            englishToolStripMenuItem.Text = "&English";
            frenchToolStripMenuItem.Text = "&French";
            LanguageToolStripMenuItem1.Text = "&Language";
            helpToolStripMenuItem2.Text = "&Help";
            aboutToolStripMenuItem.Text = "&About";
            //howToUseApplicationToolStripMenuItem.Text = "&How to use this application";
            helpToolStripMenuItem.Text = "&Evaluate";
            //pSNRToolStripMenuItem1.Text = "PSNR";
            optionToolStripMenuItem.Text = "&File";
            exitToolStripMenuItem.Text = "&Exit";
            OpenImageToolStripMenuItem.Text = "&Open image";
            imagePathText.Text = "Image Path :";
            le_type.Text = "The type of your message :";
            radioChoice_t.Text = "text";
            radioChoice_d.Text = "file";
            messageText.Text = "Write your message here :";
            OpenFile.Text = "Open File";
            OpenFile.Width = 71;
            filePathtext.Text = "File Path :";
            buttonHide.Text = "Hide";
            buttonExtract.Text = "Extract";
            notification.Text = "Note :";
            this.Text = "Steganography";
            image.BackgroundImage = global::Steganography.Properties.Resources.mainChoose;

        }

        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            english = false;
            method.Text = "Méthode utilisé :";
            int index = -1;
            if (MethodChoice.SelectedIndex == 0)
            {
                index = 0;
            }
            else
            {
                index = 1;
            }
            this.MethodChoice.Items.Clear();
            this.MethodChoice.Items.AddRange(new object[] {
            "LSB par correspondance",
            "LSB remplacement"});
            if (index == 0)
            {
                this.MethodChoice.SelectedItem = "LSB par correspondance";
            }
            else if(index == 1){
                this.MethodChoice.SelectedItem = "LSB remplacement";
            }
            
            method.Left = 195;
            exitToolStripMenuItem.Text = "&Fermer";
            englishToolStripMenuItem.Text = "&Anglais";
            frenchToolStripMenuItem.Text = "&Français";
            LanguageToolStripMenuItem1.Text = "&Langue";
            helpToolStripMenuItem2.Text = "&Aide";
            aboutToolStripMenuItem.Text = "&A propos";
            //howToUseApplicationToolStripMenuItem.Text = "&Comment utilisé cette application";
            helpToolStripMenuItem.Text = "&Evaluer";
            //pSNRToolStripMenuItem1.Text = "PSNR";
            optionToolStripMenuItem.Text = "&Fichier";
            OpenImageToolStripMenuItem.Text = "&Ouvrir image";
            imagePathText.Text = "Chemin d'Image :";
            le_type.Text = "Le type de votre message :";
            radioChoice_t.Text = "texte";
            radioChoice_d.Text = "fichier";
            messageText.Text = "Ecrire votre message ici :";
            OpenFile.Text = "Ouvrir Fichier";
            OpenFile.Width = 100;
            filePathtext.Text = "Chemin de Fichier :";
            buttonHide.Text = "Insérer";
            buttonExtract.Text = "Extraire";
            notification.Text = "Note :";
            this.Text = "Stéganographie";
            image.BackgroundImage = global::Steganography.Properties.Resources.mainChoisir;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void image_Click(object sender, EventArgs e)
        {

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files (*.png; *.jpg;  *.bmp)|*.png; *.jpg; *.bmp;";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                Imagepath.Text = open_dialog.FileName;
                ImagefileName = open_dialog.FileName;

                bmp = (Bitmap)Image.FromFile(open_dialog.FileName);

                image.Image = Image.FromFile(open_dialog.FileName);

                notification.Text = "Note :\n";

                if (MethodChoice.SelectedIndex == 1)
                {

                    if (english)
                    {
                        notification.Text += "\nYour message must be less than : " + H_EText.NbCaracStored(bmp).ToString() + " characters(bytes)";
                    }
                    else
                    {
                        notification.Text += "\nLa taille de votre doit être inférieur à : " + H_EText.NbCaracStored(bmp).ToString() + " caractères(octets)";
                    }
                }
                else if (MethodChoice.SelectedIndex == 0)
                {
                    if (english)
                    {
                        notification.Text += "\nYour message must be less than : " + M_Text.NbCaracStored(bmp).ToString() + "Characters(bytes)";
                    }
                    else
                    {
                        notification.Text += "\nLa taille de votre message doit être inférieur à : " + M_Text.NbCaracStored(bmp).ToString() + "caractères(octets)";
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }


        private void MethodChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                notification.Text = "Note :\n";
                if (MethodChoice.SelectedIndex == 1)
                {
                    if (english)
                    {
                        notification.Text += "\nYour message must be less than : " + H_EText.NbCaracStored(bmp).ToString() + " characters(bytes)";
                    }
                    else
                    {
                        notification.Text += "\nLa taille de votre message doit être inférieur à : " + H_EText.NbCaracStored(bmp).ToString() + " caractères(octets)";
                    }

                }
                else if (MethodChoice.SelectedIndex == 0)
                {
                    if (english)
                    {
                        notification.Text += "\nYour message must be less than : " + M_Text.NbCaracStored(bmp).ToString() + " characters(bytes)";
                    }
                    else
                    {
                        notification.Text += "\nLa taille de votre message doit être inférieur à : " + M_Text.NbCaracStored(bmp).ToString() + " caractères(octets)";
                    }

                }
            }
        }
    }
}

