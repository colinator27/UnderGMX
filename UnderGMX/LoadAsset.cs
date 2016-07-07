using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnderGMX
{
    class LoadAsset
    {
        public static String[] loadAsset(string asset)
        {
            string[] filecontent = File.ReadAllLines(@"assets\\" + asset);
            return filecontent;
        }
    }
}
