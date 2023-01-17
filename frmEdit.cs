using ShopAid.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopAid
{
    public partial class frmEdit : Form
    {
        int ID = 0;
        public static double budget { get; set; }

        public frmEdit()
        {
            InitializeComponent();
            ID = frmHome.getID();
        }

        //creates budget label to return to homepage
        public static Label createLabel()
        {
            Label lbl = new Label();
            lbl.Location = new Point(65, 130);
            lbl.AutoSize = true;
            Font template = new Font("Microsoft Sans Serif", 30);
            lbl.Font = template;
            lbl.Text = "$" + budget.ToString();
            return lbl;
        }

        //Updates the budget and label used in homepage
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //checks validation
            if (!ValidateItems())
                return;

            MessageBox.Show(this, "Budget updated.", TitlesModel.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private bool ValidateItems()
        {
            //validate Price is numeric
            bool passed = false;

            double temp = 0;
            double old = budget;

            passed = double.TryParse(this.txtNew.Text.Trim(), out temp);

            budget = temp;

            BudgetModel.EditBudgets(ID, old, budget);


            if (!passed)
            {
                MessageBox.Show(this, "Price MUST be numeric!", TitlesModel.MessageBoxTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //validates if budget is enough for current items
            if (!WishList.checkBudget(0))
            {
                MessageBox.Show(this, "Budget is too low for current wishlist. Please delete items.", TitlesModel.MessageBoxTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //closes the form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t = new Thread(new ThreadStart(ThreadHome));
            t.Start();
        }

        private void ThreadHome()
        {
            //RUNs a NEW application with the desired form
            Application.Run(new frmHome());
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();
        }

        private void SetControls()
        {
            //Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
