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
    public partial class FrmMuhasebe : Form
    {
        public FrmMuhasebe()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2VA2JL1\\SQLSERCAN;Initial Catalog=DbHotelAutomation;User ID=WebMobile_302;Password=webmobile.302");
        private void FrmMuhasebe_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select sum(Ucret) as toplam from MusteriEkleme", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label2.Text = dr["toplam"].ToString();
            }
            baglanti.Close();

            int personel;
            if (int.TryParse(textBox1.Text, out personel))
            {
                label4.Text = (personel * 11400).ToString();
            }
            else
            {
                personel = 0;
                label4.Text = (personel * 11400).ToString();
            }
            label4.Text = personel.ToString();

            baglanti.Open();
            SqlCommand cmd1 = new SqlCommand("select sum(Bakliyat) as stok1 from Stoklar", baglanti);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                label8.Text = dr1["stok1"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand cmd2 = new SqlCommand("select sum(Sebze) as stok2 from Stoklar", baglanti);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                label9.Text = dr2["stok2"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand cmd3 = new SqlCommand("select sum(Icecek) as stok3 from Stoklar", baglanti);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                label10.Text = dr3["stok3"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand cmd4 = new SqlCommand("select sum(Elektrik) as fatura1 from Faturalar", baglanti);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            while (dr4.Read())
            {
                label6.Text = dr4["fatura1"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand cmd5 = new SqlCommand("select sum(Su) as fatura2 from Faturalar", baglanti);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                label14.Text = dr5["fatura2"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand cmd6 = new SqlCommand("select sum(Dogalgaz) as fatura3 from Faturalar", baglanti);
            SqlDataReader dr6 = cmd6.ExecuteReader();
            while (dr6.Read())
            {
                label15.Text = dr6["fatura3"].ToString();
            }
            baglanti.Close();

            int total;
            total = Convert.ToInt32(label2.Text) - Convert.ToInt32(label4.Text) + Convert.ToInt32(label6.Text) + Convert.ToInt32(label14.Text) + Convert.ToInt32(label15.Text) + Convert.ToInt32(label8.Text) + Convert.ToInt32(label9.Text) + Convert.ToInt32(label10.Text);

            label12.Text = total.ToString();
        }
    }
}
