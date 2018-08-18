using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace MyProject
{
    class VeriBaglantisi
    {

        #region Veri Tabanı Bağlantısı


        string BaglantiMetni = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA";  // BURAYA VERİTABANINI OLUŞTURDUĞUNDA VERİ TABANI ADRESİ GİRİLECEK !   ==>>  ACCESS YAPIP VERİ TABANINA ŞİFRE KOYABİLİRSİN (2003 OLARAK KAYDETMELİSİN !)
        OleDbConnection Baglanti;
        //OleDbCommand komut;

        public VeriBaglantisi() 
        {

            Baglanti = new OleDbConnection(BaglantiMetni);
            Baglanti.Open();

        }
        #endregion

        #region Kullanıcı Girişi1 Kodları
        /*public int KullaniciGirisi1(string Ad, string Sifre) 
        {

            string Sorgu = "Select * From kullanicilar Where kullanici_adi='" + Ad + "'and sifre='" + Sifre + "'and yetkisi='" + "ADMİN" + "'"; // BURAYI DÜZELT !            
            komut = new OleDbCommand(Sorgu, Baglanti);
            int Sonuc = (int)komut.ExecuteScalar();
            return Sonuc;

        }
        #endregion
        #region Kullanıcı Girişi1 Kodları
        public int KullaniciGirisi2(string Ad, string Sifre)
        {

            string Sorgu = "Select count (*) From kullanicilar Where kullanici_adi='" + Ad + "'and sifre='" + Sifre + "'and yetkisi='" + "USER" + "'"; // BURAYI DÜZELT !            
            komut = new OleDbCommand(Sorgu, Baglanti);
            int Sonuc = (int)komut.ExecuteScalar();
            return Sonuc;

        }*/
        #endregion
    }
}