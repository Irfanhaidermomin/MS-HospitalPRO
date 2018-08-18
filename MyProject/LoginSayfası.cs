using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace MyProject
{
    public partial class LoginSayfası : Form
    {
        public LoginSayfası()
        {
            InitializeComponent();

            StreamReader reader = new StreamReader("BeniHatırla.txt");
            string hatırlananAd = reader.ReadToEnd();
            reader.Close();

            textBox1.Text = hatırlananAd;
        }
        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataReader dr;
        public void Kısayol_Etkinlestirme() 
        {
            Program.a.poliklinikEklemeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;       //KISAYOL ETKİNLENTİRME !
            Program.a.kullanıcıEklemeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            Program.a.kullanıcılarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            Program.a.raporlamaToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.R;
            Program.a.randevuluHastalarToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            Program.a.hastaKayıtToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F;
            Program.a.hastaVeriBulToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult hata = MessageBox.Show("Çıkmak İstediğinize Emin Misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (hata == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        public static LoginSayfası frm2;
        public static Poliklinikler polikinik;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    StreamWriter writer = new StreamWriter("BeniHatırla.txt");
                    writer.Write(textBox1.Text);
                    writer.Close();
                }

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Lütfen Boş Yerleri Doldurunuz !", "Boş Alanlar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string ad = textBox1.Text;
                    string sifre = textBox2.Text;

                    baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
                    komut = new OleDbCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Select * From kullanicilar Where kullanici_adi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'and yetkisi='" + "ADMİN" + "'";
                    dr = komut.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show("Giriş Başarılı !", "Yetkin Giriş !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Program.a.menuStrip1.Enabled = true;
                        Program.a.kullanıcıEklemeToolStripMenuItem.Visible = true;
                        Program.a.kullanıcılarToolStripMenuItem.Visible = true;
                        Program.a.poliklinikEklemeToolStripMenuItem.Visible = true;
                        Program.a.doktorEklemeToolStripMenuItem.Visible = true;
                        Program.a.veriTabanıToolStripMenuItem.Visible = true;
                        this.Hide();

                        Kısayol_Etkinlestirme();
                    }
                    else
                    {
                        baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MyProject.mdb;Jet OLEDB:Database Password=MUSTAFA");
                        komut = new OleDbCommand();
                        baglanti.Open();
                        komut.Connection = baglanti;
                        komut.CommandText = "Select * From kullanicilar Where kullanici_adi='" + textBox1.Text + "'and sifre='" + textBox2.Text + "'and yetkisi='" + "USER" + "'";
                        dr = komut.ExecuteReader();

                        if (dr.Read())
                        {
                            MessageBox.Show("STANDART YETKİ !", "Yetki Kısıtlaması !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Program.a.menuStrip1.Enabled = true;
                            Program.a.kullanıcıEklemeToolStripMenuItem.Visible = false;
                            Program.a.kullanıcılarToolStripMenuItem.Visible = false;
                            Program.a.poliklinikEklemeToolStripMenuItem.Visible = false;
                            Program.a.doktorEklemeToolStripMenuItem.Visible = false;
                            Program.a.veriTabanıToolStripMenuItem.Visible = false;
                            this.Hide();

                            Kısayol_Etkinlestirme();
                            // POLİKLİNİKLER ÇİFT TIKLANDIGINDA ACILIYOR O BUGU DÜZELT
                            Program.a.kullanıcıEklemeToolStripMenuItem.ShortcutKeys = Keys.None;
                            Program.a.kullanıcılarToolStripMenuItem.ShortcutKeys = Keys.None;
                            Program.a.poliklinikEklemeToolStripMenuItem.ShortcutKeys = Keys.None;
                        }
                        else
                        {
                            textBox1.Clear();
                            textBox2.Clear();
                            MessageBox.Show("Lütfen Kullanıcı Adı ve Şifrenizi Yeniden Giriniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum unuttum = new SifremiUnuttum();
            unuttum.Show();
        }

        private void LoginSayfası_Load(object sender, EventArgs e)
        {
            try
            {
                Program.a.poliklinikEklemeToolStripMenuItem.ShortcutKeys = Keys.None;       //KISAYOL DEVREDIŞI BIRAKMA !
                Program.a.kullanıcıEklemeToolStripMenuItem.ShortcutKeys = Keys.None;
                Program.a.kullanıcılarToolStripMenuItem.ShortcutKeys = Keys.None;
                Program.a.raporlamaToolStripMenuItem.ShortcutKeys = Keys.None;
                Program.a.randevuluHastalarToolStripMenuItem.ShortcutKeys = Keys.None;
                Program.a.hastaKayıtToolStripMenuItem.ShortcutKeys = Keys.None;
                Program.a.hastaVeriBulToolStripMenuItem.ShortcutKeys = Keys.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}