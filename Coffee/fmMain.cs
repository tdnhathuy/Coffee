using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Coffee
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
            LoadTable();
            LoadCate();
        }
        #region Method

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
        }
        void LoadTable()
        {
            pnTable.Controls.Clear();

            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button()
                {
                    Width = 75,
                    Height = 75,
                    Text = item.Name + Environment.NewLine + item.Status

                };
                btn.Click += btn_Click;
                btn.Tag = item;
                if (item.Status == "Trống") { btn.BackColor = Color.Cornsilk; }
                else btn.BackColor = Color.Coral;
                pnTable.Controls.Add(btn);
            }
        }
        void LoadFood(int id)
        {
            pnFood.Controls.Clear();

            List<Food> tableFood = FoodDAO.Instance.GetFoodByCategoryID(id);

            foreach (Food item in tableFood)
            {
                Button btnFood = new Button()
                {
                    Width = 125,
                    Height = 70,
                    BackColor = Color.CadetBlue,
                    Text = item.Name + Environment.NewLine + item.Price
                };
                btnFood.MouseDown += (sender, args) =>
                {
                    LoadTable();
                    Table table = table = lsvBill.Tag as Table;
                    if (table == null) return;
                    int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
                    int foodID = ((sender as Button).Tag as Food).ID;
                    string foodName = ((sender as Button).Tag as Food).Name;


                    if (args.Button == MouseButtons.Left)
                    {
                        if (idBill == -1)
                        {
                            BillDAO.Instance.InsertBill(table.ID);
                            BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, 1);
                        }
                        else
                        {
                            BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, 1);
                        }
                        ShowBill(table.ID);
                    }
                    if (args.Button == MouseButtons.Right)
                    {
                        int count = 0;
                        foreach (ListViewItem i in lsvBill.Items)
                        {
                            if (i.Text.Contains(foodName))
                            {
                                count = Convert.ToInt32(i.SubItems[1].Text);
                            }
                        }
                    
                        if (count != 0)
                        {
                            if (idBill == -1)
                            {
                                BillDAO.Instance.InsertBill(table.ID);
                                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, -1);
                            }
                            else
                            {
                                BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, -1);
                            }
                            ShowBill(table.ID);
                        }
                    }
                };
                btnFood.Tag = item;
                pnFood.Controls.Add(btnFood);
            }
        }

        void LoadCate()
        {
            pnCate.Controls.Clear();
            List<Category> tableCate = CategoryDAO.Instance.GetListCategory();

            foreach (Category item in tableCate)
            {
                Button btnCate = new Button()
                {
                    Width = 80,
                    Height = 50,
                    BackColor = Color.BurlyWood,
                    Text = item.Name + Environment.NewLine

                };
                btnCate.Click += (sender, e) =>
                {
                    int tableCategory = ((sender as Button).Tag as Category).ID;
                    LoadFood(tableCategory);
                };
                btnCate.Tag = item;
                pnCate.Controls.Add(btnCate);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            int totalPrice = 0;
            foreach (DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += Convert.ToInt32(item.TotalPrice);
                lsvBill.Items.Add(lsvItem);
            }
            txbTotalPrice.Text = String.Format("{0:0,0 đ}", totalPrice);
        }
        #endregion

        #region Event
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
            lbTableName.Text = btn.Text.Split('\n')[0];
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null) return;
            int idBill = idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int totalPrice = 0;
            try
            {
                totalPrice = Convert.ToInt32(txbTotalPrice.Text.Split(',')[0]);
            }
            catch (Exception) { }

            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn có chắc thanh toán cho " + table.Name + "", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, table.ID, totalPrice * 1000);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }

        private void cửaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmManagement fm = new fmManagement();
            fm.ShowDialog();
        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAccount fm = new fmAccount();
            fm.ShowDialog();
        }

        #endregion





    }
}
