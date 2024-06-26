﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ileri_seviye__ATM_Uygulaması_application_
{
   static class Logger
    {
        static string KlasorYolu, DosyaYolu; // Fieldlar

        static Logger()
        {
            KlasorYolu = @"C:\ATM_Log";
            DosyaYolu = KlasorYolu + $"\\EOD_Tarih({DateTime.Now:dd.MM.yyy}).txt";
            VarlikKontrolu();
        }

        static void VarlikKontrolu()
        {
            if (!Directory.Exists(KlasorYolu)) // Klasör yoksa
                Directory.CreateDirectory(KlasorYolu); // Oluştur!

            if (!File.Exists(DosyaYolu)) // Dosya yoksa
                File.Create(DosyaYolu).Close();     // Oluştur! Ardından dosyayı kapat!
        }

        internal static string DosyaOku() => File.ReadAllText(DosyaYolu);
        internal static void DosyaYaz(string deger)
        {
            deger = $"\n{DateTime.Now:T} \nYapılan İşlem: {deger} \n";
            File.AppendAllText(DosyaYolu, deger);
        }
    }
}
