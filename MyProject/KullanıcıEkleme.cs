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
    public partial class KullanıcıEkleme : Form
    {
        public KullanıcıEkleme()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");

        OleDbCommand komut = new OleDbCommand();

        OleDbCommand komut_Doktor = new OleDbCommand();
        public string tc { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string kullanici_adi { get; set; }
        public string sifre { get; set; }
        public string email { get; set; }
        public string yetkisi { get; set; }
        public string telefon { get; set; }
        public string dogum_yeri { get; set; }
        public string baba_adi { get; set; }
        public string ana_adi { get; set; }
        public string adres { get; set; }
        public string cinsiyet { get; set; }
        public string medeni_hal { get; set; }
        public string kan_grubu { get; set; }
        public string unvan { get; set; }
        public string maas { get; set; }
        public string baslama_tar { get; set; }
        public string gizli_yanit { get; set; }
        public string dogum_tar { get; set; }


        private void hata1()
        {
            MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //  KAYDET BUTTONU
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox12.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox5.Text == "")
                {
                    hata1();
                    // MASKED TEXTBOXUN BOS OLDUGUNDA HATA VERMIYOR ONA Bİ BAK !!!
                }
                else
                {
                    if (comboBox2.Text == "Doktor")
                    {
                        baglanti.Open();
                        komut_Doktor = new OleDbCommand("insert into doktor (tc,adi,soyadi,tel,maas,baslama_tar,adres) values ('" + textBox1.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglanti);
                        komut_Doktor.ExecuteNonQuery();
                        OleDbCommand komut = new OleDbCommand("insert into kullanicilar (tc,yetkisi,kullanici_adi,sifre,email,gizli_yanit,dogum_yeri,baba_adi,ana_adi,telefon,unvan,adi,soyadi,maas,baslama_tar,dogum_tar,cinsiyet,medeni_hal,kan_grubu,adres) values ('" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox10.Text.ToString() + "','" + textBox12.Text.ToString() + "','" + textBox11.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglanti);
                        komut.ExecuteNonQuery();
                    }
                    else
                    {
                        baglanti.Open();
                        OleDbCommand komut = new OleDbCommand("insert into kullanicilar (tc,yetkisi,kullanici_adi,sifre,email,gizli_yanit,dogum_yeri,baba_adi,ana_adi,telefon,unvan,adi,soyadi,maas,baslama_tar,dogum_tar,cinsiyet,medeni_hal,kan_grubu,adres) values ('" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox10.Text.ToString() + "','" + textBox12.Text.ToString() + "','" + textBox11.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + maskedTextBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglanti);
                        komut.ExecuteNonQuery();
                    }

                    baglanti.Close();

                    MessageBox.Show("Kullanıcı Başarı ile Eklendi !", "Kullanıcı Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textclear(this);
                }
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
                    if (item == textBox1 || item == textBox12)
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
                textBox1.Clear();
                textBox12.Clear();
                maskedTextBox1.Clear();
                dateTimePicker1.Value = DateTime.Today;
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
                komut.CommandText = "Delete From kullanicilar where tc='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Kullanıcı Başarı ile Silindi !", "Kullanıcı Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textclear(this);

                //  Kullanıcılar kapat = new Kullanıcılar();
                // kapat.Close();

                Kullanıcılar ac = new Kullanıcılar();
                ac.Show();
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

        private void KullanıcıEkleme_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = tc;
                comboBox1.Text = yetkisi;
                textBox6.Text = kullanici_adi;
                textBox10.Text = sifre;
                textBox12.Text = email;
                textBox7.Text = adi;
                textBox8.Text = soyadi;
                textBox9.Text = maas;
                maskedTextBox1.Text = telefon;
                textBox11.Text = gizli_yanit;
                textBox5.Text = adres;
                comboBox2.Text = unvan;
                comboBox5.Text = cinsiyet;
                comboBox3.Text = medeni_hal;
                comboBox4.Text = kan_grubu;
                textBox2.Text = dogum_yeri;
                textBox3.Text = baba_adi;
                textBox4.Text = ana_adi;
                dateTimePicker1.Text = baslama_tar;
                dateTimePicker2.Text = dogum_tar;

                if (comboBox2.Text == "Doktor")  //Button3 görünürlük
                {
                    button3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //  GÜNCELLEME BUTTONU
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox12.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox5.Text == "")
                {
                    hata1();
                    // MASKED TEXTBOXUN BOS OLDUGUNDA HATA VERMIYOR ONA Bİ BAK !!!
                }
                else
                {
                    if (comboBox2.Text == "Doktor")
                    {
                        baglanti.Open();
                        komut_Doktor.Connection = baglanti;
                        komut_Doktor.CommandText = ("Update doktor SET yetkisi='" + comboBox1.Text + "',kullanici_adi='" + textBox6.Text + "',sifre='" + textBox10.Text + "',email='" + textBox12.Text + "',gizli_yanit='" + textBox11.Text + "',dogum_yeri='" + textBox2.Text + "',baba_adi='" + textBox3.Text + "',ana_adi='" + textBox4.Text + "',telefon='" + maskedTextBox1.Text + "',unvan='" + comboBox2.Text + "',adi='" + textBox7.Text + "',soyadi='" + textBox8.Text + "',maas='" + textBox9.Text + "',baslama_tar='" + dateTimePicker1.Text + "',dogum_tar='" + dateTimePicker2.Text + "',cinsiyet='" + comboBox5.Text + "',medeni_hal='" + comboBox3.Text + "',kan_grubu='" + comboBox4.Text + "',adres='" + textBox5.Text + "'where tc='" + textBox1.Text + "'");
                        komut_Doktor.ExecuteNonQuery();

                        komut.Connection = baglanti;
                        komut.CommandText = ("Update kullanicilar SET yetkisi='" + comboBox1.Text + "',kullanici_adi='" + textBox6.Text + "',sifre='" + textBox10.Text + "',email='" + textBox12.Text + "',gizli_yanit='" + textBox11.Text + "',dogum_yeri='" + textBox2.Text + "',baba_adi='" + textBox3.Text + "',ana_adi='" + textBox4.Text + "',telefon='" + maskedTextBox1.Text + "',unvan='" + comboBox2.Text + "',adi='" + textBox7.Text + "',soyadi='" + textBox8.Text + "',maas='" + textBox9.Text + "',baslama_tar='" + dateTimePicker1.Text + "',dogum_tar='" + dateTimePicker2.Text + "',cinsiyet='" + comboBox5.Text + "',medeni_hal='" + comboBox3.Text + "',kan_grubu='" + comboBox4.Text + "',adres='" + textBox5.Text + "'where tc='" + textBox1.Text + "'");
                        komut.ExecuteNonQuery();
                    }
                    else
                    {
                        baglanti.Open();
                        komut.Connection = baglanti;
                        komut.CommandText = ("Update kullanicilar SET yetkisi='" + comboBox1.Text + "',kullanici_adi='" + textBox6.Text + "',sifre='" + textBox10.Text + "',email='" + textBox12.Text + "',gizli_yanit='" + textBox11.Text + "',dogum_yeri='" + textBox2.Text + "',baba_adi='" + textBox3.Text + "',ana_adi='" + textBox4.Text + "',telefon='" + maskedTextBox1.Text + "',unvan='" + comboBox2.Text + "',adi='" + textBox7.Text + "',soyadi='" + textBox8.Text + "',maas='" + textBox9.Text + "',baslama_tar='" + dateTimePicker1.Text + "',dogum_tar='" + dateTimePicker2.Text + "',cinsiyet='" + comboBox5.Text + "',medeni_hal='" + comboBox3.Text + "',kan_grubu='" + comboBox4.Text + "',adres='" + textBox5.Text + "'where tc='" + textBox1.Text + "'");
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                    }

                    MessageBox.Show("Kullanıcı Başarı ile Güncellendi !", "Kullanıcı Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textclear(this);
                }
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

        private void button6_Click(object sender, EventArgs e)  //Doktor Sil
        {
            try
            {
                baglanti.Open();
                komut_Doktor.Connection = baglanti;
                komut_Doktor.CommandText = "Delete From doktor where unvan='" + comboBox2.Text + "'";
                komut_Doktor.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Doktor Başarı ile Silindi !", "Doktor Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textclear(this);


                //BURAYA ASAGIDAKİ GİBİ KULLANICILAR YERİNE DOKTORLAR LİSTVİEWİNİ ACTIR !!!!__

                //Kullanıcılar ac = new Kullanıcılar();
                //ac.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
