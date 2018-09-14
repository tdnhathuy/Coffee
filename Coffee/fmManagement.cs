﻿using DAO;
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
    public partial class fmManagement : Form
    {
        BindingSource listBill = new BindingSource();
        BindingSource listCategory = new BindingSource();
        BindingSource listFood = new BindingSource();
        BindingSource listTable = new BindingSource();

        public fmManagement()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0: Tab0(); break;
                case 1: Tab1(); break;
                case 2: Tab2(); break;
                case 3: Tab3(); break;
                case 4: Tab4(); break;
            }
            try { AddBindingData(); } catch (Exception ex) { }
        }


        #region Methods
        private void LoadBill(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
            dtgvBill.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvBill.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvBill.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvBill.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvBill.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvBill.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvBill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Statistical(DateTime checkIn, DateTime checkOut)
        {
            //Tổng số hóa đơn
            lbInvoice.Text = BillDAO.Instance.GetAllInvoice(checkIn, checkOut).ToString();

            //Hóa đơn lớn nhất
            lbMostValue.Text = BillDAO.Instance.GetMostValueInvoice(checkIn, checkOut).ToString();

            //Hốa đơn nhỏ nhất
            lbLeastValue.Text = BillDAO.Instance.GetLeastValueInvoice(checkIn, checkOut).ToString();

            //Số hóa đơn hơn 200k
            lbBigInvoice.Text = BillDAO.Instance.GetBigInvoice(checkIn, checkOut).ToString();

            //Tổng doanh thu
            lbRevenue.Text = BillDAO.Instance.GetRevenue(checkIn, checkOut).ToString();
        }

        private void AddBindingData()
        {
            dtgvCategory.DataSource = listCategory;
            dtgvFood.DataSource = listFood;

            listCategory.DataSource = CategoryDAO.Instance.LoadCategory();
            listFood.DataSource = FoodDAO.Instance.LoadFood();

            txbCateID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbCateName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Tên", true, DataSourceUpdateMode.Never));

            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Tên", true, DataSourceUpdateMode.Never));
            cbbFoodCate.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Danh mục", true, DataSourceUpdateMode.Never));
            nbuFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Giá", true, DataSourceUpdateMode.Never));

            dtgvCategory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvFood.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvFood.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvFood.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvFood.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        #endregion

        #region Events
        private void btnShowBill_Click(object sender, EventArgs e)
        {
            LoadBill(dtpkFromDate.Value, dtpkToDate.Value);
            Statistical(dtpkFromDate.Value, dtpkToDate.Value);

            txbBillID.DataBindings.Clear();
            txbBillID.DataBindings.Add(new Binding("Text", dtgvBill.DataSource, "Số Hóa Đơn"));
        }

        private void fmManagement_Load(object sender, EventArgs e)
        {
            LoadBill(dtpkFromDate.Value, dtpkToDate.Value);
            Statistical(dtpkFromDate.Value, dtpkToDate.Value);

            txbBillID.DataBindings.Clear();
            txbBillID.DataBindings.Add(new Binding("Text", dtgvBill.DataSource, "Số Hóa Đơn"));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listFood.DataSource = FoodDAO.Instance.SearchFoodByName(txbSearch.Text);
        }

        private void txbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            listFood.DataSource = FoodDAO.Instance.SearchFoodByName(txbSearch.Text);
        }

        private void txbBillID_TextChanged(object sender, EventArgs e)
        {
            lsvFood.Items.Clear();

            string qr = string.Format("" +
                "SELECT c.name, b.count, FORMAT(b.count * c.price, '#,### VNĐ') " +
                "FROM Bill a, BillInfo b, Food c " +
                "WHERE a.id = b.idBill AND b.idFood = c.id AND a.id = " + txbBillID.Text);
            DataTable data = null;
            try
            {
                data = DataProvider.Instance.ExecuteQuery(qr);
            }
            catch (Exception) { }

            if (data == null) return;
            foreach (DataRow row in data.Rows)
            {
                ListViewItem lsvItem = new ListViewItem(row[0].ToString());
                lsvItem.SubItems.Add(row[1].ToString());
                lsvItem.SubItems.Add(row[2].ToString());
                lsvFood.Items.Add(lsvItem);
            }
        }

        #endregion

        #region Tab Controls
        void Tab0() { }
        void Tab1()
        {
            dtgvCategory.DataSource = CategoryDAO.Instance.LoadCategory();
            dtgvFood.DataSource = FoodDAO.Instance.LoadFood();
        }
        void Tab2()
        {
            dtgvTable.DataSource = TableDAO.Instance.LoadTable();
            dtgvTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvTable.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvTable.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            txbTableID.DataBindings.Clear();
            txbTableName.DataBindings.Clear();
            txbTableStatus.DataBindings.Clear();

            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Tên bàn", true, DataSourceUpdateMode.Never));
            txbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Trạng thái", true, DataSourceUpdateMode.Never));
        }
        void Tab3()
        {
            dtgvListFoodSold.DataSource = FoodDAO.Instance.GetListFoodSold(dtpkReportFrom.Value, dtpkReportTo.Value);

            dtgvListFoodSold.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvListFoodSold.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvListFoodSold.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvListFoodSold.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        void Tab4() { }


        #endregion

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            dtgvListFoodSold.DataSource = FoodDAO.Instance.GetListFoodSold(dtpkReportFrom.Value, dtpkReportTo.Value);

            dtgvListFoodSold.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvListFoodSold.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvListFoodSold.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvListFoodSold.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
        }
    }
}