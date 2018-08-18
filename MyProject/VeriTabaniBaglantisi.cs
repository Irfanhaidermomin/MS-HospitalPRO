using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace MyProject
{
    class VeriTabaniBaglantisi
    {
        OleDbConnection Baglanti;
        OleDbCommand komut;
        //OleDbDataReader dr;

        public void VeriBaglantisi() 
        {

            Baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
            Baglanti.Open();

        }
        #region Kullanıcı Girişi1 Kodları
        public int KullaniciGirisi1(string Ad, string Sifre)
        {
            string Sorgu = "Select count (*) From kullanicilar Where kullanici_adi='" + Ad + "'and sifre='" + Sifre + "'and yetkisi='" + "ADMİN" + "'"; // BURAYI DÜZELT !            
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

        }
        #endregion
    }
}
