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
    public partial class Tur : Form
    {
        public Tur()
        {
            InitializeComponent();
        }
        
        public int sayı;//turlar sayfasından ve ana sayfada gönderilen değer

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3TH9R0M\\SQLEXPRESS;Initial Catalog=ETurAjentası;Integrated Security=SSPI");
        private void Tur_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from  TurBilgisi  WHERE TurÇeşidiID= " + sayı + "", baglanti);

            //select * from  TurBilgisi ıner join TurÇeşidi on TurBilgisi.TurÇeşidiID = TurÇeşidi.TurÇeşidiID

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblTür.Text = dr["TurÇeşidiID"].ToString();
                lblKonum.Text = dr["Konum"].ToString();
                lblFiyat.Text = dr["BirimFiyat"].ToString();
                lblDetaylar.Text = uzunluklimitle(dr["Detay"].ToString());
                lblTarih.Text = dr["Tarih"].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)//geri tuşu
        {
            Turlar form2sec = new Turlar();
            form2sec.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTür_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//satın al tuşuna basıldığında rezervasyon sayfasına atar
        {
            Rezervasyon frm = new Rezervasyon();
            frm.tur = Convert.ToInt32(lblTür.Text);
            frm.ShowDialog();
        }

        private void lblDetaylar_Click(object sender, EventArgs e)
        {

        }

        public string uzunluklimitle(string text)//detayın uzunluğuna göre alt satıra geçmesini sağladık
        {
            int firstindex = 0;
            int maxlenght = 50;
            string newtext = null;
            while (firstindex + maxlenght < text.Length)
            {
                newtext += text.Substring(firstindex, maxlenght) + "\r\n";
                firstindex += maxlenght;
            }
            return newtext;
        }
    }
}
