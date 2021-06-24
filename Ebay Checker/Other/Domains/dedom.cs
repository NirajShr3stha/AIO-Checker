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

namespace Ebay_Checker
{
    class dedom
    {
        [STAThread]
        public static void extract()
        {
            Export.Initialize();
            Console.Title = "Mailos | .de extractor";
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
            Colorful.Console.WriteLine("               Filtering...");
            try
            {

                Task.Factory.StartNew(() =>
                {
                    for (; ; )
                    {
                        Variables.cpm = Variables.cpm_aux;
                        Variables.cpm_aux = 0;
                        Colorful.Console.Title = "[Mailos - .de extractor] | Valid: " + Variables.hit + " | Other: " + Variables.other + "| Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
                        Thread.Sleep(1000);
                    }
                });

                for (int i = 1; i <= Variables.threads; i++)
                {
                    new Thread(new ThreadStart(CheckPP)).Start();
                }
            }
            catch
            {

            }
        }
        [STAThread]
        public static void CheckPP()
        {
        stat:

            for (; ; )
            {

                while (true)
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
                                //REQUESTS - YOU CAN REPLACE WITH COMPILER CODE HERE, USE UR BRAIN PLEASE THANKS`
                                if (s[0].Contains(".de") || s[0].Contains(".DE"))
                                {
                                    Variables.hit++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    Export.AsResult("/.de", s[0] + ":" + s[1]);
                                }
                                else if (s[0].Contains(".com"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else if (s[0].Contains(".org"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else if (s[0].Contains(".ru"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else if (s[0].Contains(".net"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else if (s[0].Contains(".es"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else if (s[0].Contains(".co.uk"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else if (s[0].Contains(".eu"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else if (s[0].Contains(".fr"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else if (s[0].Contains(".eu"))
                                {
                                    Variables.other++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }
                                else
                                {
                                    break;//add retry here
                                }





                                {
                                    goto stat;
                                }
                            }
                            catch (Exception ex)
                            {
                                Variables.error++;

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
    }
}