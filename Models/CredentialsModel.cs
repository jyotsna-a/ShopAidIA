using ShopAid.Processes;
using System;
using System.Collections.Generic;
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
            return CredentialInputOutput.GetCredentialData(dir);
        }

    }
}
