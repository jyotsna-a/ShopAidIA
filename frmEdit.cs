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
        public static double budget = 0;
        public static Label lblBudget { get; set; }
        public frmEdit()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateItems())
                return;
            MessageBox.Show(this, "Budget updated.", TitlesModel.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            lblBudget = new Label();
            lblBudget.Location = new Point(65, 150);
            lblBudget.AutoSize = true;
            Font template = new Font("Microsoft Sans Serif", 50);
            lblBudget.Font = template;
            lblBudget.Text = "$" + budget.ToString();
        }

        private bool ValidateItems()
        {
            //validate Price is numeric
            bool passed = false;

            passed = double.TryParse(this.txtNew.Text.Trim(), out budget);

            if (!passed)
            {
                MessageBox.Show(this, "Price MUST be numeric!", TitlesModel.MessageBoxTitle,
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
