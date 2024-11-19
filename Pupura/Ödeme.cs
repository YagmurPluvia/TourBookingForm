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
    public partial class Ödeme : Form
    {
        public Ödeme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3TH9R0M\\SQLEXPRESS;Initial Catalog=ETurAjentası;Integrated Security=SSPI");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ödeme_Load(object sender, EventArgs e)//rezervasyon tablosundan turbilgi ve toplam tutarı alip labellere yazdırdık
        {
            SqlCommand komut = new SqlCommand("select * from  Rezervasyon ", baglanti);
            //select * from  TurBilgisi ıner join TurÇeşidi on TurBilgisi.TurÇeşidiID = TurÇeşidi.TurÇeşidiID

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label1.Text = dr["TurBilgisiID"].ToString();
                label2.Text = dr["ToplamTutar"].ToString();
                label6.Text = dr["AnaMüşteriID"].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)//son rezervasyon ıd sini bulduk
        {

            SqlCommand bul = new SqlCommand("SELECT COUNT(RezarvasyonID) as sayı FROM Rezervasyon ", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = bul.ExecuteReader();

            while (dr.Read())
            {
                label9.Text = dr["sayı"].ToString();
            }
            baglanti.Close();

            SqlCommand AnaID = new SqlCommand("SELECT RezarvasyonID FROM Rezervasyon where RezarvasyonID= " + label9.Text + "", baglanti);
            SqlDataReader dr2;
            baglanti.Open();
            dr2 = AnaID.ExecuteReader();
            while (dr2.Read())
            {
                label3.Text = dr2["RezarvasyonID"].ToString();

            }
            baglanti.Close();

            baglanti.Open();
            if (baglanti.State == System.Data.ConnectionState.Open) //Ödeme tablosuna girilen bilgileri yazdırdık
            {
                string query = "insert into Ödeme(AnaMüşteriID,RezervasyonID,ToplamTutar,ÖdemeTarihi,ÖdemeŞekli) values(@AnaMüş,@Rezer,@topTutar,getdate(),@ÖdemŞ)";
                SqlCommand hesapla = new SqlCommand(query, baglanti);
                hesapla.Parameters.AddWithValue("@AnaMüş", label6.Text);
                hesapla.Parameters.AddWithValue("@Rezer", label3.Text);
                hesapla.Parameters.AddWithValue("@topTutar", label2.Text);
                hesapla.Parameters.AddWithValue("@ÖdemŞ", comboBox2.SelectedItem.ToString());
                hesapla.ExecuteNonQuery();
            }
            MessageBox.Show("Ödemeniz başarıyla gerçekleşmiştir");
        }
    }
}
