using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadExcelBogorSehat.Models;

namespace UploadExcelBogorSehat
{

    class Program
    {
        private BogorHealthEntities db = new BogorHealthEntities();
        static void Main(string[] args)
        {
            uploadSpesialis();

        }


        public static void uploadSpesialis()
        {
            BogorHealthEntities db = new BogorHealthEntities();
            string pathToExcelFile = ""+ @"D:\rsud.xlsx";
            string sheetName = "Spesialis";
            

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet(sheetName) select a;
            IQueryable<Spesiali> sp = (from a in excelFile.Worksheet<Spesiali>(sheetName) select a);
            foreach (Spesiali spesiali in sp)
            {
                db.Spesialis.Add(spesiali);
                db.SaveChanges();
                Console.WriteLine("Ok");
            }
        }


        public static void uploadDokter()
        {
            BogorHealthEntities db = new BogorHealthEntities();
            string pathToExcelFile = "" + @"D:\rsud.xlsx";
            string sheetName = "Dokter";


            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet(sheetName) select a;
            IQueryable<Dokter> sp = (from a in excelFile.Worksheet<Dokter>(sheetName) select a);

            foreach (Dokter dok in sp)
            {
                db.Dokters.Add(dok);
                db.SaveChanges();
                Console.WriteLine("Ok");
            }
        }

        public static void uploadLayanan()
        {
            BogorHealthEntities db = new BogorHealthEntities();
            string pathToExcelFile = "" + @"D:\rsud.xlsx";
            string sheetName = "Jenis Layanan";


            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet(sheetName) select a;
            IQueryable<JenisLayanan> sp = (from a in excelFile.Worksheet<JenisLayanan>(sheetName) select a);

            foreach (JenisLayanan dok in sp)
            {
                db.JenisLayanans.Add(dok);
                db.SaveChanges();
                Console.WriteLine("Ok");
            }
        }
    }
}
