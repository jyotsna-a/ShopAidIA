using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAid.Processes
{
    public static class CurrentPath
    {
        private static string loc = string.Empty;

        public static string GetCurrentPath()
        {
            //Get Location of the application
            loc = Directory.GetCurrentDirectory();

            //Remove bin dir and everything to the right
            loc = loc.Substring(0, loc.IndexOf("\\bin"));

            return loc;
        }

        public static string GetDbasePath()
        {
            //Add Database path to the current path 
            loc = GetCurrentPath() + "\\DataBase";

            return loc;
        }
    }
}
