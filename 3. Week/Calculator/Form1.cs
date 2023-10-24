using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rakamOlay(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || opertDurum)
            {
                textBox1.Clear();
            }
            opertDurum = false;
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
        }

        bool opertDurum = false;
        double sonuc = 0;
        string opert = "";

        private void islemOlay(object sender, EventArgs e)
        {
            opertDurum = true;
            Button btn = (Button)sender;
            string yeniOpr = btn.Text;

            label1.Text = label1.Text + " " + textBox1.Text + " " + yeniOpr;

            switch (opert)
            {
                case "+": textBox1.Text = (sonuc + double.Parse(textBox1.Text)).ToString(); break;
                case "-": textBox1.Text = (sonuc - double.Parse(textBox1.Text)).ToString(); break;
                case "*": textBox1.Text = (sonuc * double.Parse(textBox1.Text)).ToString(); break;
                case "/": textBox1.Text = (sonuc / double.Parse(textBox1.Text)).ToString(); break;
            }
            sonuc = double.Parse(textBox1.Text);
            textBox1.Text = sonuc.ToString();
            opert = yeniOpr;
        }

        private void C(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void CE(object sender, EventArgs e)
        {
            label1.Text = "Sonuç:";
            textBox1.Text = "0";
            opert = "";
            sonuc = 0;
            opertDurum = false;
        }

        private void esit(object sender, EventArgs e)
        {
            label1.Text = "Sonuç:";
            opertDurum = true;

            switch (opert)
            {
                case "+": textBox1.Text = (sonuc + double.Parse(textBox1.Text)).ToString(); break;
                case "-": textBox1.Text = (sonuc - double.Parse(textBox1.Text)).ToString(); break;
                case "*": textBox1.Text = (sonuc * double.Parse(textBox1.Text)).ToString(); break;
                case "/": textBox1.Text = (sonuc / double.Parse(textBox1.Text)).ToString(); break;
            }
            label1.Text = "Sonuç: " + textBox1.Text + " " + opert + " " + sonuc;
        }

        private void nokta(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
        }
    }
}
