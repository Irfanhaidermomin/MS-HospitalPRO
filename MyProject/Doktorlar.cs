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
    public partial class Doktorlar : Form
    {
        public Doktorlar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader dr;

        private void veriler()
        {
            listView1.Items.Clear();

            baglanti.Open();
            komut = new OleDbCommand("Select *From doktor", baglanti);
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = dr["tc"].ToString();
                ekle.SubItems.Add(dr["adi"].ToString());
                ekle.SubItems.Add(dr["soyadi"].ToString());
                ekle.SubItems.Add(dr["tel"].ToString());
                ekle.SubItems.Add(dr["maas"].ToString());
                ekle.SubItems.Add(dr["baslama_tar"].ToString());
                ekle.SubItems.Add(dr["adres"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                DoktorEkleme Doktor_Gonder = new DoktorEkleme();

                listView1.Items.Clear();

                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "select *from doktor";
                komut.ExecuteNonQuery();
                dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    Doktor_Gonder.tc = listView1.SelectedItems[0].SubItems[0].Text;
                    Doktor_Gonder.adi = listView1.SelectedItems[0].SubItems[1].Text;
                    Doktor_Gonder.Soyadi = listView1.SelectedItems[0].SubItems[2].Text;
                    Doktor_Gonder.telefon = listView1.SelectedItems[0].SubItems[3].Text;
                    Doktor_Gonder.maas = listView1.SelectedItems[0].SubItems[4].Text;
                    Doktor_Gonder.baslama_tar = listView1.SelectedItems[0].SubItems[5].Text;
                    Doktor_Gonder.adres = listView1.SelectedItems[0].SubItems[6].Text;

                    Doktor_Gonder.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Doktorlar_Load(object sender, EventArgs e)
        {
            try
            {
                veriler();
                if (Program.a.kullanıcıEklemeToolStripMenuItem.Visible == true)        // USER KULLANICI GİRDİĞİNDE LİSTVİEW ÇİFT TIKLAMA DEVRE DIŞI
                {
                    listView1.DoubleClick += new EventHandler(listView1_DoubleClick);
                }
                if (Program.a.veriTabanıToolStripMenuItem.Visible == false)
                {
                    listView1.DoubleClick -= new EventHandler(listView1_DoubleClick);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
