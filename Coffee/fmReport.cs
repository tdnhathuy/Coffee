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
    public partial class fmReport : Form
    {
        private DateTime dateFrom;
        private DateTime dateTo;

        public DateTime DateFrom { get => dateFrom; set => dateFrom = value; }
        public DateTime DateTo { get => dateTo; set => dateTo = value; }

        public fmReport()
        {
            InitializeComponent();
        }

        public fmReport(DateTime dFrom, DateTime dTo)
        {
            InitializeComponent();
            dateFrom = dFrom;
            dateTo = dTo;
        }

        private void fmReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'CoffeeDataSet.USP_Report' table. You can move, or remove it, as needed.
            dateFrom = DateTime.Parse(DateFrom.ToShortDateString() + " 00:00:00");
            dateTo = DateTime.Parse(DateTo.ToShortDateString() + " 23:59:59");
            this.USP_ReportTableAdapter.Fill(this.CoffeeDataSet.USP_Report, dateFrom, dateTo);
            textBox1.Text = dateFrom.ToString();
            textBox2.Text = dateTo.ToString();
            this.rpViewer.RefreshReport();
        }
    }
}
