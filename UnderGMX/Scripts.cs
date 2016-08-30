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
        public static void writeScripts(string appdirectory, string[] scrlist)
        {
            int i = 0;
            int i2 = 0;
            int length = scrlist.Length;
            string[] filecontent;
            string filecontentstr;
            while(i < length)
            {
                Console.WriteLine("Writing script: " + scrlist[i]);
                filecontent = File.ReadAllLines(@appdirectory + "scripts\\" + scrlist[i] + ".js");
                i2 = 0;
                filecontentstr = "";
                bool foundbend = false;
                while (i2 < filecontent.Length)
                {
                    if(foundbend == true) filecontentstr += (filecontent[i2].Replace("self.","") + Environment.NewLine);
                    if(foundbend == false)
                    {
                        if(filecontent[i2] == "*/")
                        {
                            foundbend = true;
                        }
                    }
                    i2++;
                }
                using (var dest = File.AppendText(Path.Combine(@appdirectory + "UnderGMX.gmx\\scripts\\", scrlist[i] + ".gml")))
                {
                    dest.Write(filecontentstr);
                }
                i++;
            }
        }
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
