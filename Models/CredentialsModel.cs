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

    }
}
