namespace MyProject
{
    partial class Ücret_Raporlama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ücretBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ücretDataSet = new MyProject.ücretDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ücretTableAdapter = new MyProject.ücretDataSetTableAdapters.ücretTableAdapter();
            this.MyProjectDataSet = new MyProject.MyProjectDataSet();
            this.gecmis_kayitlihastaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gecmis_kayitlihastaTableAdapter = new MyProject.MyProjectDataSetTableAdapters.gecmis_kayitlihastaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ücretBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ücretDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyProjectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gecmis_kayitlihastaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ücretBindingSource
            // 
            this.ücretBindingSource.DataMember = "ücret";
            this.ücretBindingSource.DataSource = this.ücretDataSet;
            // 
            // ücretDataSet
            // 
            this.ücretDataSet.DataSetName = "ücretDataSet";
            this.ücretDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ücretBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyProject.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(645, 610);
            this.reportViewer1.TabIndex = 0;
            // 
            // ücretTableAdapter
            // 
            this.ücretTableAdapter.ClearBeforeFill = true;
            // 
            // MyProjectDataSet
            // 
            this.MyProjectDataSet.DataSetName = "MyProjectDataSet";
            this.MyProjectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gecmis_kayitlihastaBindingSource
            // 
            this.gecmis_kayitlihastaBindingSource.DataMember = "gecmis_kayitlihasta";
            this.gecmis_kayitlihastaBindingSource.DataSource = this.MyProjectDataSet;
            // 
            // gecmis_kayitlihastaTableAdapter
            // 
            this.gecmis_kayitlihastaTableAdapter.ClearBeforeFill = true;
            // 
            // Ücret_Raporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 610);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "Ücret_Raporlama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "< Ücret Raporlama >";
            this.Load += new System.EventHandler(this.Raporlama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ücretBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ücretDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyProjectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gecmis_kayitlihastaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ücretBindingSource;
        private ücretDataSet ücretDataSet;
        private ücretDataSetTableAdapters.ücretTableAdapter ücretTableAdapter;
        private System.Windows.Forms.BindingSource gecmis_kayitlihastaBindingSource;
        private MyProjectDataSet MyProjectDataSet;
        private MyProjectDataSetTableAdapters.gecmis_kayitlihastaTableAdapter gecmis_kayitlihastaTableAdapter;
    }
}