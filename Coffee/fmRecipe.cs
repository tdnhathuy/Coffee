﻿using Microsoft.Reporting.WinForms;
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
    public partial class fmRecipe : Form
    {
        private int idBill;
        public fmRecipe(int idBill)
        {
            InitializeComponent();
            this.idBill = idBill;
        }

        public int IdBill { get => idBill; set => idBill = value; }

        private void fmRecipe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'CoffeeRecipeDataSet.USP_Recipe' table. You can move, or remove it, as needed.

            this.USP_RecipeTableAdapter.Fill(this.CoffeeRecipeDataSet.USP_Recipe, idBill.ToString());

            ReportParameter pr = new ReportParameter("idBill", idBill.ToString(), false);
            this.rpRecipe.LocalReport.SetParameters(pr);

            this.rpRecipe.RefreshReport();
        }
    }
}
