using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcelTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ClosedXML kütüphanesini kuruyoruz.

            List<string> kasaVerileri = new List<string>();

            string excelDosyaYolu = "benzin_verileri.xlsx";

            kasaVerileri.Add("15.09.2023|alış|150");
            kasaVerileri.Add("15.09.2023|satış|150");
            kasaVerileri.Add("15.09.2023|alış|150");

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Veriler");

                worksheet.Cell(1, 1).Value = "Tarih";
                worksheet.Cell(1, 2).Value = "İşlem Türü";
                worksheet.Cell(1, 3).Value = "Miktar";

                int satir = 2;

                foreach (var kasaVeri in kasaVerileri)
                {
                    string[] veriParcalari = kasaVeri.Split('|'); // 15.09|satış|100
                    string tarih = veriParcalari[0];
                    string islemTuru = veriParcalari[1];
                    int miktar = int.Parse(veriParcalari[2]);

                    worksheet.Cell(satir, 1).Value = tarih;
                    worksheet.Cell(satir, 1).Value = islemTuru;
                    worksheet.Cell(satir, 1).Value = miktar;

                    satir++;
                }

                workbook.SaveAs(excelDosyaYolu);
            }
            Console.WriteLine("Veriler başarıyla excel dosyasına kaydedildi.");
        }
    }
}
