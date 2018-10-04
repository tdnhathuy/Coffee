namespace Coffee
{
    partial class fmReport
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
            this.USP_ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CoffeeDataSet = new Coffee.DSReport();
            this.rpViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_ReportTableAdapter = new Coffee.CoffeeDataSetTableAdapters.USP_ReportTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.USP_ReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoffeeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_ReportBindingSource
            // 
            this.USP_ReportBindingSource.DataMember = "USP_Report";
            this.USP_ReportBindingSource.DataSource = this.CoffeeDataSet;
            // 
            // CoffeeDataSet
            // 
            this.CoffeeDataSet.DataSetName = "CoffeeDataSet";
            this.CoffeeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpViewer
            // 
            this.rpViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "DataSetReport";
            reportDataSource1.Value = this.USP_ReportBindingSource;
            this.rpViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rpViewer.LocalReport.ReportEmbeddedResource = "Coffee.ReportDaily.rdlc";
            this.rpViewer.Location = new System.Drawing.Point(0, 50);
            this.rpViewer.Name = "rpViewer";
            this.rpViewer.ServerReport.BearerToken = null;
            this.rpViewer.Size = new System.Drawing.Size(834, 400);
            this.rpViewer.TabIndex = 0;
            // 
            // USP_ReportTableAdapter
            // 
            this.USP_ReportTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(196, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(178, 20);
            this.textBox2.TabIndex = 2;
            // 
            // fmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rpViewer);
            this.Name = "fmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmReport";
            this.Load += new System.EventHandler(this.fmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_ReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoffeeDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpViewer;
        private System.Windows.Forms.BindingSource USP_ReportBindingSource;
        private DSReport CoffeeDataSet;
        private CoffeeDataSetTableAdapters.USP_ReportTableAdapter USP_ReportTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}