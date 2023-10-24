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
    public partial class FrmOdalar : Form
    {
        public FrmOdalar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-2VA2JL1\\SQLSERCAN;Initial Catalog=DbHotelAutomation;User ID=WebMobile_302;Password=webmobile.302");

        private void FrmOdalar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select * from MusteriEKleme", baglanti);
            SqlDataReader oku = kmt.ExecuteReader();

            while (oku.Read())
            {
                string odaNoData = oku["OdaNo"].ToString();

                foreach (Control control in this.Controls)
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
    }
}
