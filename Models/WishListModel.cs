using ShopAid.Processes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAid.Models
{
    public class WishListModel
    {
        public int ID { get; set; } = 0;

        public static List<ItemsModel> GetWishList(int ID)
        {
            string dir = CurrentPath.GetDbasePath() + "\\WishList.txt";
            List<ItemsModel> wishlists = new List<ItemsModel>();
            string line = string.Empty;

            try
            {
               //Check if the file exists
               if (File.Exists(dir))
               {
                    //Create a Stream Reader
                    using (StreamReader rdr = new StreamReader(dir))
                    {
                        //Read the data in the file
                        while ((line = rdr.ReadLine()) != null)
                        {
                            var value = line.Split('|');

                            if (int.Parse(value[0]) == ID)
                            {
                                //Add data to the Wishlist Model
                                wishlists.Add(new ItemsModel(value[1], double.Parse(value[3]), int.Parse(value[2])));
                            }    
                        }
                    }
               }
               else
               {
                    throw new Exception("File Not Found!");
               }
            }
            catch (Exception ex)
            {
                throw ex;
            }

             return wishlists;
        }

        public static void EditWishlist(int id, double oldB, double newB)
        {
            string current = id.ToString() + "|" + oldB.ToString();
            
            string newVal = id.ToString() + "|" + newB.ToString();

            string dir = CurrentPath.GetDbasePath() + "\\WishList.txt";

            string[] lines = System.IO.File.ReadAllLines(dir);
            lines[id - 1] = newVal;
            System.IO.File.WriteAllLines(dir, lines);
        }
    }
}
