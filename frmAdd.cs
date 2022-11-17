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
    public partial class frmAdd : Form
    {
        public static List<ItemsModel> items = new List<ItemsModel>();
        double price = 0;

        public frmAdd()
        {
            InitializeComponent();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();
            frmDelete export = new frmDelete();
            export.items = items;
            export.Show();

            frmView export1 = new frmView();
            export1.items = items;
            export1.Show();
        }

        private void SetControls()
        {
            //Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateItems())
                return;

            items.Add(new ItemsModel()
            {
                Name = this.txtName.Text.Trim(),
                Price = price,
                Priority = (int)numPriority.Value
            });

            MessageBox.Show(this, "Item added", TitlesModel.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //validate Price is numeric
            bool passed = false;

            passed = double.TryParse(this.txtPrice.Text.Trim(), out price);

            if (!passed)
            {
                MessageBox.Show(this, "Price must be numeric!", TitlesModel.MessageBoxTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
