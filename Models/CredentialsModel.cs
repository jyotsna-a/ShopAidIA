using ShopAid.Processes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAid.Models
{
    public class CredentialsModel
    {
        public int ID { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public CredentialsModel()
        {

        }

        public CredentialsModel(int UID, string uName, string pwd)
        {
            ID = UID;
            UserName = uName;
            Password = pwd;
        }

        public static List<CredentialsModel> GetCredentials()
        {
            string dir = CurrentPath.GetDbasePath() + "\\Credentials.txt";
            List<CredentialsModel> credentials = new List<CredentialsModel>();
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
                            credentials.Add(new CredentialsModel()
                            {
                                ID = int.Parse(value[0]),
                                UserName = value[1],
                                Password = value[2]
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

            return credentials;
        }

        public static void EditCredentials(string uName, string pWord)
        {
            string dir = CurrentPath.GetDbasePath() + "\\Credentials.txt";

            //find lowest ID number available
            string[] lines = System.IO.File.ReadAllLines(dir);
            string[] last = lines[lines.Length - 1].Split('|');
            int lastID = int.Parse(last[0]);
            int id = lastID + 1;

            string newUser = id.ToString() + "|" + uName + "|" + pWord;

            using (StreamWriter sw = File.AppendText(dir))
            {
                sw.WriteLine(newUser);
            }

            string budgetDir = CurrentPath.GetDbasePath() + "\\Budget.txt";
            string budget = id.ToString() + "|" + "0";

            using (StreamWriter sw = File.AppendText(budgetDir))
            {
                sw.WriteLine(budget);
            }
        }
    }
}
