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
    public partial class HastaKayıt : Form
    {
        public HastaKayıt()
        {
            InitializeComponent();
        }
        public string tc { get; set; }
        public string pol_id { get; set; }
        public string polikilinik_adi { get; set; }
        public string ücret { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string tel { get; set; }
        public string yakinin_tel { get; set; }
        public string dogum_tar { get; set; }
        public string cinsiyet { get; set; }
        public string medeni_hal { get; set; }
        public string kan_grubu { get; set; }
        public string adres { get; set; }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
        OleDbConnection baglanti_Ücret = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ücret.mdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbCommand komut_gecmisKayitliHasta = new OleDbCommand();
        OleDbCommand komut_randevu = new OleDbCommand();
        OleDbCommand ücret_rapor = new OleDbCommand();
        private void hata1()
        {
            MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //  KAYDET BUTTONU
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox2.Text == "" || comboBox6.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    baglanti.Open();

                    OleDbCommand komut = new OleDbCommand("insert into kayitlihasta (tc,pol_id,poliklinik_adi,ücret,adi,soyadi,tel,yakinin_tel,dogum_tar,cinsiyet,medeni_hal,kan_grubu,adres) values ('" + textBox3.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox6.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + maskedTextBox2.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox8.Text.ToString() + "')", baglanti);
                    komut.ExecuteNonQuery();

                    OleDbCommand komut_gecmisKayitliHasta = new OleDbCommand("insert into gecmis_kayitlihasta (tc,pol_id,poliklinik_adi,ücret,adi,soyadi,tel,yakinin_tel,dogum_tar,cinsiyet,medeni_hal,kan_grubu,adres) values ('" + textBox3.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox6.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + maskedTextBox2.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox8.Text.ToString() + "')", baglanti);
                    komut_gecmisKayitliHasta.ExecuteNonQuery();

                    OleDbCommand komut_randevu = new OleDbCommand("insert into randevu (pol_id,tc,adi,soyadi) values ('" + comboBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglanti);
                    komut_randevu.ExecuteNonQuery();

                    baglanti.Close();


                    baglanti_Ücret.Open();

                    OleDbCommand ücret_rapor = new OleDbCommand("insert into ücret (tc,adi,soyadi,ücret) values ('" + textBox3.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox6.Text + "')", baglanti_Ücret);
                    ücret_rapor.ExecuteNonQuery();

                    baglanti_Ücret.Close();

                    MessageBox.Show("Hasta Başarı ile Eklendi !", "Hasta Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                textclear(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //  TEMİZLE BUTTONU
        private void button2_Click(object sender, EventArgs e)
        {
            textclear(this);
        }
        private void textclear(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    if (item == textBox2 || item == textBox8)
                    {
                        continue;
                    }
                    ((TextBox)item).Clear();
                }
                if (item.Controls.Count > 0)
                {
                    textclear(item);
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                textBox2.Clear();
                textBox8.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                dateTimePicker2.Value = DateTime.Today;
            }
        }
        //  SİLME BUTTONU
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete From kayitlihasta where tc='" + textBox3.Text + "'";
                komut.ExecuteNonQuery();

                komut_randevu.Connection = baglanti;
                komut_randevu.CommandText = "Delete From randevu where tc='" + textBox3.Text + "'";
                komut_randevu.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Hasta Başarı ile Silindi !", "Hasta Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textclear(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        //  GÜNCELLEME BUTTONU
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = ("Update kayitlihasta SET pol_id='" + comboBox2.Text + "',poliklinik_adi='" + comboBox1.Text + "',ücret='" + comboBox6.Text + "',adi='" + textBox2.Text + "',soyadi='" + textBox4.Text + "',tel='" + maskedTextBox1.Text + "',yakinin_tel='" + maskedTextBox2.Text + "',dogum_tar='" + dateTimePicker2.Text + "',cinsiyet='" + comboBox5.Text + "',medeni_hal='" + comboBox3.Text + "',kan_grubu='" + comboBox4.Text + "',adres='" + textBox8.Text + "'where tc='" + textBox3.Text + "'");
                    komut.ExecuteNonQuery();

                    komut_randevu.Connection = baglanti;
                    komut_randevu.CommandText = ("Update randevu SET pol_id='" + comboBox2.Text + "',adi='" + textBox2.Text + "',soyadi='" + textBox4.Text + "'where tc='" + textBox3.Text + "'");
                    komut_randevu.ExecuteNonQuery();

                    // ÇALIŞTIRIP DENE GÜNCELLİYOR MU ???????????????

                    baglanti.Close();
                }
                textclear(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);     // SADECE RAKAM GİRİŞİ !
        }

        private void HastaKayıt_Load(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = tc;
                comboBox2.Text = pol_id;
                comboBox1.Text = polikilinik_adi;
                comboBox6.Text = ücret;
                textBox2.Text = adi;
                textBox4.Text = soyadi;
                maskedTextBox1.Text = tel;
                maskedTextBox2.Text = yakinin_tel;
                dateTimePicker2.Text = dogum_tar;
                comboBox5.Text = cinsiyet;
                comboBox3.Text = medeni_hal;
                comboBox4.Text = kan_grubu;
                textBox8.Text = adres;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
