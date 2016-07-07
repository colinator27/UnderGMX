using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnderGMX
{
    class Objects
    {
        public static String[] getObjectDataNames(string appdirectory)
        {
            DirectoryInfo d = new DirectoryInfo(@appdirectory + "objects\\");
            FileInfo[] Files = d.GetFiles("*.js");
            string[] filecontent = { };
            List<String> objlist = new List<String>();
            string[] split = {""};
            int index = 0;
            int i = 0;
            int i2 = 0;
            while (i2 < Files.Length - 1)
            {
                while (i < Files.Length)
                {
                    filecontent = File.ReadAllLines(@appdirectory + "objects\\" + Files[i].Name);
                    if (filecontent.Length > 0) { split[0] = filecontent[1].Remove(0, 20); } else
                        split[0] = "undefined";
                    //Console.WriteLine(split[0]);
                    if (split[0] == index.ToString())
                    {
                        objlist.Add(Files[i].Name.Remove(Files[i].Name.Length - 3));
                        Console.WriteLine("Loading Object: " + Files[i].Name.Remove(Files[i].Name.Length - 3));
                        index++;
                        i = 999999999;
                    }
                    i++;
                }
                i = 0;
                i2++;
            }
            return objlist.ToArray();
        }
    }
}
