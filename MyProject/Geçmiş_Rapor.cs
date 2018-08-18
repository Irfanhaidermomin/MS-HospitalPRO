using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class Geçmiş_Rapor : Form
    {
        public Geçmiş_Rapor()
        {
            InitializeComponent();
        }

        private void Rapor_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'MyProjectDataSet.gecmis_kayitlihasta' table. You can move, or remove it, as needed.
                this.gecmis_kayitlihastaTableAdapter.Fill(this.MyProjectDataSet.gecmis_kayitlihasta);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
