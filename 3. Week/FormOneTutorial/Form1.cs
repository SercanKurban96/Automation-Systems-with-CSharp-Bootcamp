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

namespace FormOneTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = "Merhaba";
            //label2.Text = "Dünya";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Metin Dosyaları|*.txt|Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif|Tüm Dosyalar|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dosyaYolu = openFileDialog.FileName;
                    try
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox1.Image = Image.FromFile(dosyaYolu);

                        //string metin = File.ReadAllText(dosyaYolu);
                        //label1.Text = "Dosya İçeriği: " + metin;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Dosya Okuma Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("Resim Yükleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
