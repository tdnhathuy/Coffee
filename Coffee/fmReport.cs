using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee
{
    public partial class fmReport : Form
    {
        public fmReport()
        {
            InitializeComponent();
        }


        private void fmReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

        }
    }
}

