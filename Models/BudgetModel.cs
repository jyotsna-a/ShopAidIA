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
            return BudgetInputOutput.GetBudgetData(dir);
        }

        public static void EditBudgets(int id, double oldB, double newB)
        {
            string current = id.ToString() + "|" + oldB.ToString();
            
            string newVal = id.ToString() + "|" + newB.ToString();

            string dir = CurrentPath.GetDbasePath() + "\\Budget.txt";

            using (StreamReader reader = new StreamReader(File.OpenRead(dir)))
            {
                string fileContent = reader.ReadToEnd();

                reader.Close();

                fileContent = fileContent.Replace(current, newVal);

                StreamWriter writer = new StreamWriter(File.OpenWrite(dir));

                writer.Write(fileContent);

                writer.Close();
            }
        }
    }
}
