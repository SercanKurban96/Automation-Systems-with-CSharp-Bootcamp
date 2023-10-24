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

namespace HotelReservation
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlConnection baglantim = new SqlConnection("Data Source=DESKTOP-2VA2JL1\\SQLSERCAN;Initial Catalog=DbHotelAutomation;User ID=WebMobile_302; password=webmobile.302");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglantim.Open();
            SqlCommand komut = new SqlCommand("select * from MusteriEkleme", baglantim);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = read["MusteriID"].ToString();
                ekle.SubItems.Add(read["Adi"].ToString());
                ekle.SubItems.Add(read["Soyadi"].ToString());
                ekle.SubItems.Add(read["TCNo"].ToString());
                ekle.SubItems.Add(read["Telefon"].ToString());
                ekle.SubItems.Add(read["OdaNo"].ToString());
                ekle.SubItems.Add(read["Ucret"].ToString());
                ekle.SubItems.Add(read["GirisTarihi"].ToString());
                ekle.SubItems.Add(read["CikisTarihi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglantim.Close();
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[7].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[8].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand kmt = new SqlCommand("delete from MusteriEkleme where MusteriID=(" + id + ")", baglantim);
            kmt.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Müşteri silindi.");
            verilerigoster();
            temizle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand kmt = new SqlCommand("update MusteriEkleme set Adi='" + textBox1.Text + "',Soyadi='" + textBox2.Text + "',TCNo='" + textBox3.Text + "',Telefon='" + maskedTextBox1.Text + "',OdaNo='" + textBox5.Text + "',Ucret='" + textBox6.Text + "',GirisTarihi='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',CikisTarihi='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' where MusteriID=" + id +"", baglantim);
            kmt.ExecuteNonQuery();
            baglantim.Close();
            MessageBox.Show("Müşteri güncellendi.");
            verilerigoster();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            int ucret;
            DateTime girisTarihi = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime cikisTarihi = Convert.ToDateTime(dateTimePicker2.Text);

            TimeSpan sonuc = girisTarihi - cikisTarihi;
            label10.Text = sonuc.ToString();

            ucret = Convert.ToInt32(label10.Text) * 200;
            textBox6.Text = ucret.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglantim.Open();
            SqlCommand komut = new SqlCommand("select * from MusteriEkleme where Adi like '%"+textBox1.Text+"%'", baglantim);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = read["MusteriID"].ToString();
                ekle.SubItems.Add(read["Adi"].ToString());
                ekle.SubItems.Add(read["Soyadi"].ToString());
                ekle.SubItems.Add(read["TCNo"].ToString());
                ekle.SubItems.Add(read["Telefon"].ToString());
                ekle.SubItems.Add(read["OdaNo"].ToString());
                ekle.SubItems.Add(read["Ucret"].ToString());
                ekle.SubItems.Add(read["GirisTarihi"].ToString());
                ekle.SubItems.Add(read["CikisTarihi"].ToString());
                listView1.Items.Add(ekle);
            }
            baglantim.Close();
        }
    }
}
