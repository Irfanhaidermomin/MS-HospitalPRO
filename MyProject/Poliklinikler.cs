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
    public partial class Poliklinikler : Form
    {
        public Poliklinikler()
        {
            InitializeComponent();
        }
        //public string ListViewDevredısı { get; set; }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader dr;
        private void veriler()
        {
            listView1.Items.Clear();

            baglanti.Open();
            komut = new OleDbCommand("Select *From poliklinik", baglanti);
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = dr["pol_id"].ToString();
                ekle.SubItems.Add(dr["poliklinik_adi"].ToString());
                ekle.SubItems.Add(dr["durumu"].ToString());
                ekle.SubItems.Add(dr["doktor"].ToString());
                ekle.SubItems.Add(dr["aciklama"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }
        private void Poliklinikler_Load(object sender, EventArgs e)
        {
            try
            {
                veriler();
                if (Program.a.kullanıcıEklemeToolStripMenuItem.Visible == true)    // USER KULLANICI GİRDİĞİNDE LİSTVİEW ÇİFT TIKLAMA DEVRE DIŞI
                {
                    listView1.DoubleClick += new EventHandler(listView1_DoubleClick_1);
                }
                if (Program.a.veriTabanıToolStripMenuItem.Visible == false)
                {
                    listView1.DoubleClick -= new EventHandler(listView1_DoubleClick_1);
                }

                // listView1.DoubleClick -= new EventHandler(listView1_DoubleClick);
                //listView1.DoubleClick -= new EventHandler(listView1_DoubleClick_1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       /* private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
        }*/

        private void listView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                PoliklinkEkleme PoliklinikGonder = new PoliklinkEkleme();

                listView1.Items.Clear();

                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "select *from poliklinik";
                komut.ExecuteNonQuery();
                dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    PoliklinikGonder.pol_id = listView1.SelectedItems[0].SubItems[0].Text;
                    PoliklinikGonder.poliklinikAdi = listView1.SelectedItems[0].SubItems[1].Text;
                    PoliklinikGonder.durumu = listView1.SelectedItems[0].SubItems[2].Text;
                    PoliklinikGonder.doktor = listView1.SelectedItems[0].SubItems[3].Text;
                    PoliklinikGonder.aciklama = listView1.SelectedItems[0].SubItems[4].Text;

                    PoliklinikGonder.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void listView1_(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
