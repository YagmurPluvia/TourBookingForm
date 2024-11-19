using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pupura
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3TH9R0M\\SQLEXPRESS;Initial Catalog=ETurAjentası;Integrated Security=SSPI");
 
        private void Form1_Load(object sender, EventArgs e)//combobox ın içine tur çeşidlerini atadık
        {
           
            SqlCommand komut = new SqlCommand("SELECT Tür FROM TurÇeşidi ",baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Tür"]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//turlar sayfasına geçmemize olanak sağlar
        {
            {
                Turlar form2sec = new Turlar();
                form2sec.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)//comboboxtan gelen bilgiye göre tur sayfasına bilgi atıyor
        {
            String seçilen = comboBox1.SelectedItem.ToString();
            if (seçilen.ToString() == "DoğuAnadolu")
            {
                Tur frm = new Tur();
                frm.sayı = 1;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "DoğuExpres")
            {
                Tur frm = new Tur();
                frm.sayı = 2;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "Gap")
            {
                Tur frm = new Tur();
                frm.sayı = 3;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "DoğuKardeniz")
            {
                Tur frm = new Tur();
                frm.sayı = 4;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "Kayak")
            {
                Tur frm = new Tur();
                frm.sayı = 5;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "Bodrum")
            {
                Tur frm = new Tur();
                frm.sayı = 6;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "İstanbul")
            {
                Tur frm = new Tur();
                frm.sayı = 7;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "Kapadokya")
            {
                Tur frm = new Tur();
                frm.sayı = 8;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "Marmaris")
            {
                Tur frm = new Tur();
                frm.sayı = 9;
                frm.ShowDialog();
            }
            if (seçilen.ToString() == "Olympos")
            {
                Tur frm = new Tur();
                frm.sayı = 10;
                frm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)//yönetici sayfasına atar
        {
            Admin form2sec = new Admin();
            form2sec.Show();
            this.Hide();
        }
    }
}
