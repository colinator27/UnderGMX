using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnderGMX
{
    class Scripts
    {
        public static String[] getScriptDataNames(string appdirectory)
        {
            DirectoryInfo d = new DirectoryInfo(@appdirectory + "scripts\\");
            FileInfo[] Files = d.GetFiles("*.js");
            string[] filecontent = { };
            List<String> scrlist = new List<String>();
            int i = 0;
            while (i < Files.Length)
            {
                scrlist.Add(Files[i].Name.Remove(Files[i].Name.Length - 3));
                i++;
            }
            return scrlist.ToArray();
        }
    }
}
