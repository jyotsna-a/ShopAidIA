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

        private List<ItemsModel> mergeSortPrice(List<ItemsModel> list)
        {

            return list;
        }

        private List<ItemsModel> merge(List<ItemsModel> a, List<ItemsModel> b)
        {
            List<ItemsModel> merged = new List<ItemsModel>();

            while (a.Count > 0 || b.Count > 0)
            {
                if (a.Count > 0 && b.Count > 0)
                {
                    if (a[1].Price < b[1].Price)
                    {
                        merged.Add(a[0]);
                        a.RemoveAt(0);
                    }
                        merged.Add(b[0]);
                }
                else if (a.Count > 0)
                {
                    merged.Add(a[0]);
                }
                else
                {
                    merged.Add(b[0]);
                }
            }
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
