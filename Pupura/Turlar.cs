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
using System.IO;

namespace Pupura
{
    public partial class Turlar : Form
    {
        public Turlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3TH9R0M\\SQLEXPRESS;Initial Catalog=ETurAjentası;Integrated Security=SSPI");

      
        private void Turlar_Load(object sender, EventArgs e)//labellere ve picturbox lara sql den sıra ile bilgilerini yerleştirdik
        {
            PictureBox[] picture = new PictureBox[] { pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5};
            for (int i = 1; i <= picture.Length; i++)
            {
                SqlCommand komutresim = new SqlCommand("Select Resim from TurBilgisi where TurBilgisiID="+i+"", baglanti);
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter(komutresim);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Resim"]);
                    picture[i-1].Image = new Bitmap(ms);
                }
                baglanti.Close();
            }

            Label[] labels = new Label[]{ l1, l2, l3, l4,l5};
            Label[] labelss = new Label[]{ labell1, labell2, labell3, labell4,labell5};
            
            for (int i = 1; i <= labels.Length; i++)
            {
                SqlCommand komut = new SqlCommand("SELECT * FROM TurÇeşidi WHERE TurÇeşidiID= " + i + "", baglanti);
                SqlDataReader dr;
                baglanti.Open();
                dr = komut.ExecuteReader();


                while (dr.Read())
                {
                    labels[i-1].Text = dr["Tür"].ToString();
                    labelss[i-1].Text = dr["RehberID"].ToString();
                }
                baglanti.Close();
            }
        }



        private void button1_Click(object sender, EventArgs e)//geri butonu
        {
            {
                AnaSayfa form2sec = new AnaSayfa();
                form2sec.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)//turun bilgisine bağlı olarak tur sayfasına gereken bilgiyi göndererk tur sayfasını açarız
        {
            Tur frm = new Tur();
            frm.sayı = 1;
            frm.ShowDialog();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Tur frm = new Tur();
            frm.sayı = 2;
            frm.ShowDialog();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            Tur frm = new Tur();
            frm.sayı = 3;
            frm.ShowDialog();
        }

        private void b4_Click(object sender, EventArgs e)
        {
            Tur frm = new Tur();
            frm.sayı = 4;
            frm.ShowDialog();
        }

        private void b5_Click(object sender, EventArgs e)
        {
            Tur frm = new Tur();
            frm.sayı = 5;
            frm.ShowDialog();
        }
    }
}
