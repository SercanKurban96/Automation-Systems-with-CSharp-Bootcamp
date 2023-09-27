using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStationAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double D_benzin95 = 0, D_benzin97 = 0, D_dizel = 0, D_eurodizel = 0, D_lpg = 0;
        double F_benzin95 = 0, F_benzin97 = 0, F_dizel = 0, F_eurodizel = 0, F_lpg = 0;
        double E_benzin95 = 0, E_benzin97 = 0, E_dizel = 0, E_eurodizel = 0, E_lpg = 0; // Eklenen benzin işlemi

        private void BtnDepoGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                E_benzin95 = Convert.ToDouble(textBox1.Text);
                if (1000<D_benzin95 + E_benzin95 || E_benzin95 <= 0)
                {
                    textBox1.Text = "HATA";
                }
                else
                {
                    depo_bilgileri[0] = Convert.ToString(D_benzin95 + E_benzin95);
                }               
            }
            catch (Exception)
            {
                textBox1.Text = "HATA";
            }

            try
            {
                E_benzin97 = Convert.ToDouble(textBox2.Text);
                if (1000 < D_benzin97 + E_benzin97 || E_benzin97 <= 0)
                {
                    textBox2.Text = "HATA";
                }
                else
                {
                    depo_bilgileri[1] = Convert.ToString(D_benzin97 + E_benzin97);
                }
            }
            catch (Exception)
            {
                textBox2.Text = "HATA";
            }

            try
            {
                E_dizel = Convert.ToDouble(textBox3.Text);
                if (1000 < D_dizel + E_dizel || E_dizel <= 0)
                {
                    textBox3.Text = "HATA";
                }
                else
                {
                    depo_bilgileri[2] = Convert.ToString(D_dizel + E_dizel);
                }
            }
            catch (Exception)
            {
                textBox3.Text = "HATA";
            }

            try
            {
                E_eurodizel = Convert.ToDouble(textBox4.Text);
                if (1000 < D_eurodizel + E_eurodizel || E_eurodizel <= 0)
                {
                    textBox4.Text = "HATA";
                }
                else
                {
                    depo_bilgileri[3] = Convert.ToString(D_eurodizel + E_eurodizel);
                }
            }
            catch (Exception)
            {
                textBox4.Text = "HATA";
            }

            try
            {
                E_lpg = Convert.ToDouble(textBox5.Text);
                if (1000 < D_lpg + E_lpg || E_lpg <= 0)
                {
                    textBox5.Text = "HATA";
                }
                else
                {
                    depo_bilgileri[4] = Convert.ToString(D_lpg + E_lpg);
                }
            }
            catch (Exception)
            {
                textBox5.Text = "HATA";
            }

            File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressBar_durum();
        }

        string[] depo_bilgileri;
        string[] fiyat_bilgileri;

        private void txt_depo_oku()
        {
            depo_bilgileri = File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_benzin95 = Convert.ToDouble(depo_bilgileri[0]);
            D_benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            D_dizel = Convert.ToDouble(depo_bilgileri[2]);
            D_eurodizel = Convert.ToDouble(depo_bilgileri[3]);
            D_lpg = Convert.ToDouble(depo_bilgileri[4]);
        }

        private void txt_depo_yaz()
        {
            label6.Text = D_benzin95.ToString("N");
            label7.Text = D_benzin97.ToString("N");
            label8.Text = D_dizel.ToString("N");
            label9.Text = D_eurodizel.ToString("N");
            label10.Text = D_lpg.ToString("N");
        }

        private void txt_fiyat_oku()
        {
            fiyat_bilgileri = File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            F_dizel = Convert.ToDouble(fiyat_bilgileri[2]);
            F_eurodizel = Convert.ToDouble(fiyat_bilgileri[3]);
            F_lpg = Convert.ToDouble(fiyat_bilgileri[4]);
        }

        private void txt_fiyat_yaz()
        {
            label17.Text = F_benzin95.ToString("N");
            label18.Text = F_benzin97.ToString("N");
            label19.Text = F_dizel.ToString("N");
            label20.Text = F_eurodizel.ToString("N");
            label21.Text = F_lpg.ToString("N");
        }

        private void progressBar_durum()
        {
            this.Text = "Akaryakıt Otomasyonu";
            progressBar1.Value = Convert.ToInt32(D_benzin95);
            progressBar2.Value = Convert.ToInt32(D_benzin97);
            progressBar3.Value = Convert.ToInt32(D_dizel);
            progressBar4.Value = Convert.ToInt32(D_eurodizel);
            progressBar5.Value = Convert.ToInt32(D_lpg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;

            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            progressBar_durum();
        }
    }
}
