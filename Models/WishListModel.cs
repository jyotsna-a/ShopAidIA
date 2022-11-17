using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopAid.Models
{
    public class WishListModel
    {
        public static List<ItemsModel> items = new List<ItemsModel>();

        public WishListModel()
        {

        }

        //adds an item to the items arraylist
        public static void addItem(ItemsModel i)
        {
            items.Insert(i.Priority, i);
        }

        //creates a label for an item
        public static Label viewWishlist(ItemsModel i, int x, int y)
        {
            Label n = new Label();
            n.Location = new Point(x,y);
            n.AutoSize = true;
            n.Text = i.Name + "     Priority: " + i.Priority.ToString();
            return n;
        }

        //returns the items array
        public static List<ItemsModel> itemsArray()
        {
            return items;
        }
    }
}
