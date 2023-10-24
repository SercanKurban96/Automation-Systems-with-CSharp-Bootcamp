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
    public partial class FrmMusteriEkleme : Form
    {
        public FrmMusteriEkleme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2VA2JL1\\SQLSERCAN;Initial Catalog=DbHotelAutomation;User ID=WebMobile_302;Password=webmobile.302");

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Text = button7.Text;
        }

        private void FrmMusteriEkleme_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from MusteriEKleme", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                string odaNoData = oku["OdaNo"].ToString();

                foreach (Control control in this.groupBox2.Controls)
                {
                    if (control is Button button && button.Name.StartsWith("button"))
                    {
                        if (button.Text == odaNoData)
                        {
                            button.BackColor = Color.Red;
                            break;
                        }
                    }
                }
            }
            oku.Close();
            baglanti.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into MusteriEkleme (Adi,Soyadi,TCNo,Telefon,OdaNo,Ucret,GirisTarihi,CikisTarihi) values ('" + textBox1.Text + "','" + textBox2.Text + "','"+textBox3.Text+"','"+maskedTextBox1.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"','"+dateTimePicker2.Value.ToString()+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri başarılı bir şekilde kaydedildi.", "Müşteri Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
