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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2VA2JL1\\SQLSERCAN;Initial Catalog=DbHotelAutomation;User ID=WebMobile_302;Password=webmobile.302");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Stoklar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Bakliyat"].ToString();
                ekle.SubItems.Add(oku["Sebze"].ToString());
                ekle.SubItems.Add(oku["Icecek"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void verilerigoster2()
        {
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Faturalar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Elektrik"].ToString();
                ekle.SubItems.Add(oku["Su"].ToString());
                ekle.SubItems.Add(oku["Dogalgaz"].ToString());
                listView2.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            verilerigoster();
            verilerigoster2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Stoklar (Bakliyat,Sebze,Icecek) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
            komut.Parameters.AddWithValue("@p3", textBox3.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Faturalar (Elektrik,Su,Dogalgaz) values (@p1,@p2,@p3)", baglanti);
            komut2.Parameters.AddWithValue("@p1", textBox4.Text);
            komut2.Parameters.AddWithValue("@p2", textBox5.Text);
            komut2.Parameters.AddWithValue("@p3", textBox6.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster2();
        }
    }
}
