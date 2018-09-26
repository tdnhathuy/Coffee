using DAO;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee
{
    public partial class fmCash : Form
    {
        private int idBill;
        private int idTable;
        private int totalPrice;
        private string tableName;

        string t;

        public int IdBill { get => idBill; set => idBill = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string TableName { get => tableName; set => tableName = value; }

        public fmCash(int idBill, int idTable, int totalPrice, string tableName)
        {
            InitializeComponent();

            this.idBill = idBill;
            this.idTable = idTable;
            this.totalPrice = totalPrice;
            txbTotalPrice.Text = totalPrice.ToString();
            this.tableName = tableName;

            this.Text = "Thanh toán bàn " + tableName;

            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaximizeBox = false;

            Button btn = null;
            int size = 60;
            for (int i = 7; i <= 9; i++)
            {
                btn = new Button { Width = size, Height = size, Text = i + "", BackColor = Color.Aqua };
                btn.Click += (sender, args) =>
                {
                    t += (sender as Button).Text;
                    txbSubTotal.Text = t;
                };
                pnPad.Controls.Add(btn);
            }
            for (int i = 4; i <= 6; i++)
            {
                btn = new Button { Width = size, Height = size, Text = i + "", BackColor = Color.Aqua };
                btn.Click += (sender, args) =>
                {
                    t += (sender as Button).Text;
                    txbSubTotal.Text = t;
                };
                pnPad.Controls.Add(btn);
            }
            for (int i = 1; i <= 3; i++)
            {
                btn = new Button { Width = size, Height = size, Text = i + "", BackColor = Color.Aqua };
                btn.Click += (sender, args) =>
                {
                    t += (sender as Button).Text;
                    txbSubTotal.Text = t;
                };
                pnPad.Controls.Add(btn);
            }
            for (int i = 1; i <= 3; i++)
            {
                if (i == 1) btn = new Button { Width = size, Height = size, Text = "0", BackColor = Color.Aqua }; pnPad.Controls.Add(btn);
                if (i == 2) btn = new Button { Width = size, Height = size, Text = "000", BackColor = Color.Aqua }; pnPad.Controls.Add(btn);
                if (i == 3) btn = new Button { Width = size, Height = size, Text = "AC", BackColor = Color.Aqua }; pnPad.Controls.Add(btn);
                btn.Click += (sender, args) =>
                {
                    t += (sender as Button).Text;
                    if (t.EndsWith("AC"))
                    {
                        txbSubTotal.Text = "";
                        t = "";
                        return;
                    }
                    txbSubTotal.Text = t;
                };
            }
            txbSubTotal.Focus();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            txbSubTotal.Focus();
            int total = Convert.ToInt32(txbTotalPrice.Text);
            int subTotal = Convert.ToInt32(txbSubTotal.Text);
            int change = subTotal - total; //tiền thừa

            if (change < 0)
            {
                MessageBox.Show("Nhận tiền chưa đủ", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc thanh toán cho " + tableName + "", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (change >= 0)
                {
                    BillDAO.Instance.CheckOut(idBill, IdTable, TotalPrice);
                    fmChangeMoney fm = new fmChangeMoney(idBill, change);
                    fm.ShowDialog();
                    this.Dispose();
                }
            }
        }
    }
}
