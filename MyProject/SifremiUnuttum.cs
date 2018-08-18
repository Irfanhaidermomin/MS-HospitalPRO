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
using System.Net.Mail;      //  GEREKLİ OLAN KÜTÜPHANE ...

namespace MyProject
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
        OleDbCommand komut = new OleDbCommand();

        public bool Gonder(string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("<your email>");//buraya kendi gmail hesabınız
            
            ePosta.To.Add(textBox2.Text);//bura şifre unutanın maili textboxdan çekdiniz.

            ePosta.Subject = konu; //butonda veri tabanı çekdikden sonra aldımız değer konu değeri
            //
            ePosta.Body = icerik;  // buda şifremiz
            //
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential("<your email>", "<your password>");
            //  kendi gmail hesabiniz var şifresi
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;
        }

        private void Temizle() 
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region beklet
            /*if (textBox1.Text=="")
            {
                MessageBox.Show("Lütfen gizli yanıtınızı giriniz !", "Boş Kutu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listView1.Items.Clear();
                baglati.Open();
                OleDbCommand komut = new OleDbCommand("Select *From kullanicilar where gizli_yanit like '%" + textBox1.Text + "%'", baglati);
                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();

                    ekle.Text = oku["kullanici_adi"].ToString();
                    ekle.SubItems.Add(oku["sifre"].ToString());
                    ekle.SubItems.Add(oku["gizli_yanit"].ToString());

                    listView1.Items.Add(ekle);
                }
                baglati.Close();
                textBox1.Clear();
            }*/
            #endregion
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                baglanti.Open();
                OleDbCommand com = new OleDbCommand("Select *From kullanicilar where tc='" + textBox1.Text + "'and email='" + textBox2.Text + "'", baglanti);
                OleDbDataReader oku = com.ExecuteReader();

                if (oku.Read())
                {
                    //burada verdiği tc ve mail doğruysa gireceği için şifreyi veritabanından çekip gönder fonksiyonunu kullanarak göndereceğiz

                    string sifre = oku["sifre"].ToString();
                    string k_adi = oku["kullanici_adi"].ToString();

                    //veritabanından çekdik            
                    MessageBox.Show("Bilgiler Uyuşuyor ! Şifrenizi E-Mail Adresinize Yolluyoruz !", "Şifremi Unuttum", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Gonder("Unutmuş olduğunuz şifre ektedir !", "Kullanıcı Adınız = " + k_adi + " Şifre = " + sifre);
                    //gönder paremetresi ile içeriğe 2 string değer yolladık biri mesajımız öbürü şifresi
                    baglanti.Close();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Bilgileriniz Uyuşmadı !", "Dikkat !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                baglanti.Close();
                Temizle();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);     // SADECE RAKAM GİRİŞİ !
        }
    }
}
