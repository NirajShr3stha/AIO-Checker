using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template;
using yoboi_legend;
using Ebay_Checker;
using System.Net;
using System.Diagnostics;
using JawBrute;

namespace Ebay_Checker
{
    class fullextr
    {
        [STAThread]
        public static void extractfull()
        {
            Prsc.fullextract();
            Export.Initialize();
            Console.Title = "Mailos | Full Extract";
        fuck:
            Console.Clear();
            ASCII.ASCIII();
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("                Threads:", Color.SpringGreen);
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.SpringGreen);
            try
            {
                Variables.threads = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Error Parsing Integor...");
                goto fuck;
            }
        fuckme:
            Console.Clear();
            ASCII.ASCIII();
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("                [1] HTTP", Color.SpringGreen);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("                [2] SOCKS4", Color.SpringGreen);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("                [3] SOCKS5", Color.SpringGreen);
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.SpringGreen);
            string c = Console.ReadLine();
            if (c == "1")
            {
                Variables.proxyprotocol = "HTTP";
            }
            else if (c == "2")
            {
                Variables.proxyprotocol = "SOCKS4";
            }
            else if (c == "3")
            {
                Variables.proxyprotocol = "SOCKS5";
            }
            else
            {
                goto fuckme;
            }
            loadCombos();
        }
        [STAThread]
        public static void loadCombos()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName;
            do
            {
                op.Title = "Load Combos";
                op.DefaultExt = "txt";
                op.Filter = "Text Files|*.txt";
                op.RestoreDirectory = true;
                op.ShowDialog();
                fileName = op.FileName;
            }
            while (!File.Exists(fileName));

            try
            {
                Variables.combos = new List<string>(File.ReadAllLines(fileName));

                using (FileStream FS = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (BufferedStream bs = new BufferedStream(FS))
                    {
                        using (StreamReader sr = new StreamReader(bs))
                        {
                            while (sr.ReadLine() != null)
                            {
                                Variables.combototal++;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            loadProxies();
        }
        [STAThread]
        public static void loadProxies()
        {
            OpenFileDialog op = new OpenFileDialog();
            string fileName;
            do
            {
                op.Title = "Load Proxies";
                op.DefaultExt = "txt";
                op.Filter = "Text Files|*.txt";
                op.RestoreDirectory = true;
                op.ShowDialog();
                fileName = op.FileName;
            }
            while (!File.Exists(fileName));

            try
            {
                Variables.proxies1 = new List<string>(File.ReadAllLines(fileName));

                using (FileStream FS = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (BufferedStream bs = new BufferedStream(FS))
                    {
                        using (StreamReader sr = new StreamReader(bs))
                        {
                            while (sr.ReadLine() != null)
                            {
                                Variables.proxytotal++;
                            }

                        }
                    }
                }
            }
            catch
            {

            }
            startpp();
        }
        [STAThread]
        public static void startpp()
        {
            Console.Clear();
            ASCII.ASCIII();
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [!] Please Wait Filtering ... ");
            Colorful.Console.WriteLine("");
        stat:
            try
            {

                Task.Factory.StartNew(() =>
                {
                    for (; ; )
                    {
                        Variables.cpm = Variables.cpm_aux;
                        Variables.cpm_aux = 0;
                        Colorful.Console.Title = "[Mailos - Full Extract] | Total Valid: " + Variables.hit + " | Other: " + Variables.other + " | Checked: " + Variables.check + "/" + Variables.combototal + " | FPM: " + Variables.cpm * 60;
                        Thread.Sleep(1000);
                    }
                });
                for (int i = 10; i <= Variables.threads; i++)
                {



                    {

                        {
                            try
                            {






                                //RANDOM PROXY EVERY REQ
                                string proxy = "";
                                Random r = new Random();
                                proxy = Variables.proxies1[r.Next(Variables.proxies1.Count)];


                                try
                                {

                                    using (HttpRequest httpRequest = new HttpRequest())
                                    {
                                        //SPLITTIN COMBOS
                                        if (Variables.comboindex >= Variables.combos.Count<string>())

                                        {
                                            break;
                                        }
                                        Interlocked.Increment(ref Variables.comboindex);
                                        string[] s = Variables.combos[Variables.comboindex].Split(new char[]
                                        {
                            ':'
                                        });
                                        //s[0] - Email  | s[1] - Password
                                        try
                                        {
                                            //PROXY HANDEL
                                            if (Variables.proxyprotocol == "HTTP")
                                            {
                                                httpRequest.Proxy = HttpProxyClient.Parse(proxy);
                                            }
                                            if (Variables.proxyprotocol == "SOCKS4")
                                            {
                                                httpRequest.Proxy = Socks4ProxyClient.Parse(proxy);
                                            }
                                            if (Variables.proxyprotocol == "SOCKS5")
                                            {
                                                httpRequest.Proxy = Socks5ProxyClient.Parse(proxy);
                                            }
                                            {
                                                //REQUESTS - YOU CAN REPLACE WITH COMPILER CODE HERE, USE UR BRAIN PLEASE THANKS`
                                                if (s[0].Contains("@gmail") || s[0].Contains("@GMAIL"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.gmail++;
                                                    Export.AsResult("/@gmail", s[0] + ":" + s[1]);


                                                }
                                                else if (s[0].Contains("@yandex"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.yandex++;
                                                    Export.AsResult("/@yandex", s[0] + ":" + s[1]);
                                                }
                                                else if (s[0].Contains("@yahoo"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.yahoo++;
                                                    Export.AsResult("/@yahoo", s[0] + ":" + s[1]);
                                                }
                                                else if (s[0].Contains("@hotmail"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.hotmail++;
                                                    Export.AsResult("/@hotmail", s[0] + ":" + s[1]);
                                                }
                                                else if (s[0].Contains("@outlook"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.outlook++;
                                                    Export.AsResult("/@outlook", s[0] + ":" + s[1]);
                                                }
                                                else if (s[0].Contains("@aol"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.aol++;
                                                    Export.AsResult("/@aol", s[0] + ":" + s[1]);
                                                }
                                                else if (s[0].Contains("@gmx"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.gmx++;
                                                    Export.AsResult("/@gmx", s[0] + ":" + s[1]);
                                                }
                                                else if (s[0].Contains("@googlemail"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.googlemail++;
                                                    Export.AsResult("/@googlemail", s[0] + ":" + s[1]);
                                                }
                                                else if (s[0].Contains("@live"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.live++;
                                                    Export.AsResult("/@live", s[0] + ":" + s[1]);
                                                }
                                                else if (s[0].Contains("@rocketmail"))
                                                {
                                                    Variables.hit++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    Variables.rocketmail++;

                                                    Export.AsResult("/@rocketmail", s[0] + ":" + s[1]);

                                                }
                                                else

                                                {
                                                    Variables.other++;
                                                    Variables.cpm_aux++;
                                                    Variables.check++;
                                                    goto stat;
                                                }
                                            }
                                        }





                                        catch (Exception ex)
                                        {
                                            Variables.error++;
                                            Variables.cpm_aux++;

                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Variables.error++;
                                    Variables.cpm_aux++;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Variables.cpm_aux++;
                                Variables.error++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Variables.error++;
            }
        }
    }
}


                
            

