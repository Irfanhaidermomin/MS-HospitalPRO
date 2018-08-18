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
    public partial class HastaBul : Form
    {
        public HastaBul()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader dr;
        public void veriler()
        {
            listView2.Items.Clear();

            baglanti.Open();
            komut = new OleDbCommand("Select *From kayitlihasta", baglanti);
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
        private void veriler2()
        {
            listView3.Items.Clear();

            baglanti.Open();
            komut = new OleDbCommand("Select *From randevu", baglanti);
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = dr["sira_no"].ToString();
                ekle.SubItems.Add(dr["pol_id"].ToString());
                ekle.SubItems.Add(dr["tc"].ToString());
                ekle.SubItems.Add(dr["adi"].ToString()); //dikkat
                ekle.SubItems.Add(dr["soyadi"].ToString());

                listView3.Items.Add(ekle);
            }
            baglanti.Close();
        }
        public void veriler_Gecmiskayitli()
        {
            listView3.Items.Clear();

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

                listView3.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
        }
        public static AnaSayfa gecmis_kayıtlı;
        private void HastaBul_Load(object sender, EventArgs e)
        {
            try
            {
                //gecmis_kayıtlı.geçmişKayıtlıHastalarToolStripMenuItem += geçmişKayıtlıHastalarToolStripMenuItem_Click;
                veriler();
                veriler2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void geçmişKayıtlıHastalarToolStripMenuItem_Click(object sender, EventArgs e)
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
                komut.CommandText = "select *from kayitlihasta";
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

        private void button1_Click(object sender, EventArgs e) //BUTTON BUL KAYİTLİ
        {
            try
            {
                listView2.Items.Clear();
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Select *From kayitlihasta where tc like '%" + textBox1.Text + "%'", baglanti);
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

        private void button2_Click(object sender, EventArgs e) // BUTTON BUL GEÇMİŞ
        {
            try
            {
                listView2.Items.Clear();
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Select *From kayitlihasta where tc like '%" + textBox1.Text + "%'", baglanti);
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

        private void button3_Click(object sender, EventArgs e) // BUTTON BUL RANDEVU
        {
            try
            {
                listView3.Items.Clear();
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Select *From randevu where tc like '%" + textBox1.Text + "%'", baglanti);
                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();

                    ekle.Text = oku["sira_no"].ToString();
                    ekle.SubItems.Add(oku["pol_id"].ToString());
                    ekle.SubItems.Add(oku["tc"].ToString());
                    ekle.SubItems.Add(oku["adi"].ToString());
                    ekle.SubItems.Add(oku["soyadi"].ToString());

                    listView3.Items.Add(ekle);
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);     // SADECE RAKAM GİRİŞİ !
        }

        private void listView3_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
// ARAMA TC NOYA GÖRE ARANACAK ...............