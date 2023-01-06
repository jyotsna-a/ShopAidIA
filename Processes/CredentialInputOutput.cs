using ShopAid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAid.Processes
{
    class CredentialInputOutput
    {
        private static List<CredentialsModel> credentials;

        public static List<CredentialsModel> GetCredentialData(string file)
        {
            credentials = new List<CredentialsModel>();
            string line = string.Empty;

            try
            {
                //Check if the file exists
                if (File.Exists(file))
                {
                    //Create a Stream Reader
                    using (StreamReader rdr = new StreamReader(file))
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

        public static bool ExportDataToTextFile(List<CredentialsModel> data, string file)
        {
            try
            {
                //We want to 
                FileStream stream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);

                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    foreach (var d in data)
                    {
                        //writer.WriteLine(d.Person.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }
    }
}
