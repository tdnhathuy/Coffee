using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee
{
    public partial class fmAccount : Form
    {
        public fmAccount()
        {
            InitializeComponent();
            rdbManager.Select();
        }

        private void fmAccount_Load(object sender, EventArgs e)
        {

            AddBinding();
        }

        void AddBinding()
        {
            dtgvAccount.DataSource = AccountDAO.Instance.GetListAccount();
            dtgvAccount.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvAccount.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvAccount.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            txbUsername.DataBindings.Clear();
            txbDisplayname.DataBindings.Clear();

            txbUsername.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Tài khoản", true, DataSourceUpdateMode.Never));
            txbDisplayname.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Tên hiển thị", true, DataSourceUpdateMode.Never));
        }

        private void btnAcountAdd_Click(object sender, EventArgs e)
        {
            if (txbUsername.Enabled == false && txbPassword.Enabled == false && txbDisplayname.Enabled == false)
            {
                txbUsername.Enabled = true;
                txbPassword.Enabled = true;
                txbDisplayname.Enabled = true;
            }
            else
            {

                txbUsername.Enabled = false;
                txbPassword.Enabled = false;
                txbDisplayname.Enabled = false;
                try
                {
                    AccountDAO.Instance.InsertAccount(txbUsername.Text, txbDisplayname.Text, txbPassword.Text, 0);
                    MessageBox.Show("Thêm thành công !!!");
                }
                catch (Exception) { MessageBox.Show("Có lỗi !!!"); }
                dtgvAccount.DataSource = AccountDAO.Instance.GetListAccount();
            }
        }

        private void btnAccountEdit_Click(object sender, EventArgs e)
        {
            if (txbUsername.Enabled == false && txbPassword.Enabled == false && txbDisplayname.Enabled == false)
            {
                txbUsername.Enabled = true;
                txbPassword.Enabled = true;
                txbDisplayname.Enabled = true;
            }
            else
            {
                txbUsername.Enabled = false;
                txbPassword.Enabled = false;
                txbDisplayname.Enabled = false;
                try
                {
                    AccountDAO.Instance.UpdateAccount(txbUsername.Text, txbDisplayname.Text, txbPassword.Text);
                    MessageBox.Show("Sửa thành công !!!");
                }
                catch (Exception) { MessageBox.Show("Có lỗi !!!"); }
                AddBinding();
            }
        }

        private void btnAccountDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa tài khoản " + txbUsername.Text, "Xác nhận xóa", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    txbUsername.Enabled = false;
                    txbPassword.Enabled = false;
                    txbDisplayname.Enabled = false;
                    AccountDAO.Instance.DeleteAccount(txbUsername.Text);
                    MessageBox.Show("Xóa thành công !", "Thông báo !");
                    AddBinding();
                }
                catch (Exception) { MessageBox.Show("Có lỗi xảy ra !", "Lỗi"); }
            }
        }

        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbUsername.Enabled = false;
            txbPassword.Enabled = false;
            txbDisplayname.Enabled = false;
            if (dtgvAccount.CurrentRow.Cells[2].Value.ToString() == "Quản lý") rdbManager.Select();
            else rdbStaff.Select();
        }
    }
}
