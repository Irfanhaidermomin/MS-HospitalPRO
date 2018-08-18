namespace MyProject
{
    partial class Geçmiş_Rapor
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
            this.gecmis_kayitlihastaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MyProjectDataSet = new MyProject.MyProjectDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gecmis_kayitlihastaTableAdapter = new MyProject.MyProjectDataSetTableAdapters.gecmis_kayitlihastaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gecmis_kayitlihastaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyProjectDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // gecmis_kayitlihastaBindingSource
            // 
            this.gecmis_kayitlihastaBindingSource.DataMember = "gecmis_kayitlihasta";
            this.gecmis_kayitlihastaBindingSource.DataSource = this.MyProjectDataSet;
            // 
            // MyProjectDataSet
            // 
            this.MyProjectDataSet.DataSetName = "MyProjectDataSet";
            this.MyProjectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.gecmis_kayitlihastaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyProject.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(632, 574);
            this.reportViewer1.TabIndex = 0;
            // 
            // gecmis_kayitlihastaTableAdapter
            // 
            this.gecmis_kayitlihastaTableAdapter.ClearBeforeFill = true;
            // 
            // Geçmiş_Rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 574);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "Geçmiş_Rapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "< Geçmiş Kayıtlı Hastalar >";
            this.Load += new System.EventHandler(this.Rapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gecmis_kayitlihastaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyProjectDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource gecmis_kayitlihastaBindingSource;
        private MyProjectDataSet MyProjectDataSet;
        private MyProjectDataSetTableAdapters.gecmis_kayitlihastaTableAdapter gecmis_kayitlihastaTableAdapter;
    }
}