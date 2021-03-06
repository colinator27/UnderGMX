using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace UnderGMX
{
    class Program
    {
        static int gmxFileI = 0;
        static List<String> gmxFile = new List<String>();
        static void gmxWrite(String str)
        {
            gmxFile.Add(str);

        }
        static void Main(string[] args)
        {
            String appDir = System.AppDomain.CurrentDomain.BaseDirectory; //Get application directory for future use.
            Console.WriteLine("Application Base Directory: "+appDir);
            String gmxBase = appDir + "UnderGMX.gmx\\";
            
            Console.WriteLine("Writing GMX File...");
            gmxFile.Add("<!--This Document is generated by UnderGMX, if you edit it by hand then you do so at your own risk!-->");
            gmxFile.Add("<assets>"); // Entry point for GMX file assets.
            Console.WriteLine("GMX File -> Writing Config");
            gmxWrite("  <Configs name=\"configs\">");
            gmxWrite("    <Config>Configs\\Default</Config>");
            gmxWrite("  </Configs>");
            //Console.WriteLine("GMX File -> Writing datafiles (not implemented)");
            //gmxWrite("  <datafiles name=\"datafiles\"/>");
            Console.WriteLine("GMX File -> Writing Extensions (not implemented)");
            gmxWrite("  <NewExtensions>");
            gmxWrite("  </NewExtensions>");

            // HERE WE GET ALL OF THE SPRITES, SCRIPTS, OBJECTS, ETC. INTO MEMORY AND WRITE THE GMX FILE CONTENT.
            gmxWrite("  <sounds name=\"sound\">");

            String[] soundnames = Sounds.getSoundDataNames(appDir);
            int soundi = 0;

            while (soundi < soundnames.Length)
            {
                gmxWrite("    <sound>sound\\"+soundnames[soundi]+ "</sound>");
                soundi++;
            }

            gmxWrite("  </sounds>");

            gmxWrite("  <sprites name=\"sprites\">");

            String[] spritenames = Sprites.getSpriteDataNames(appDir);
            int spritei = 0;

            while (spritei < spritenames.Length)
            {
                gmxWrite("    <sprite>sprites\\" + spritenames[spritei] + "</sprite>");
                spritei++;
            }

            gmxWrite("  </sprites>");

            gmxWrite("    <backgrounds name=\"background\">");

            String[] bgnames = Backgrounds.getBackgroundDataNames(appDir);
            int bgi = 0;

            while (bgi < bgnames.Length)
            {
                gmxWrite("    <background>background\\" + bgnames[bgi] + "</background>");
                bgi++;
            }

            gmxWrite("  </backgrounds>");

            gmxWrite("  <paths name=\"paths\">");

            String[] pathnames = Paths.getPathDataNames(appDir);
            int pathi = 0;

            while (pathi < pathnames.Length)
            {
                gmxWrite("    <path>paths\\" + pathnames[pathi] + "</path>");
                pathi++;
            }

            gmxWrite("  </paths>");

            gmxWrite("  <scripts name=\"scripts\">");

            String[] scrnames = Scripts.getScriptDataNames(appDir);
            int scri = 0;

            while (scri < scrnames.Length)
            {
                gmxWrite("    <script>scripts\\" + scrnames[scri] + ".gml</script>");
                scri++;
            }

            gmxWrite("  </scripts>");

            gmxWrite("  <fonts name=\"fonts\">");

            String[] fntnames = Fonts.getFontDataNames(appDir);
            int fnti = 0;

            while (fnti < fntnames.Length)
            {
                gmxWrite("    <font>fonts\\" + fntnames[fnti] + "</font>");
                fnti++;
            }

            gmxWrite("  </fonts>");

            /*gmxWrite("  <objects name=\"objects\">");

            String[] objnames = Objects.getObjectDataNames(appDir);
            int obji = 0;

            while (obji < objnames.Length)
            {
                gmxWrite("    <object>objects\\" + objnames[obji] + "</object>");
                obji++;
            }

            gmxWrite("  </objects>");*/

            /*gmxWrite("  <rooms name=\"rooms\">");

            String[] roomnames = Rooms.getRoomDataNames(appDir);
            int roomi = 0;

            while (roomi < roomnames.Length)
            {
                gmxWrite("    <room>rooms\\" + roomnames[roomi] + "</room>");
                roomi++;
            }

            gmxWrite("  </rooms>");*/

            // Here we complete the GMX file with the help files/tutorial states.
            gmxWrite("  <help>");

            gmxWrite("    <rtf>help.rtf</rtf>");

            gmxWrite("  </help>");

            gmxWrite("  <TutorialState>");

            gmxWrite("    <IsTutorial>0</IsTutorial>");

            gmxWrite("    <TutorialName></TutorialName>");

            gmxWrite("    <TutorialPage>0</TutorialPage>");

            gmxWrite("  </TutorialState>");
            //Close off GMX file.
            gmxWrite("</assets>");
            var gmxFileArr = gmxFile.ToArray();
            string list = "";
            int i = 0;
            //while(i < gmxFileArr.Length)
            //{
            //   Console.WriteLine(gmxFileArr[i]);
            // list += gmxFileArr[i];
            //    i++;
            //}
            //Console.WriteLine(list);

            if (!Directory.Exists(appDir + "UnderGMX.gmx"))
            {
                Directory.CreateDirectory(appDir + "UnderGMX.gmx");
            } else
            {
                //if(Directory.Exists(appDir+"gmx\\sprites")) Directory.Delete(appDir+"gmx\\sprites");

                System.IO.DirectoryInfo di = new DirectoryInfo(appDir+"UnderGMX.gmx");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                Directory.CreateDirectory(appDir + "UnderGMX.gmx");
            }

            /*if ((!File.Exists(@appDir+"UnderGMX.project.gmx")))
            {
                FileStream fs = File.Create(@appDir+"UnderGMX.project.gmx");
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(appDir+"UnderGMX.project.gmx", true);

            while (i < gmxFileArr.Length)
            {
                sw.WriteLine(gmxFileArr[i]);
                i++;
            }

            sw.Close();*/

            using (var dest = File.AppendText(Path.Combine(gmxBase, "help.rtf")))
            {
                dest.Write("");
            }

            using (var dest = File.AppendText(Path.Combine(gmxBase, "UnderGMX.project.gmx")))
            {
                dest.Write("");
            }

            while (i < gmxFileArr.Length)
            {
                using (var dest = File.AppendText(Path.Combine(gmxBase, "UnderGMX.project.gmx")))
                {
                    dest.WriteLine(gmxFileArr[i]);
                }
                i++;
            }

            if (!Directory.Exists(gmxBase + "Configs\\"))
                Directory.CreateDirectory(gmxBase + "Configs");

            if (!Directory.Exists(gmxBase + "datafiles\\"))
                Directory.CreateDirectory(gmxBase + "datafiles");

            if (!Directory.Exists(gmxBase + "extensions\\"))
                Directory.CreateDirectory(gmxBase + "extensions");

            if (!Directory.Exists(gmxBase + "sound\\"))
                Directory.CreateDirectory(gmxBase + "sound");

            if (!Directory.Exists(gmxBase + "sprites\\"))
                Directory.CreateDirectory(gmxBase + "sprites");

            if (!Directory.Exists(gmxBase + "background\\"))
                Directory.CreateDirectory(gmxBase + "background");

            if (!Directory.Exists(gmxBase + "paths\\"))
                Directory.CreateDirectory(gmxBase + "paths");

            if (!Directory.Exists(gmxBase + "scripts\\"))
                Directory.CreateDirectory(gmxBase + "scripts");

            if (!Directory.Exists(gmxBase + "fonts\\"))
                Directory.CreateDirectory(gmxBase + "fonts");

            if (!Directory.Exists(gmxBase + "rooms\\"))
                Directory.CreateDirectory(gmxBase + "rooms");


            string ConfigBase = gmxBase + "Configs\\";

            string[] configasset = LoadAsset.loadAsset("Default.config.gmx");

            i = 0;

            while (i < configasset.Length)
            {
                using (var dest = File.AppendText(Path.Combine(ConfigBase, "Default.project.gmx")))
                {
                    dest.WriteLine(configasset[i]);
                }
                i++;
            }

            CopyPaste.CopyDirectory(@"assets\Default",ConfigBase+"Default",true);

            Sprites.copySprites(appDir);
            Sprites.writeSprites(appDir,spritenames);

            Sounds.copySounds(appDir);
            Sounds.writeSounds(appDir,soundnames);

            Backgrounds.copyBackgrounds(appDir);
            Backgrounds.writeBackgrounds(appDir,bgnames);

            Scripts.writeScripts(appDir, scrnames);

            Console.WriteLine("GMX Project File Compiled successfully!");
            Console.WriteLine("Press any key to exit."); //Finish off application.
            Console.ReadKey();

        }
    }
}
