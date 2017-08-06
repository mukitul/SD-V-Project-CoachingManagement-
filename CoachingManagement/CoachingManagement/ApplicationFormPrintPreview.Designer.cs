namespace CoachingManagement
{
    partial class ApplicationFormPrintPreview
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.coachingmanagementDataSet = new CoachingManagement.coachingmanagementDataSet();
            this.StudentResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StudentResultTableAdapter = new CoachingManagement.coachingmanagementDataSetTableAdapters.StudentResultTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.coachingmanagementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.StudentResultBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CoachingManagement.ApplicationForm.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(674, 687);
            this.reportViewer1.TabIndex = 0;
            // 
            // coachingmanagementDataSet
            // 
            this.coachingmanagementDataSet.DataSetName = "coachingmanagementDataSet";
            this.coachingmanagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StudentResultBindingSource
            // 
            this.StudentResultBindingSource.DataMember = "StudentResult";
            this.StudentResultBindingSource.DataSource = this.coachingmanagementDataSet;
            // 
            // StudentResultTableAdapter
            // 
            this.StudentResultTableAdapter.ClearBeforeFill = true;
            // 
            // ApplicationFormPrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 687);
            this.Controls.Add(this.reportViewer1);
            this.MaximumSize = new System.Drawing.Size(690, 726);
            this.Name = "ApplicationFormPrintPreview";
            this.Text = "ApplicationFormPrintPreview";
            this.Load += new System.EventHandler(this.ApplicationFormPrintPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coachingmanagementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StudentResultBindingSource;
        private coachingmanagementDataSet coachingmanagementDataSet;
        private coachingmanagementDataSetTableAdapters.StudentResultTableAdapter StudentResultTableAdapter;
    }
}