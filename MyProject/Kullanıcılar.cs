using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MyProject
{
    public partial class Kullanıcılar : Form
    {
        public Kullanıcılar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");

        OleDbCommand komut = new OleDbCommand();

        OleDbDataReader dr;
        public void verilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            // OleDbCommand komut = new OleDbCommand("Select tc,kullanici_adi,sifre,gizli_yanit,telefon,adi,soyadi,yetkisi From kullanicilar", baglanti);
            OleDbCommand komut = new OleDbCommand("Select *From kullanicilar", baglanti);
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["tc"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["soyadi"].ToString());
                ekle.SubItems.Add(oku["kullanici_adi"].ToString());
                ekle.SubItems.Add(oku["sifre"].ToString());
                ekle.SubItems.Add(oku["gizli_yanit"].ToString());
                ekle.SubItems.Add(oku["yetkisi"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["email"].ToString());
                ekle.SubItems.Add(oku["dogum_yeri"].ToString());
                ekle.SubItems.Add(oku["baba_adi"].ToString());
                ekle.SubItems.Add(oku["ana_adi"].ToString());
                ekle.SubItems.Add(oku["unvan"].ToString());
                ekle.SubItems.Add(oku["maas"].ToString());
                ekle.SubItems.Add(oku["baslama_tar"].ToString());
                ekle.SubItems.Add(oku["dogum_tar"].ToString());
                ekle.SubItems.Add(oku["cinsiyet"].ToString());
                ekle.SubItems.Add(oku["medeni_hal"].ToString());
                ekle.SubItems.Add(oku["kan_grubu"].ToString());
                ekle.SubItems.Add(oku["adres"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void Kullanıcılar_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }
        private void listView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                KullanıcıEkleme gonder = new KullanıcıEkleme();

                listView1.Items.Clear();



                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "select *from kullanicilar";
                komut.ExecuteNonQuery();
                dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    gonder.tc = listView1.SelectedItems[0].SubItems[0].Text;
                    gonder.adi = listView1.SelectedItems[0].SubItems[1].Text;
                    gonder.soyadi = listView1.SelectedItems[0].SubItems[2].Text;
                    gonder.kullanici_adi = listView1.SelectedItems[0].SubItems[3].Text;
                    gonder.sifre = listView1.SelectedItems[0].SubItems[4].Text;
                    gonder.gizli_yanit = listView1.SelectedItems[0].SubItems[5].Text;
                    gonder.yetkisi = listView1.SelectedItems[0].SubItems[6].Text;
                    gonder.telefon = listView1.SelectedItems[0].SubItems[7].Text;
                    gonder.email = listView1.SelectedItems[0].SubItems[8].Text;
                    gonder.dogum_yeri = listView1.SelectedItems[0].SubItems[9].Text;
                    gonder.baba_adi = listView1.SelectedItems[0].SubItems[10].Text;
                    gonder.ana_adi = listView1.SelectedItems[0].SubItems[11].Text;
                    gonder.unvan = listView1.SelectedItems[0].SubItems[12].Text;
                    gonder.maas = listView1.SelectedItems[0].SubItems[13].Text;
                    gonder.baslama_tar = listView1.SelectedItems[0].SubItems[14].Text;
                    gonder.dogum_tar = listView1.SelectedItems[0].SubItems[15].Text;
                    gonder.cinsiyet = listView1.SelectedItems[0].SubItems[16].Text;
                    gonder.medeni_hal = listView1.SelectedItems[0].SubItems[17].Text;
                    gonder.kan_grubu = listView1.SelectedItems[0].SubItems[18].Text;
                    gonder.adres = listView1.SelectedItems[0].SubItems[19].Text;


                    gonder.ShowDialog();
                }
                #region Deneme
                /* this.Close();
           KullanıcıEkleme gonder = new KullanıcıEkleme();

           baglanti.Open();
           komut.Connection = baglanti;
           komut.CommandText = "select *from kullanicilar";
           komut.ExecuteNonQuery();
           dr = komut.ExecuteReader();
           
           if (dr.Read())
           {
                   gonder.tc = dr["tc"].ToString();
                   gonder.yetkisi = dr["yetkisi"].ToString();
                   gonder.kullanici_adi = dr["kullanici_adi"].ToString();
                   gonder.sifre = dr["sifre"].ToString();
                   gonder.gizli_yanit = dr["gizli_yanit"].ToString();
                   gonder.dogum_yeri = dr["dogum_yeri"].ToString();
                   gonder.baba_adi = dr["baba_adi"].ToString();
                   gonder.ana_adi = dr["ana_adi"].ToString();
                   gonder.telefon = dr["telefon"].ToString();
                   gonder.unvan = dr["unvan"].ToString();
                   gonder.adi = dr["adi"].ToString();
                   gonder.soyadi = dr["soyadi"].ToString();
                   gonder.maas = dr["maas"].ToString();
                   gonder.baslama_tar = dr["baslama_tar"].ToString();
                   gonder.dogum_tar = dr["dogum_tar"].ToString();
                   gonder.cinsiyet = dr["cinsiyet"].ToString();
                   gonder.medeni_hal = dr["medeni_hal"].ToString();
                   gonder.kan_grubu = dr["kan_grubu"].ToString();
                   gonder.adres = dr["adres"].ToString();
           }
           gonder.Show();*/
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
