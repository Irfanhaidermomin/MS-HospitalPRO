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
    public partial class DoktorEkleme : Form
    {
        public DoktorEkleme()
        {
            InitializeComponent();
        }
        public string tc { get; set; }
        public string adi { get; set; }
        public string Soyadi { get; set; }
        public string telefon { get; set; }
        public string maas { get; set; }
        public string baslama_tar { get; set; }
        public string adres { get; set; }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
        OleDbCommand komut = new OleDbCommand();

        private void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            maskedTextBox1.Text = "";
            dateTimePicker1.Value = DateTime.Today;
        }
        private void hata1()
        {
            MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "")
                {
                    hata1();
                }
                else
                {
                    baglanti.Open();
                    OleDbCommand komut = new OleDbCommand("insert into doktor (tc,adi,soyadi,tel,maas,baslama_tar,adres) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Doktor Başarı ile Eklendi !", "Doktor Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete From doktor where tc='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Doktor Başarı ile Silindi !", "Doktor Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || maskedTextBox1.Text == "")
                {
                    hata1();
                }
                else
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = ("Update doktor SET adi='" + textBox2.Text + "',soyadi='" + textBox5.Text + "',tel='" + maskedTextBox1.Text + "',maas='" + textBox3.Text + "',baslama_tar='" + dateTimePicker1.Text + "',adres='" + textBox4.Text + "'where tc='" + textBox1.Text + "'");
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Doktor Başarı ile Güncellendi !", "Doktor Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programı Kapatmak İstediğinizden Emin Misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);     // SADECE RAKAM GİRİŞİ !
        }

        private void DoktorEkleme_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = tc;
                textBox2.Text = adi;
                textBox5.Text = Soyadi;
                textBox3.Text = maas;
                textBox4.Text = adres;
                maskedTextBox1.Text = telefon;
                dateTimePicker1.Text = baslama_tar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
