using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pupura
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            
        }
        String ad = "Purpura";
        String şifre = "İRDU";
        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Pink;
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)//isim ve şifreyi kontrol ederek tur ekle sil sayfasına attık
        {

            if (textBox1.Text == ad && textBox2.Text == şifre)
            {
                TurEkleSil form2sec = new TurEkleSil();
                form2sec.Show();
                this.Hide();
            }
            else
            {
                label3.Text = "İsmini veya şifreniz hatalı!";
            }
        }
    }
}
