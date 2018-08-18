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
    public partial class PoliklinkEkleme : Form
    {
        public PoliklinkEkleme()
        {
            InitializeComponent();
        }
        public string pol_id { get; set; }
        public string poliklinikAdi { get; set; }
        public string durumu { get; set; }
        public string doktor { get; set; }
        public string aciklama { get; set; }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataReader dr;

        public void Temizle() 
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox3.Text = "";
            comboBox1.Text = "";
            textBox1.Focus();
        }
        private void hata1()
        {
            MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //  TEMİZLE BUTTONU
        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        //  KAYDET BUTTONU
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    baglanti.Open();
                    OleDbCommand komut = new OleDbCommand("insert into poliklinik (pol_id,poliklinik_adi,durumu,doktor,aciklama) values ('" + comboBox2.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Poliklinik Başarı ile Eklendi !", "Poliklinik Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PoliklinkEkleme_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Text = pol_id;
                textBox1.Text = poliklinikAdi;
                comboBox1.Text = durumu;
                comboBox3.Text = doktor;
                textBox2.Text = aciklama;

                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "SELECT adi,soyadi FROM doktor";
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["adi"].ToString() + " " + dr["soyadi"].ToString());
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //  SİLME BUTTONU
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete From poliklinik where poliklinik_adi='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Poliklinik Başarı ile Silindi !", "Poliklinik Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //  GÜCELLEME BUTTONU
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
                {
                    hata1();
                }
                else
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = ("Update poliklinik SET durumu='" + comboBox1.Text + "',aciklama='" + textBox2.Text + "'where poliklinik_adi='" + textBox1.Text + "'");
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Kullanıcı Başarı ile Güncellendi !", "Kullanıcı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
