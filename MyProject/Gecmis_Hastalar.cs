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
    public partial class Gecmis_Hastalar : Form
    {
        public Gecmis_Hastalar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader dr;
        public void veriler_Gecmiskayitli()
        {
            listView2.Items.Clear();

            baglanti.Open();
            komut = new OleDbCommand("Select *From gecmis_kayitlihasta", baglanti);
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = dr["tc"].ToString();
                ekle.SubItems.Add(dr["pol_id"].ToString());
                ekle.SubItems.Add(dr["poliklinik_adi"].ToString());
                ekle.SubItems.Add(dr["ücret"].ToString()); //dikkat
                ekle.SubItems.Add(dr["adi"].ToString());
                ekle.SubItems.Add(dr["soyadi"].ToString());
                ekle.SubItems.Add(dr["tel"].ToString());
                ekle.SubItems.Add(dr["yakinin_tel"].ToString());
                ekle.SubItems.Add(dr["dogum_tar"].ToString());
                ekle.SubItems.Add(dr["cinsiyet"].ToString());
                ekle.SubItems.Add(dr["medeni_hal"].ToString());
                ekle.SubItems.Add(dr["kan_grubu"].ToString());
                ekle.SubItems.Add(dr["adres"].ToString());

                listView2.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void Gecmis_Hastalar_Load(object sender, EventArgs e)
        {
            try
            {
                veriler_Gecmiskayitli();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                HastaKayıt hastaGonder = new HastaKayıt();

                listView2.Items.Clear();

                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "select *from gecmis_kayitlihasta";
                komut.ExecuteNonQuery();
                dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    hastaGonder.tc = listView2.SelectedItems[0].SubItems[0].Text;
                    hastaGonder.pol_id = listView2.SelectedItems[0].SubItems[1].Text;
                    hastaGonder.polikilinik_adi = listView2.SelectedItems[0].SubItems[2].Text;
                    hastaGonder.ücret = listView2.SelectedItems[0].SubItems[3].Text;
                    hastaGonder.adi = listView2.SelectedItems[0].SubItems[4].Text;
                    hastaGonder.soyadi = listView2.SelectedItems[0].SubItems[5].Text;
                    hastaGonder.tel = listView2.SelectedItems[0].SubItems[6].Text;
                    hastaGonder.yakinin_tel = listView2.SelectedItems[0].SubItems[7].Text;
                    hastaGonder.dogum_tar = listView2.SelectedItems[0].SubItems[8].Text;
                    hastaGonder.cinsiyet = listView2.SelectedItems[0].SubItems[9].Text;
                    hastaGonder.medeni_hal = listView2.SelectedItems[0].SubItems[10].Text;
                    hastaGonder.kan_grubu = listView2.SelectedItems[0].SubItems[11].Text;
                    hastaGonder.adres = listView2.SelectedItems[0].SubItems[12].Text;

                    hastaGonder.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listView2.Items.Clear();
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Select *From gecmis_kayitlihasta where tc like '%" + textBox1.Text + "%'", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();

                    ekle.Text = oku["tc"].ToString();
                    ekle.SubItems.Add(oku["pol_id"].ToString());
                    ekle.SubItems.Add(oku["poliklinik_adi"].ToString());
                    ekle.SubItems.Add(oku["ücret"].ToString());
                    ekle.SubItems.Add(oku["adi"].ToString());
                    ekle.SubItems.Add(oku["soyadi"].ToString());
                    ekle.SubItems.Add(oku["tel"].ToString());
                    ekle.SubItems.Add(oku["yakinin_tel"].ToString());
                    ekle.SubItems.Add(oku["dogum_tar"].ToString());
                    ekle.SubItems.Add(oku["cinsiyet"].ToString());
                    ekle.SubItems.Add(oku["medeni_hal"].ToString());
                    ekle.SubItems.Add(oku["kan_grubu"].ToString());
                    ekle.SubItems.Add(oku["adres"].ToString());

                    listView2.Items.Add(ekle);
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
