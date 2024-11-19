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
    public partial class TurEkleSil : Form
    {
        public TurEkleSil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3TH9R0M\\SQLEXPRESS;Initial Catalog=ETurAjentası;Integrated Security=SSPI");
        SqlCommand komut;
        SqlDataAdapter da;

       public void turÇek()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select *from TurBilgisi",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }
        public void turÇeşÇek()
        {
            baglanti.Open();
            da = new SqlDataAdapter("select *from TurÇeşidi", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void TurEkleSil_Load(object sender, EventArgs e)
        {
            //turbilgisi();
            turÇek();
            turÇeşÇek();

        }

        private void btnturb_Click(object sender, EventArgs e)//tur bilgisi tablosuna ekleme yapmak
        {
            FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            byte[] resim = binaryReader.ReadBytes((int)fileStream.Length);
            binaryReader.Close();
            fileStream.Close();

            string sorgu = "insert into TurBilgisi(TurÇeşidiID,BirimFiyat,Konum,Resim,Tarih,Detay) values (@TurÇeşidiID,@BirimFiyat,@Konum,@image,@Tarih,@Detay)";
            komut = new SqlCommand(sorgu, baglanti);
            
          //  komut.Parameters.AddWithValue("@TurBilgisiID", textBox5.Text);
            komut.Parameters.AddWithValue("@TurÇeşidiID", textBox1.Text);
            komut.Parameters.AddWithValue("@BirimFiyat", textBox2.Text);
            komut.Parameters.AddWithValue("@Konum", textBox3.Text);
            komut.Parameters.Add("@image", SqlDbType.Image, resim.Length).Value = resim;
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@Detay", textBox4.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();//sql e yazmak için
            baglanti.Close();
            turÇek();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)//sql deki turBilgisi tablosunu yazdırma
        {
            textBox5.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
           // textBox4.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void btntursil_Click(object sender, EventArgs e)//TurBilgisi silme işlemi
        {
            string sorgu = "delete from TurBilgisi where TurBilgisiID=@id";
            komut = new SqlCommand(sorgu,baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox5.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            turÇek();
        }

        private void btnturdegistir_Click(object sender, EventArgs e)//TurBilgisi tbalosunu güncelleme
        {


            string sorgu = "update TurBilgisi set TurÇeşidiID=@TurÇeşidiID,BirimFiyat=@BirimFiyat,Konum=@Konum,Tarih=@Tarih,Detay=@Detay where TurBilgisiID=@id ";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox5.Text));
            komut.Parameters.AddWithValue("@TurÇeşidiID", textBox1.Text);
            komut.Parameters.AddWithValue("@BirimFiyat", textBox2.Text);
            komut.Parameters.AddWithValue("@Konum", textBox3.Text);
            komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@Detay", textBox4.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            turÇek();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)//sql deki turÇeşidi tablosunu yazdırma
        {
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();         
            textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)//tur çeşidi tablosuna ekleme yapmak
        {
            string sorgu = "insert into TurÇeşidi(Tür,OtelBilgiID,UlaşımID,RehberID) values (@Tür,@OtelBilgiID,@UlaşımID,@RehberID)";
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@Tür", textBox10.Text);
            komut.Parameters.AddWithValue("@OtelBilgiID", textBox9.Text);
            komut.Parameters.AddWithValue("@UlaşımID", textBox8.Text);
            komut.Parameters.AddWithValue("@RehberID", textBox7.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();//sql e yazmak için
            baglanti.Close();
            turÇeşÇek();
        }

        private void button2_Click(object sender, EventArgs e)//TurÇeşidi silme işlemi
        {
            string sorgu = "delete from TurÇeşidi where TurÇeşidiID=@çid";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@çid", Convert.ToInt32(textBox6.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            turÇeşÇek();
        }

        private void button1_Click(object sender, EventArgs e)//TurÇeşidi tbalosunu güncelleme
        {
            string sorgu = "update TurÇeşidi set Tür=@Tür,OtelBilgiID=@OtelBilgiID,UlaşımID=@UlaşımID,RehberID=@RehberID where TurÇeşidiID=@çid ";
            komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@çid", Convert.ToInt32(textBox6.Text));
            komut.Parameters.AddWithValue("@Tür", textBox10.Text);
            komut.Parameters.AddWithValue("@OtelBilgiID", textBox9.Text);
            komut.Parameters.AddWithValue("@UlaşımID", textBox8.Text);
            komut.Parameters.AddWithValue("@RehberID", textBox7.Text);


            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            turÇeşÇek();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa form2sec = new AnaSayfa();
            form2sec.Show();
            this.Hide();
        }
        string imagepath;
        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = "Jpeg dosyaları(*.jpeg)|*.jpeg|Jpg dosyaları(*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                imagepath = openFileDialog1.FileName;
            }

        }      
    }
}
