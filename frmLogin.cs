using ShopAid.Models;
using ShopAid.Processes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopAid
{
    public partial class frmLogin : Form
    {
        public static int ID = 0;
        List<CredentialsModel> credentials = new List<CredentialsModel>();
        List<ItemsModel> loadedItems = new List<ItemsModel>();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.SetControls();

            credentials = CredentialsModel.GetCredentials();
        }

        private void SetControls()
        {
            //Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        //threads to homepage
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidLogin())
            {
                DialogResult dr = MessageBox.Show(this, "Would you like to register?", TitlesModel.MessageBoxTitle,
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    ID = CredentialsModel.EditCredentials(this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim());
                }
                else
                {
                    return;
                }
            }   


            this.Close();
            Thread t = new Thread(new ThreadStart(ThreadHome));
            t.Start();
        }

        public static int getID()
        {
            return ID;
        }

        private void ThreadHome()
        {
            //RUNs a NEW application with the desired form
            Application.Run(new frmHome(ID, credentials));
        }

        private bool ValidLogin()
        {
            //LINQ
            var result = (from r in credentials
                          where r.UserName == this.txtUsername.Text.Trim() &&
                                r.Password == this.txtPassword.Text.Trim()
                          select r).ToArray();

            if (result.Count() == 0)
            {
                MessageBox.Show(this, "Login Failed. Username and/or Password is incorrect!", TitlesModel.MessageBoxTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ID = result[0].ID;
            loadedItems = WishListModel.GetWishList(ID);
            WishList.setItems(loadedItems);

            return true;
        }
    }
}
