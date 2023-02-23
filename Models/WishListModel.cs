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
                                wishlists.Add(new ItemsModel(value[1], double.Parse(value[2]), int.Parse(value[3])));
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

        public static void EditWishlist(List<ItemsModel> list, int ID)
        {
            string dir = CurrentPath.GetDbasePath() + "\\WishList.txt";

            string[] oldFile = System.IO.File.ReadAllLines(dir);         

            //empties all the lines that are part of the user's original wishlist
            for (int a = 0; a < oldFile.Length; a++)
            {
                string[] current = oldFile[a].Split('|');

                if (int.Parse(current[0]) == ID)
                {
                    oldFile[a] = "";
                }
            }

            System.IO.File.WriteAllLines(dir, oldFile);

            using (StreamWriter sw = File.AppendText(dir))
            {
                //adds each element of the user's updated wishlist to the WishList text file in the correct format
                for (int j = 0; j < list.Count; j++)
                {
                    string add = ID.ToString() + "|" + list[j].Name + "|" + list[j].Price.ToString() + "|" + list[j].Priority.ToString();
                    sw.WriteLine(add);
                }
            }

            var lines = File.ReadAllLines(dir).Where(line => !string.IsNullOrWhiteSpace(line));
            File.WriteAllLines(dir, lines);
        }
    }
}
