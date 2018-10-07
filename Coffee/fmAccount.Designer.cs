namespace Coffee
{
    partial class fmAccount
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
            this.dtgvAccount = new System.Windows.Forms.DataGridView();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbDisplayname = new System.Windows.Forms.TextBox();
            this.btnAcountAdd = new System.Windows.Forms.Button();
            this.btnAccountEdit = new System.Windows.Forms.Button();
            this.btnAccountDel = new System.Windows.Forms.Button();
            this.rdbStaff = new System.Windows.Forms.RadioButton();
            this.rdbManager = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvAccount
            // 
            this.dtgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvAccount.Location = new System.Drawing.Point(0, 217);
            this.dtgvAccount.Name = "dtgvAccount";
            this.dtgvAccount.ReadOnly = true;
            this.dtgvAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvAccount.Size = new System.Drawing.Size(693, 287);
            this.dtgvAccount.TabIndex = 0;
            this.dtgvAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvAccount_CellClick);
            // 
            // txbUsername
            // 
            this.txbUsername.Enabled = false;
            this.txbUsername.Location = new System.Drawing.Point(187, 12);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(320, 46);
            this.txbUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên hiển thị";
            // 
            // txbPassword
            // 
            this.txbPassword.Enabled = false;
            this.txbPassword.Location = new System.Drawing.Point(187, 64);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(320, 46);
            this.txbPassword.TabIndex = 5;
            // 
            // txbDisplayname
            // 
            this.txbDisplayname.Enabled = false;
            this.txbDisplayname.Location = new System.Drawing.Point(187, 116);
            this.txbDisplayname.Name = "txbDisplayname";
            this.txbDisplayname.Size = new System.Drawing.Size(320, 46);
            this.txbDisplayname.TabIndex = 6;
            // 
            // btnAcountAdd
            // 
            this.btnAcountAdd.Location = new System.Drawing.Point(528, 14);
            this.btnAcountAdd.Name = "btnAcountAdd";
            this.btnAcountAdd.Size = new System.Drawing.Size(150, 45);
            this.btnAcountAdd.TabIndex = 7;
            this.btnAcountAdd.Text = "Thêm";
            this.btnAcountAdd.UseVisualStyleBackColor = true;
            this.btnAcountAdd.Click += new System.EventHandler(this.btnAcountAdd_Click);
            // 
            // btnAccountEdit
            // 
            this.btnAccountEdit.Location = new System.Drawing.Point(528, 65);
            this.btnAccountEdit.Name = "btnAccountEdit";
            this.btnAccountEdit.Size = new System.Drawing.Size(150, 45);
            this.btnAccountEdit.TabIndex = 8;
            this.btnAccountEdit.Text = "Sửa";
            this.btnAccountEdit.UseVisualStyleBackColor = true;
            this.btnAccountEdit.Click += new System.EventHandler(this.btnAccountEdit_Click);
            // 
            // btnAccountDel
            // 
            this.btnAccountDel.Location = new System.Drawing.Point(528, 117);
            this.btnAccountDel.Name = "btnAccountDel";
            this.btnAccountDel.Size = new System.Drawing.Size(150, 45);
            this.btnAccountDel.TabIndex = 9;
            this.btnAccountDel.Text = "Xóa";
            this.btnAccountDel.UseVisualStyleBackColor = true;
            this.btnAccountDel.Click += new System.EventHandler(this.btnAccountDel_Click);
            // 
            // rdbStaff
            // 
            this.rdbStaff.AutoSize = true;
            this.rdbStaff.Enabled = false;
            this.rdbStaff.Location = new System.Drawing.Point(334, 168);
            this.rdbStaff.Name = "rdbStaff";
            this.rdbStaff.Size = new System.Drawing.Size(173, 43);
            this.rdbStaff.TabIndex = 11;
            this.rdbStaff.TabStop = true;
            this.rdbStaff.Text = "Nhân viên";
            this.rdbStaff.UseVisualStyleBackColor = true;
            // 
            // rdbManager
            // 
            this.rdbManager.AutoSize = true;
            this.rdbManager.Enabled = false;
            this.rdbManager.Location = new System.Drawing.Point(187, 168);
            this.rdbManager.Name = "rdbManager";
            this.rdbManager.Size = new System.Drawing.Size(141, 43);
            this.rdbManager.TabIndex = 12;
            this.rdbManager.TabStop = true;
            this.rdbManager.Text = "Quản lý";
            this.rdbManager.UseVisualStyleBackColor = true;
            // 
            // fmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 504);
            this.Controls.Add(this.rdbManager);
            this.Controls.Add(this.rdbStaff);
            this.Controls.Add(this.btnAccountDel);
            this.Controls.Add(this.btnAccountEdit);
            this.Controls.Add(this.btnAcountAdd);
            this.Controls.Add(this.txbDisplayname);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbUsername);
            this.Controls.Add(this.dtgvAccount);
            this.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "fmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin các tài khoản";
            this.Load += new System.EventHandler(this.fmAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvAccount;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbDisplayname;
        private System.Windows.Forms.Button btnAcountAdd;
        private System.Windows.Forms.Button btnAccountEdit;
        private System.Windows.Forms.Button btnAccountDel;
        private System.Windows.Forms.RadioButton rdbStaff;
        private System.Windows.Forms.RadioButton rdbManager;
    }
}