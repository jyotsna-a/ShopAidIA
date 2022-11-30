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
            setPriorities();
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

        //method to delete an item, returns a success/fail message
        public static string deleteItem(string name)
        {
            foreach (ItemsModel i in items)
            {
                if (i.Name.Equals(name))
                {
                    items.Remove(i);
                    setPriorities();
                    return "Item deleted";
                }
            }

            return "Item not found";
        }

        public static string changePriority(string name, int p)
        {
            ItemsModel temp = new ItemsModel();

            foreach (ItemsModel i in items)
            {
                if (i.Name.Equals(name))
                {
                    temp = i;
                    items.Remove(i);
                    break;
                }
            }

            return "Priority changed.";
        }

        //updates priorities each time a change is made to the arraylist
        public static void setPriorities()
        {
            for (int item = 0; item < items.Count; item++)
            {
                items[item].setPriority(item);
            }

        }
    }
}
