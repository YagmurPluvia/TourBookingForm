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
    public partial class Rezervasyon : Form
    {
        public Rezervasyon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3TH9R0M\\SQLEXPRESS;Initial Catalog=ETurAjentası;Integrated Security=SSPI");
        public int tur;//tur sayfasındaki gönderilen değeri alır
        private void button1_Click(object sender, EventArgs e)//toplam tutar bilgisini bulduk
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TurBilgisi WHERE TurBilgisiID= "+tur+"", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                int birim = Convert.ToInt32(dr["BirimFiyat"]);
               lblTopTutar.Text= (Convert.ToInt32(txtKişiSaysı.Text) * birim).ToString();             
            }
            baglanti.Close();
        }

        private void Rezervasyon_Load(object sender, EventArgs e)
        {
            lblTurID.Text = tur.ToString();
        }

        private void button2_Click(object sender, EventArgs e)//satın al butonuna basıldığında
        {
            baglanti.Open();
            if (baglanti.State == System.Data.ConnectionState.Open) //AnaMüş BİLGİSİ ALINDI
            {
                string query = "insert into AnaMüşteri(Tc,Adı,Soyadı,Cinsiyet,DogumTarihi,TelNo1,Email) values('" + txtTc.Text + "','" + txtAd.Text + "','" + txtSoyad.Text + "','" + comboBox1.Text + "','" + txtDTarih.Text + "','" + txtTel.Text + "','" + txtEmail.Text + "' )";    
                SqlCommand komut = new SqlCommand(query, baglanti);                      
                komut.ExecuteNonQuery();
            }
            baglanti.Close();
            //AnaMüşteri tablsunda kaç kişi olduğunu hesapladık
            SqlCommand bul = new SqlCommand("SELECT COUNT(AnaMüşteriID) as sayı FROM AnaMüşteri ", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = bul.ExecuteReader();
            
            while (dr.Read())
            {
                label9.Text = dr["sayı"].ToString();
            }
            baglanti.Close();

            SqlCommand AnaID = new SqlCommand("SELECT AnaMüşteriID FROM AnaMüşteri where AnaMüşteriID= "+label9.Text+"", baglanti);
            SqlDataReader dr2;
            baglanti.Open();
            dr2 = AnaID.ExecuteReader();
            while (dr2.Read())
            {
                lblAnaID.Text = dr2["AnaMüşteriID"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            if (baglanti.State == System.Data.ConnectionState.Open) //AnaMüş BİLGİSİ ALINDI
            {
                string query = "insert into Rezervasyon(AnaMüşteriID,ToplamTutar,TurBilgisiID) values(@AnaMüş,@topTutar,@turBil)";
                SqlCommand hesapla = new SqlCommand(query, baglanti);
                hesapla.Parameters.AddWithValue("@topTutar", lblTopTutar.Text);
                hesapla.Parameters.AddWithValue("@turBil", lblTurID.Text);
                hesapla.Parameters.AddWithValue("@AnaMüş", lblAnaID.Text);
                hesapla.ExecuteNonQuery();
            }
            baglanti.Close();

            baglanti.Close();//ödeme tablosuna atar
            Ödeme form2sec = new Ödeme();
            form2sec.Show();
            this.Hide();
        }
    }
}
