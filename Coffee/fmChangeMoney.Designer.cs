namespace Coffee
{
    partial class fmChangeMoney
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbChange = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnPrintRecipe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiền thừa: ";
            // 
            // lbChange
            // 
            this.lbChange.AutoSize = true;
            this.lbChange.Location = new System.Drawing.Point(228, 9);
            this.lbChange.Name = "lbChange";
            this.lbChange.Size = new System.Drawing.Size(29, 33);
            this.lbChange.TabIndex = 1;
            this.lbChange.Text = "0";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(125, 68);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(125, 60);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnPrintRecipe
            // 
            this.btnPrintRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintRecipe.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintRecipe.Location = new System.Drawing.Point(256, 68);
            this.btnPrintRecipe.Name = "btnPrintRecipe";
            this.btnPrintRecipe.Size = new System.Drawing.Size(125, 60);
            this.btnPrintRecipe.TabIndex = 3;
            this.btnPrintRecipe.Text = "In hóa đơn";
            this.btnPrintRecipe.UseVisualStyleBackColor = true;
            this.btnPrintRecipe.Click += new System.EventHandler(this.btnPrintRecipe_Click);
            // 
            // fmChangeMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 131);
            this.Controls.Add(this.btnPrintRecipe);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbChange);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "fmChangeMoney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmRecipe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbChange;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnPrintRecipe;
    }
}