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
    public partial class Password : Form
    {
        public static bool cancel_ = false;
        public event Action<string> password;

        public Password()
        {
            InitializeComponent();
            if (!main.english)
            {
                cancel.Text = "Annuler";
                info.Left = 4;
                info.Text = "Mot de Passe";
                note.Text = "Votre mot de passe doit être >= 8 chars";
            }
            
        }
        
        private void ok_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            cancel_ = false;

            if (text.Length < 8)
            {
                textBox.Text = "";
                note.ForeColor = Color.Red;
            }
            else
            {
                if (this.password != null) this.password(textBox.Text);
                this.Close();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            cancel_ = true;
            this.Close();
        }

       
    }
}
