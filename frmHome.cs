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
    public partial class frmHome : Form
    {
        int ID = 0;
        List<CredentialsModel> credentials;
        List<BudgetModel> budgets = new List<BudgetModel>();
        double actualBudget = 0;

        public frmHome()
        {
            InitializeComponent();
        }

        public frmHome(int id, List<CredentialsModel> c)
        {
            InitializeComponent();
            this.ID = id;
            this.credentials = c;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();
            frmEdit.budget = actualBudget;
            this.Controls.Add(frmEdit.createLabel());
        }

        private void SetControls()
        {
            //Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.BudgetData();
        }

        private void BudgetData()
        {
            //Budgets
            budgets = BudgetModel.GetBudgets();

            var b = (from c in budgets
                     where c.ID == ID
                     select c.Budget).ToArray();

            actualBudget = b[0];
        }

        //threads to add page
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t = new Thread(new ThreadStart(ThreadAdd));
            t.Start();
        }

        private void ThreadAdd()
        {
            //RUNs a NEW application with the desired form
            Application.Run(new frmAdd());
        }

        //threads to the delete page
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t = new Thread(new ThreadStart(ThreadDelete));
            t.Start();
        }

        private void ThreadDelete()
        {
            //runs a new form
            Application.Run(new frmDelete());
        }

        //threads to priority page
        private void btnPriority_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t = new Thread(new ThreadStart(ThreadPriority));
            t.Start();
        }

        private void ThreadPriority()
        {
            //RUNs a NEW application with the desired form
            Application.Run(new frmPriority());
        }

        //threads to view page
        private void btnView_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t = new Thread(new ThreadStart(ThreadView));
            t.Start();
        }

        private void ThreadView()
        {
            //RUNs a NEW application with the desired form
            Application.Run(new frmView());
        }

        //threads to edit page
        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread t = new Thread(new ThreadStart(ThreadEdit));
            t.Start();
        }

        private void ThreadEdit()
        {
            //RUNs a NEW application with the desired form
            Application.Run(new frmEdit());
        }
    }
}
