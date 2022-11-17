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

        public static void addItem(ItemsModel i)
        {
            items.Add(i);
        }

        public static Label viewWishlist(ItemsModel i, int x, int y)
        {
            Label n = new Label();
            n.Location = new Point(x,y);
            n.AutoSize = true;
            n.Text = i.Name + "     Priority: " + i.Priority.ToString();
            return n;
        }

        public static List<ItemsModel> itemsArray()
        {
            return items;
        }
    }
}
