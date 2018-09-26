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
    public partial class fmChangeMoney : Form
    {
        private int changeMoney;
        private int idBill;

        public fmChangeMoney(int idBill, int change)
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.changeMoney = change;
            this.idBill = idBill;

            lbChange.Text = change.ToString();
        }

        public int Change { get => changeMoney; set => changeMoney = value; }
        public int IdBill { get => idBill; set => idBill = value; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPrintRecipe_Click(object sender, EventArgs e)
        {
            fmRecipe fm = new fmRecipe(idBill);
            fm.ShowDialog();
        }
    }
}
