using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnderGMX
{
    class Rooms
    {
        public static String[] getRoomDataNames(string appdirectory)
        {
            DirectoryInfo d = new DirectoryInfo(@appdirectory + "rooms\\");
            FileInfo[] Files = d.GetFiles("*.xml");
            string[] filecontent = { };
            List<String> roomlist = new List<String>();
            string[] split = { };
            int index = 0;
            int i = 0;
            int i2 = 0;
            while (i2 < Files.Length - 1)
            {
                while (i < Files.Length)
                {
                    filecontent = File.ReadAllLines(@appdirectory + "rooms\\" + Files[i].Name);
                    split = filecontent[0].Split('>');
                    if (split[2].Remove(split[2].Length - 7) == index.ToString())
                    {
                        roomlist.Add(Files[i].Name.Remove(Files[i].Name.Length - 4));
                        Console.WriteLine("Loading Room: " + Files[i].Name.Remove(Files[i].Name.Length - 4));
                        index++;
                        i = 999999999;
                    }
                    i++;
                }
                i = 0;
                i2++;
            }
            return roomlist.ToArray();
        }
    }
}
