using ShopAid.Processes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAid.Models
{
    public class BudgetModel
    {
        public int ID { get; set; } = 0;
        public double Budget { get; set; }

        public static List<BudgetModel> GetBudgets()
        {
            string dir = CurrentPath.GetDbasePath() + "\\Budget.txt";
            List<BudgetModel> budgets = new List<BudgetModel>();
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

                            //Add data to the Customers Model
                            budgets.Add(new BudgetModel()
                            {
                                ID = int.Parse(value[0]),
                                Budget = double.Parse(value[1])
                            });
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

             return budgets;
        }

        public static void EditBudgets(int id, double newB)
        {           
            string newVal = id.ToString() + "|" + newB.ToString();

            string dir = CurrentPath.GetDbasePath() + "\\Budget.txt";

            string[] lines = System.IO.File.ReadAllLines(dir);
            lines[id - 1] = newVal;
            System.IO.File.WriteAllLines(dir, lines);
        }
    }
}
