﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnderGMX
{
    class Paths
    {
        public static String[] getPathDataNames(string appdirectory)
        {
            DirectoryInfo d = new DirectoryInfo(@appdirectory + "paths\\");
            FileInfo[] Files = d.GetFiles("*.xml");
            string[] filecontent = { };
            List<String> pathlist = new List<String>();
            string[] split = { };
            int index = 0;
            int i = 0;
            int i2 = 0;
            while (i2 < Files.Length)
            {
                while (i < Files.Length)
                {
                    filecontent = File.ReadAllLines(@appdirectory + "paths\\" + Files[i].Name);
                    split = filecontent[0].Split('>');
                    if (split[2].Remove(split[2].Length - 7) == index.ToString())
                    {
                        pathlist.Add(Files[i].Name.Remove(Files[i].Name.Length - 4));
                        Console.WriteLine("Loading Path: " + Files[i].Name.Remove(Files[i].Name.Length - 4));
                        index++;
                        i = 999999999;
                    }
                    i++;
                }
                i = 0;
                i2++;
            }
            return pathlist.ToArray();
        }
    }
}
