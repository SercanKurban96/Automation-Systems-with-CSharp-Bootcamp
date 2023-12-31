﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EmployeeTracking
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=employee.accdb");

        private void personel_listesi()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter("select tcno AS[TC Kimlik], ad AS[Ad], soyad AS[Soyad], cinsiyet AS[Cinsiyet], dogumtarihi AS[Doğum Tarihi], gorevi AS[Mezuniyeti], gorevyeri AS[Görev Yeri] from personeller order by tcno ASC", baglantim);
                DataSet dshafiza = new DataSet();
                oleDbDataAdapter.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Personel Görüntüleme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            personel_listesi();
            this.Text = "KULLANICI İŞLEMLERİ";
            maskedTextBox1.Mask = "00000000000";
            label2.Text = Form1.adi + " " + Form1.soyadi;
            pictureBox1.Height = 150; pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            pictureBox2.Height = 150; pictureBox2.Width = 150;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;

            try
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimleri\\" + Form1.tcno + ".jpg");
            }
            catch (Exception)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimleri\\resimsiz.jpg");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kayit_okuma_durumu = false;

            if (maskedTextBox1.Text.Length == 11)
            {
                baglantim.Open();
                OleDbCommand selectSorgu = new OleDbCommand("select * from personeller where tcno='"+maskedTextBox1.Text+"'", baglantim);
                OleDbDataReader kayit_okuma = selectSorgu.ExecuteReader();
                while (kayit_okuma.Read())
                {
                    kayit_okuma_durumu = true;
                    try
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimleri\\" + kayit_okuma.GetValue(0) + ".jpg");
                    }
                    catch (Exception)
                    {
                        pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimleri\\resimsiz.jpg");
                    }
                    label10.Text = kayit_okuma.GetValue(1).ToString();
                    label11.Text = kayit_okuma.GetValue(2).ToString();
                    if (kayit_okuma.GetValue(3).ToString() == "Erkek")
                        label12.Text = "Erkek";
                    else
                        label12.Text = "Kadın";
                    label13.Text = kayit_okuma.GetValue(4).ToString();
                    label14.Text = kayit_okuma.GetValue(5).ToString();
                    label15.Text = kayit_okuma.GetValue(6).ToString();
                    break;
                }
                if (kayit_okuma_durumu == false)
                {
                    MessageBox.Show("Kayıt Bulunamadı!", "Personel Arama", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Girilen TC numarası 11 haneli olmalıdır!", "Personel Arama", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
