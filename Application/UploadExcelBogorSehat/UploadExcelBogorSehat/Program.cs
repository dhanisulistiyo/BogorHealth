﻿using LinqToExcel;
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
            // uploadSpesialis();
            //uploadDokter();
            //uploadLayanan();
            //uploadAdmin();
            //uploadRS();
            //uploadLayananRS();
            uploadJadwal();
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

        public static void uploadAdmin()
        {
            BogorHealthEntities db = new BogorHealthEntities();
            string pathToExcelFile = "" + @"D:\rsud.xlsx";
            string sheetName = "Admin";


            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet(sheetName) select a;
            IQueryable<Admin> sp = (from a in excelFile.Worksheet<Admin>(sheetName) select a);

            foreach (Admin dok in sp)
            {
                db.Admins.Add(dok);
                db.SaveChanges();
                Console.WriteLine("Ok");
            }
        }

        public static void uploadRS()
        {
            BogorHealthEntities db = new BogorHealthEntities();
            string pathToExcelFile = "" + @"D:\rsud.xlsx";
            string sheetName = "RS";


            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet(sheetName) select a;
            IQueryable<RumahSakit> sp = (from a in excelFile.Worksheet<RumahSakit>(sheetName) select a);

            foreach (RumahSakit dok in sp)
            {
                db.RumahSakits.Add(dok);
                db.SaveChanges();
                Console.WriteLine("Ok");
            }
        }


        public static void uploadLayananRS()
        {
            BogorHealthEntities db = new BogorHealthEntities();
            string pathToExcelFile = "" + @"D:\rsud.xlsx";
            string sheetName = "rrLayanan RS";


            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet(sheetName) select a;
            IQueryable<LayananR> sp = (from a in excelFile.Worksheet<LayananR>(sheetName) select a);

            foreach (LayananR dok in sp)
            {
               var l =  db.LayananRS.Find(dok.IdLayananRS);
                if (l == null)
                {
                    db.LayananRS.Add(dok);
                    db.SaveChanges();
                    Console.WriteLine("Ok");
                 }
            }
        }


        public static void uploadJadwal()
        {
            BogorHealthEntities db = new BogorHealthEntities();
            string pathToExcelFile = "" + @"D:\rsud.xlsx";
            string sheetName = "JadwalLayanan";


            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            IQueryable<Jadwal> artistAlbums = (from a in excelFile.Worksheet<Jadwal>(sheetName) select a);
            IQueryable<JadwalLayanan> sp = artistAlbums.Select(dok => new JadwalLayanan
            {
                IdJadwal= dok.IdLayananRS + dok.IdDokter + dok.JamMulai.TimeOfDay.TotalHours +dok.Hari,
                IdLayananRS = dok.IdLayananRS,
                IdDokter = dok.IdDokter,
                Hari = dok.Hari,
                JamMulai = (dok.JamMulai.TimeOfDay),
                JamSelesai = dok.JamSelesai.TimeOfDay,
            });

            foreach (var k in sp)
            {
                var cek = db.JadwalLayanans.Find(k.IdJadwal);
                if(cek == null)
                {
                    db.JadwalLayanans.Add(k);
                    db.SaveChanges();
                }
               

            }
            

            Console.Write(sp);

           
        }
    }
}
