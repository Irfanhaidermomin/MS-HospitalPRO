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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }
        public static LoginSayfası frm2;
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            frm2 = new LoginSayfası();
            frm2.MdiParent = this;
            frm2.Show();

            // Buraya eğer user kullanıcı girerse Kullanıcıekleme menustriptini false yapacağız !!
        }
        private void çıkışToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();   
            }
        }
        // Burası Logout kısmı
        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                }
                menuStrip1.Enabled = false;
                frm2 = new LoginSayfası();
                frm2.MdiParent = this;
                frm2.Show();
                frm2.textBox1.Focus();
            }
        }
        public static PoliklinkEkleme poliklink;
        private void poliklinikEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            poliklink = new PoliklinkEkleme();
            poliklink.MdiParent = this;
            // poliklink.Close();
            poliklink.Show();
        }
        public static KullanıcıEkleme kullanıcı;
        private void kullanıcıEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            kullanıcı = new KullanıcıEkleme();
            kullanıcı.MdiParent = this;
            kullanıcı.Show();
        }
        public static HastaKayıt Kayıt;
        private void hastaKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Kayıt = new HastaKayıt();
            Kayıt.MdiParent = this;
            Kayıt.Show();
        }
        public static Kullanıcılar kullanıcılar;
        private void kullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            kullanıcılar = new Kullanıcılar();
            kullanıcılar.MdiParent=this;
            kullanıcılar.Show();*/
        }
        public static Poliklinikler poliklinikler;
        private void polikliniklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            poliklinikler = new Poliklinikler();
            poliklinikler.MdiParent = this;
            poliklinikler.Show();
        }
        public static Ücret_Raporlama rapor;
        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)//  ÜCRET RAPORLAMA
        {

            // MDİContainer dısşında bağımsız bi form olarakta yapabilirsin !

            /*foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            rapor = new Raporlama();
            rapor.MdiParent = this;
            rapor.Show();*/
            rapor = new Ücret_Raporlama();
            rapor.ShowDialog();
        }

        private void kullanıcıBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //      BURADA KULLANICILAR FORMUNU GRUPLUYORSUN !!   EKSİK TAMAMLAAAA . . . .
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            kullanıcılar = new Kullanıcılar();
            kullanıcılar.MdiParent = this;

            //kullanıcılar.listView1.Columns[0].Width = 0;  //  BU KOD GENİŞLİĞİ AYARLIYOR
            //kullanıcılar.listView1.Columns[14].Dispose();    //  BU KOD İSE VERDĞİN İNDEX NUMARASINDAKİ KOLONU LİSTVİEWDEN ATIYOR.

            kullanıcılar.listView1.ColumnWidthChanging+=listView1_ColumnWidthChanging;  //Bu kod sayesinde aşağıdaki kullanıcılar formundaki listview1'in kolon olay metodu belirdi !
            kullanıcılar.listView1.Scrollable = false; // listview kaydırma kodu !

            kullanıcılar.Text = "< Kullanıcı Bilgileri >";

            kullanıcılar.Show();
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = kullanıcılar.listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void kullanıcıHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            kullanıcılar = new Kullanıcılar();
            kullanıcılar.MdiParent = this;

            kullanıcılar.listView1.Columns[0].Width = 0;
            kullanıcılar.listView1.Columns[3].Width = 0;
            kullanıcılar.listView1.Columns[4].Width = 0;            //      For Döngüsü çalışmadığından böyle yaptım    //
            kullanıcılar.listView1.Columns[5].Width = 0;
            kullanıcılar.listView1.Columns[6].Width = 0;
            kullanıcılar.listView1.Columns[7].Width = 0;
            kullanıcılar.listView1.Columns[8].Width = 0;
            kullanıcılar.listView1.Columns[9].Width = 0;
            kullanıcılar.listView1.Columns[10].Width = 0;
            kullanıcılar.listView1.Columns[11].Width = 0;
            kullanıcılar.listView1.Columns[15].Width = 0;
            kullanıcılar.listView1.Columns[19].Width = 0;

            kullanıcılar.listView1.ColumnWidthChanging+=listView1_ColumnWidthChanging;
            kullanıcılar.listView1.Scrollable = false;

            kullanıcılar.Text = "< Kullanıcı Hakkında >";

            kullanıcılar.Show();
        }

        private void kullanıcıAdresBilgileriToolStripMenuItem_Click(object sender, EventArgs e) // KullanıcıİletişimBilgileri
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            kullanıcılar = new Kullanıcılar();
            kullanıcılar.MdiParent = this;

            kullanıcılar.listView1.Columns[0].Width = 0;
            kullanıcılar.listView1.Columns[3].Width = 0;
            kullanıcılar.listView1.Columns[4].Width = 0;
            kullanıcılar.listView1.Columns[5].Width = 0;
            kullanıcılar.listView1.Columns[6].Width = 0;
            kullanıcılar.listView1.Columns[9].Width = 0;
            kullanıcılar.listView1.Columns[10].Width = 0;
            kullanıcılar.listView1.Columns[11].Width = 0;
            kullanıcılar.listView1.Columns[12].Width = 0;
            kullanıcılar.listView1.Columns[13].Width = 0;
            kullanıcılar.listView1.Columns[14].Width = 0;
            kullanıcılar.listView1.Columns[15].Width = 0;
            kullanıcılar.listView1.Columns[16].Width = 0;
            kullanıcılar.listView1.Columns[17].Width = 0;
            kullanıcılar.listView1.Columns[18].Width = 0;

            kullanıcılar.listView1.ColumnWidthChanging += listView1_ColumnWidthChanging;
            kullanıcılar.listView1.Scrollable = false;

            kullanıcılar.Text = "< Kullanıcı İletişim >";

            kullanıcılar.Show();
        }

        private void kullanıcıKişiselBilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            kullanıcılar = new Kullanıcılar();
            kullanıcılar.MdiParent = this;

            kullanıcılar.listView1.Columns[3].Width = 0;
            kullanıcılar.listView1.Columns[4].Width = 0;
            kullanıcılar.listView1.Columns[5].Width = 0;
            kullanıcılar.listView1.Columns[6].Width = 0;
            kullanıcılar.listView1.Columns[12].Width = 0;
            kullanıcılar.listView1.Columns[13].Width = 0;
            kullanıcılar.listView1.Columns[14].Width = 0;
            kullanıcılar.listView1.Columns[15].Width = 0;
            kullanıcılar.listView1.Columns[16].Width = 0;
            kullanıcılar.listView1.Columns[17].Width = 0;
            kullanıcılar.listView1.Columns[18].Width = 0;
            kullanıcılar.listView1.Columns[19].Width = 0;

            kullanıcılar.listView1.ColumnWidthChanging += listView1_ColumnWidthChanging;
            kullanıcılar.listView1.Scrollable = false;

            kullanıcılar.Text = "< Kullanıcı Kişisel Bilgi >";
            
            kullanıcılar.Show();
        }
        public static DoktorEkleme Doktor_Ekle;
        private void doktorEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Doktor_Ekle = new DoktorEkleme();
            Doktor_Ekle.MdiParent = this;

            Doktor_Ekle.Show();
        }
        private void kayıtlıHastaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public static HastaBul Bul;

        public static Gecmis_Hastalar gecmiş_Hasta;
        private void geçmişKayıtlıHastalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            gecmiş_Hasta = new Gecmis_Hastalar();
            gecmiş_Hasta.MdiParent = this;
            

            /*Bul.button1.Visible = false;
            Bul.button3.Visible = false;*/

            gecmiş_Hasta.Text = "< Geçmiş Kayıtlı Hasta >";

            //Bul.veriler_Gecmiskayitli();

            gecmiş_Hasta.Show();
        }

        private void hastaRandevuBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Bul = new HastaBul();
            Bul.MdiParent = this;


            Bul.button2.Visible = false;
            Bul.button3.Visible = false;

            Bul.listView2.Columns[6].Width = 0;
            Bul.listView2.Columns[7].Width = 0;
            Bul.listView2.Columns[8].Width = 0;
            Bul.listView2.Columns[9].Width = 0;
            Bul.listView2.Columns[10].Width = 0;
            Bul.listView2.Columns[11].Width = 0;

            Bul.listView2.ColumnWidthChanging+=listView2_ColumnWidthChanging;
            Bul.listView2.Scrollable = false;

            Bul.Text = "< Kayıtlı Hasta (Hasta Randevu Bilgileri) >";

            Bul.Show();
        }

        private void listView2_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = Bul.listView2.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void hastaHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Bul = new HastaBul();
            Bul.MdiParent = this;


            Bul.button2.Visible = false;
            Bul.button3.Visible = false;

            Bul.listView2.Columns[1].Width = 0;
            Bul.listView2.Columns[2].Width = 0;
            Bul.listView2.Columns[3].Width = 0;
            //Bul.listView2.Columns[4].Width = 0;

            
            Bul.listView2.Scrollable = false;

            Bul.Text = "< Kayıtlı Hasta (Hasta Hakkında) >";

            Bul.Show();
        }

        public static Geçmiş_Rapor rpr;
        private void rAPORToolStripMenuItem_Click(object sender, EventArgs e)// GEÇMİŞ RAPORLAMA
        {
            rpr = new Geçmiş_Rapor();
            rpr.ShowDialog();
        }

        public static Doktorlar doktor;
        private void doktorlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            doktor = new Doktorlar();
            doktor.MdiParent = this;

            doktor.Show();
        }

        private void veriTabanıYedekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(saveFileDialog1.FileName))
                    {
                        System.IO.File.Delete(saveFileDialog1.FileName);
                    }
                    System.IO.File.Copy(Application.StartupPath.ToString() + "\\MyProject.mdb", saveFileDialog1.FileName);
                    MessageBox.Show("Yedek Alma İşlemi Tamamlandı !", "Yedek Alma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    else
	                {
                        MessageBox.Show("Yedek Alma İşlemi İptal Edildi !", "Yedek Alma", MessageBoxButtons.OK, MessageBoxIcon.Error);	                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void veriTabanıGeriYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.File.Exists(Application.StartupPath.ToString() + "\\MyProject.mdb"))
                    {
                        System.IO.File.Delete(Application.StartupPath.ToString() + "\\MyProject.mdb");
                    }
                    System.IO.File.Copy(openFileDialog1.FileName, Application.StartupPath.ToString() + "\\MyProject.mdb");
                    MessageBox.Show("Geri Yükleme Alma İşlemi Tamamlandı !", "Geri Yükleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Geri Yükleme Alma İşlemi İptal Edildi !", "Geri Yükleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void randevuluHastalarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Bul = new HastaBul();
            Bul.MdiParent = this;


            Bul.button1.Visible = false;
            Bul.button2.Visible = false;
            Bul.listView3.Visible = true;


            /*Bul.listView2.Columns[6].Width = 0;
            Bul.listView2.Columns[7].Width = 0;
            Bul.listView2.Columns[8].Width = 0;
            Bul.listView2.Columns[9].Width = 0;
            Bul.listView2.Columns[10].Width = 0;
            Bul.listView2.Columns[11].Width = 0;*/

            Bul.listView2.ColumnWidthChanging += listView2_ColumnWidthChanging;
            Bul.listView2.Scrollable = false;

            Bul.Text = "< Randevulu Hasta >";

            Bul.Show();
        }
    }
}
