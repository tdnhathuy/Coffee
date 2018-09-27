namespace Coffee
{
    partial class fmRecipe
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
            this.rpRecipe = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DSRecipe = new Coffee.DSRecipe();
            this.USP_RecipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_RecipeTableAdapter = new Coffee.DSRecipeTableAdapters.USP_RecipeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DSRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_RecipeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpRecipe
            // 
            this.rpRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSRecipe";
            reportDataSource1.Value = this.USP_RecipeBindingSource;
            this.rpRecipe.LocalReport.DataSources.Add(reportDataSource1);
            this.rpRecipe.LocalReport.ReportEmbeddedResource = "Coffee.Recipe.rdlc";
            this.rpRecipe.Location = new System.Drawing.Point(0, 0);
            this.rpRecipe.Name = "rpRecipe";
            this.rpRecipe.ServerReport.BearerToken = null;
            this.rpRecipe.Size = new System.Drawing.Size(800, 450);
            this.rpRecipe.TabIndex = 0;
            // 
            // DSRecipe
            // 
            this.DSRecipe.DataSetName = "DSRecipe";
            this.DSRecipe.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_RecipeBindingSource
            // 
            this.USP_RecipeBindingSource.DataMember = "USP_Recipe";
            this.USP_RecipeBindingSource.DataSource = this.DSRecipe;
            // 
            // USP_RecipeTableAdapter
            // 
            this.USP_RecipeTableAdapter.ClearBeforeFill = true;
            // 
            // fmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpRecipe);
            this.Name = "fmRecipe";
            this.Text = "fmRecipe";
            this.Load += new System.EventHandler(this.fmRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_RecipeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpRecipe;
        private System.Windows.Forms.BindingSource USP_RecipeBindingSource;
        private DSRecipe DSRecipe;
        private DSRecipeTableAdapters.USP_RecipeTableAdapter USP_RecipeTableAdapter;
    }
}