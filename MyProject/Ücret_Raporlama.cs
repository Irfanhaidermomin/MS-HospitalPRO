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
    public partial class Ücret_Raporlama : Form
    {
        public Ücret_Raporlama()
        {
            InitializeComponent();
        }

        private void Raporlama_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'MyProjectDataSet.gecmis_kayitlihasta' table. You can move, or remove it, as needed.
                this.gecmis_kayitlihastaTableAdapter.Fill(this.MyProjectDataSet.gecmis_kayitlihasta);
                // TODO: This line of code loads data into the 'ücretDataSet.ücret' table. You can move, or remove it, as needed.
                this.ücretTableAdapter.Fill(this.ücretDataSet.ücret);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
