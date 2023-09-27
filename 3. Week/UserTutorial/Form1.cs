using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<User> kullaniciListesi = new List<User>();
        private void BtnResimEkle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string dosyaYolu = openFileDialog.FileName;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.ImageLocation = dosyaYolu;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim yükleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir resim seçiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string okulu = textBox3.Text;
            string bolumu = textBox4.Text;

            string resimYolu = pictureBox1.ImageLocation;
            User kullanici = new User
            {
                Ad = ad,
                Soyad = soyad,
                Okulu = okulu,
                Bolumu = bolumu,
                ResimYolu = resimYolu
            };

            kullaniciListesi.Add(kullanici);

            MessageBox.Show("Kullanıcı kaydedildi:\n" + ad + "\n" + soyad + "\n" + okulu + "\n" + bolumu, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (User kullanici in kullaniciListesi)
            {
                listBox1.Items.Add(kullanici.Ad + " " + kullanici.Soyad);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string secilenKullaniciAdi = listBox1.SelectedItem.ToString();

                User secilenKullanici = kullaniciListesi.Find(k => (k.Ad + " " + k.Soyad) == secilenKullaniciAdi);
                label5.Text = secilenKullanici.Ad;
                label6.Text = secilenKullanici.Soyad;
                label7.Text = secilenKullanici.Okulu;
                label8.Text = secilenKullanici.Bolumu;

                if (!string.IsNullOrEmpty(secilenKullanici.ResimYolu))
                {
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.Image = Image.FromFile(secilenKullanici.ResimYolu);
                }
                else
                {
                    pictureBox2.Image = null;
                }
            }
        }
    }
}
