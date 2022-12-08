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
    public partial class frmView : Form
    {
        public List<ItemsModel> items;

        public frmView()
        {
            InitializeComponent();
        }

        //prints the label for each item in items
        private void frmView_Load(object sender, EventArgs e)
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

        private void btnOrderPriority_Click(object sender, EventArgs e)
        {
            items = WishListModel.itemsArray();

            //adds each item to the datagrid in the order of priority
            foreach (ItemsModel i in items)
            {
                Object[] row = new Object[] {i.Name, i.Priority, i.Price};
                dgWishlist.Rows.Add(row);
            }
        }

        private void btnOrderPrice_Click(object sender, EventArgs e)
        {
            items = WishListModel.itemsArray();

        }
    }
}
