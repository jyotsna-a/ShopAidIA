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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //creates item using user input
            string name = this.txtName.Text.Trim();
            ItemsModel i = new ItemsModel(name);

            //deletes item
            WishListModel.deleteItem(i);
            MessageBox.Show(this, "Item added.", TitlesModel.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
