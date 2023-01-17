using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopAid.Models
{
    public class WishList
    {
        public static List<ItemsModel> items = new List<ItemsModel>();

        public WishList()
        {

        }

        public static void setItems(List<ItemsModel> i)
        {
            items = i;
        }

        //adds an item to the items arraylist
        public static void addItem(ItemsModel i)
        {
            items.Insert(i.Priority - 1, i);
            setPriorities();
        }

        //method to delete an item, returns a success/fail message
        public static string deleteItem(string name)
        {
            //checks if item is in array
            foreach (ItemsModel i in items)
            {
                if (i.Name.Equals(name))
                {
                    items.Remove(i);
                    setPriorities();
                    return "Item deleted";
                }
            }

            //returns fail message
            return "Item not found";
        }

        //changes the priority of an item
        public static string changePriority(string name, int p)
        {
            //creates a temporary ItemsModel
            ItemsModel temp = null;

            //checks if item is in array
            foreach (ItemsModel i in items)
            {
                if (i.Name.Equals(name))
                {
                    temp = i;
                    items.Remove(i);
                    break;
                }
            }

            //checks if an item was assigned to the temporary ItemsModel
            if (temp != null)
            {
                int old = temp.Priority;
                temp.Priority = p;

                if (p <= items.Count)
                {
                    items.Insert((p - 1), temp);
                    setPriorities();

                    //returns success message
                    return "Priority changed.";
                }
                else
                {
                    temp.Priority = old;
                    items.Insert((old - 1), temp);
                }
            }
            
            //returns fail message
            return "Item not found or priority level not possible.";

        }

        public static bool checkBudget(double b)
        {
            if (b + sumPrices(items, items.Count) <= frmEdit.budget)
            {
                return true;
            }

            return false;
        }

        public static double sumPrices(List<ItemsModel> i, int n)
        {
            //recursive method to sum the prices of all items
            if (n < 1)
            {
                return 0;
            }
            else
            {
                return i[n - 1].Price + sumPrices(i, n - 1);
            }
        }

        //returns the items array
        public static List<ItemsModel> itemsArray()
        {
            return items;
        }

        //updates priorities each time a change is made to the arraylist
        public static void setPriorities()
        {
            for (int item = 0; item < items.Count; item++)
            {
                items[item].setPriority(item + 1);
            }

        }
    }
}
