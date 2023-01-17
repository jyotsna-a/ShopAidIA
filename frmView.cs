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
        //public List<WishListModel> wishlist = new List<WishListModel>();


        public frmView()
        {
            InitializeComponent();
        }

        //prints the label for each item in items
        private void frmView_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();
            items = WishList.itemsArray();
            dgWishlist.Columns.Add("Name", "Name");
            dgWishlist.Columns.Add("Price", "Price");
            dgWishlist.Columns.Add("Priority", "Priority");

            foreach (ItemsModel i in items)
            {
                Object[] row = new Object[] { i.Name, i.Price, i.Priority };
                dgWishlist.Rows.Add(row);
            }
            //this.GetWishList();
        }

        private void SetControls()
        {
            //Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /*private void GetWishList()
        {
            wishlist = WishListModel.GetWishList();

            this.SetWishList();
        }*/

        private void btnOrderPriority_Click(object sender, EventArgs e)
        {
            dgWishlist.Rows.Clear();
            items = WishList.itemsArray();

            //adds each item to the datagrid in the order of priority
            foreach (ItemsModel i in items)
            {
                Object[] row = new Object[] {i.Name, i.Price, i.Priority};
                dgWishlist.Rows.Add(row);
            }
        }

        private void btnOrderPrice_Click(object sender, EventArgs e)
        {
            dgWishlist.Rows.Clear();
            List<ItemsModel> sortedItems = mergeSortPrice(WishList.itemsArray());

            foreach (ItemsModel i in sortedItems)
            {
                Object[] row = new Object[] { i.Name, i.Price, i.Priority };
                dgWishlist.Rows.Add(row);
            }
        }

        //recursive merge sort: https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-7.php#:~:text=Conceptually%2C%20a%20merge%20sort%20works,will%20be%20the%20sorted%20list.
        private List<ItemsModel> mergeSortPrice(List<ItemsModel> list)
        {
            if (list.Count <= 1)
                return list;

            List<ItemsModel> a = new List<ItemsModel>();
            List<ItemsModel> b = new List<ItemsModel>();

            int mid = list.Count / 2;
            a = list.GetRange(0, mid);
            b = list.GetRange(mid, (int)Math.Ceiling((double)list.Count / 2));
            
            a = mergeSortPrice(a);
            b = mergeSortPrice(b);

            return merge(a, b); ;
        }

        //merge two lists
        private List<ItemsModel> merge(List<ItemsModel> a, List<ItemsModel> b)
        {
            List<ItemsModel> merged = new List<ItemsModel>();

            while (a.Count > 0 || b.Count > 0)
            {
                if (a.Count > 0 && b.Count > 0)
                {
                    if (a[0].Price <= b[0].Price)
                    {
                        merged.Add(a[0]);
                        a.RemoveAt(0);
                    }
                    
                    merged.Add(b[0]);
                    b.RemoveAt(0);
                }
                else if (a.Count > 0)
                {
                    merged.Add(a[0]);
                    a.RemoveAt(0);
                }
                else
                {
                    merged.Add(b[0]);
                    b.RemoveAt(0);
                }
            }

            return merged;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure you want to delete?", TitlesModel.MessageBoxTitle,
                                              MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                int index = this.dgWishlist.SelectedRows[0].Index;

                this.PerformDelete(index);
            }
        }

        private void PerformDelete(int i)
        {
            string gName = dgWishlist.Rows[i].Cells[0].Value.ToString();
            double gPrice = (double)dgWishlist.Rows[i].Cells[1].Value;
            int gPriority = (int)dgWishlist.Rows[i].Cells[2].Value;

            items.RemoveAll(x => x.Name == gName && x.Price == gPrice && x.Priority == gPriority);

            //Messagebox delete successful

            //Modified WishList what happens to the Wishlist.txt file now?

            this.SetWishList();
        }

        private void SetWishList()
        {
            this.dgWishlist.DataSource = null;
            this.dgWishlist.DataSource = items;
        }
    }
}
