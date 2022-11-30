﻿using ShopAid.Models;
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
    public partial class frmDelete : Form
    {
        public List<ItemsModel> items { get; set; }

        public frmDelete()
        {
            InitializeComponent();
        }

        private void frmDelete_Load(object sender, EventArgs e)
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

        // validates item and calls delete method in WishListModel
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateItems())
                return;

            //creates string for name using user input
            string name = this.txtName.Text.Trim();

            //deletes item and returns success/failure message
            string msg = WishListModel.deleteItem(name);
            MessageBox.Show(this, msg, TitlesModel.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidateItems()
        {
            //Validate Name is entered
            if (String.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBox.Show(this, "Item MUST have a name!", TitlesModel.MessageBoxTitle,
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
    }
}
