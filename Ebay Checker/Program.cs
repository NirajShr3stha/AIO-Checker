using JawBrute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;
using JawBrute;
using Ebay_Checker;
using System.Runtime.CompilerServices;
using DiscordRPC;
using System.Diagnostics;

namespace ClassyAIO
{
    class Program
    {
        public static bool isLoggedIn = false;
        public static string webhookUrl = "";
        public static bool isBotLoggedIn = false;
        public static string currentColor = "";
        public static string currentModule = "";
        public static string s = "";
        static List<Func<string[], string, bool>> pickedModules = new List<Func<string[], string, bool>>();
        public static List<string> pickedModulesNames = new List<string>();
        public static int globalThreads = -1;
        public static int globalRetries = -1;
        public static string proxyProtocol = "";
        public static int hits = 0;
        public static int frees = 0;
        public static int errors = 0;
        public static int realretries = 0;
        public static int cpm = 0;
        public static int checks = 0;
        public static IEnumerable<string> combos;
        public static int comboTotal = 0;
        public static IEnumerable<string> proxies;
        public static int proxiesCount = 0;
        public static int comboIndex = 0;
        public static int Modules = 0;
        public static string gay = "";
        public static DiscordRpcClient client;
        [STAThread]

        public static void Initialize()
        {


        }
        [STAThread]
        public static void Main()

        {



            if (!File.Exists("Config.json"))
            {
                string json = "{\n          \"LoginInfo\":\"\",\n          \"Color\":\"\",\n          \"DiscordWebhook\":\"\"\n}";
                File.WriteAllText("Config.json", json);
            }
            dynamic jToken = JsonConvert.DeserializeObject(File.ReadAllText("Config.json"));
            string fileName = "config.json";
            if (isLoggedIn == true) //if false needs auth 
            {
                Console.Title = "AIO - Auth...";
                OnProgramStart.Initialize("AIO", "158800", "Xg9KBoooXgDZ0fsCkII21mJEs2B15gLesmj", "1.0");

                string login = jToken["LoginInfo"];
                if (!login.Contains(":"))
                {
                    Auth.AuthPart();

                }

                if (login.Contains(":"))
                {
                    string[] split = login.Split(':');
                    Auth.username = split[0];
                    Auth.Password = split[1];

                    if (API.Login(Auth.username, Auth.Password))
                    {
                        Console.Clear();
                        ASCII.ASCIII();

                        Console.Write("               Redirecting ...", Color.LawnGreen);
                        Thread.Sleep(1000);
                        Console.Clear();

                        goto succesfullLogin;
                    }
                }
            }
        succesfullLogin:
            Prsc.Initialize();
            Console.Title = "AIO ︱ Main ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Colorful.Console.WriteLine("               [!] Made By: XDWOLF#1337", Color.FloralWhite);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [1] Checker", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] Settings", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] Exit", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                ASCII.ASCIII();
                menu2();
                Prsc.module();

            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {

                settings();
            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        public static void settings()
        {
            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO ︱ Settings... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Colorful.Console.WriteLine("               [1] Credits", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                credits.play();

            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                Main();

            }
        }


        [STAThread]
        public static void menu2()
        {

            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO ︱ Selecting... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] Modules", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] Minecraft Checker - (Disabled)", Color.Red);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] Valid Mail", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [4] Email Filters", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [5] Domain Extract", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [6] Free Proxies", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                ASCII.ASCIII();
                Modules1();

            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                menu2();

            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                ASCII.ASCIII();
                vm();

            }
            if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                ASCII.ASCIII();
                filtermenu();

            }
            if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                ASCII.ASCIII();
                domainfilter();

            }
            if (keyInfo.Key == ConsoleKey.D6 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                proxy();

            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Main();
            }
        }

        public static void proxy()
        {
            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO ︱ proxy Select... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] HTTP", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] SOCKS4", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] SOCKS5", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Process.Start("https://api.proxyscrape.com/v2/?request=getproxies&protocol=http&timeout=10000&country=all&ssl=all&anonymity=all");
                menu2();
            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Process.Start("https://api.proxyscrape.com/v2/?request=getproxies&protocol=socks4&timeout=10000&country=all");
                menu2();
            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Process.Start("https://api.proxyscrape.com/v2/?request=getproxies&protocol=socks5&timeout=10000&country=all");
                menu2();
            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                menu2();

            }
        }

        public static void Modules2()
        {
            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO Modules... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] Mail.ru", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] Hotmail, Outlook & Live", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] Mailbox.de - (Disabled)", Color.Red);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                mailru.mailrustart();

            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                hotmail.hotmailstart();

            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Modules2();

            }
            if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                btc.btccheck();

            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Modules1();

            }
        }



            public static void Modules1()
        {
            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO Modules... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] Gmx.com       [5] Web.de", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] Yandex        [6] Edu Mail", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] Elastic Mail  [7] Rediff Mail", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [4] Mail Access   [8] Yahoo #1", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back          [A] Next Page...", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                GMXAPI.GMX();
                Prsc.gmxapi();

            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                yandex.yandexapi();
                Prsc.Yandex();

            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                elastic.elasticmail();
                Prsc.ElasticMail();

            }
            if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                proxymus.proximusX();
                Prsc.MA();

            }
            if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                yahooinbox.checkinbox();
                Prsc.webde();

            }
            if (keyInfo.Key == ConsoleKey.D6 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                EduMA.Ebay();
                Prsc.EduMA();

            }
            if (keyInfo.Key == ConsoleKey.D7 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                reddif.reddifstart();
                Prsc.EduMA();

            }
            if (keyInfo.Key == ConsoleKey.D8 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                yahoo.yahoostart();

            }
            if (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                Modules2();

            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Thread.Sleep(1000);
                Console.Clear();
                menu2();
            }

        }
        [STAThread]
        public static void domainfilter()
        {

            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO Domain Filter... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] .com     [5] .org     [9] .de", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] .fr      [6] .es      [F1] .nl", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] .net     [7] .co.uk   [F2] Full Extract Domain", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [4] .ru      [8] .eu", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                domainextract.extract();

            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                frdom.extract();

            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                netdom.extract();

            }
            if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                rudom.extract();

            }
            if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                orgdom.extract();

            }
            if (keyInfo.Key == ConsoleKey.D6 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                esdom.extract();

            }
            if (keyInfo.Key == ConsoleKey.D7 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                coukdom.extract();

            }
            if (keyInfo.Key == ConsoleKey.D8 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                eudom.extract();

            }
            if (keyInfo.Key == ConsoleKey.D9 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                dedom.extract();

            }
            if (keyInfo.Key == ConsoleKey.F1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                nldom.extract();
            }
            if (keyInfo.Key == ConsoleKey.F2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                domainfull.extractfull();
            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Thread.Sleep(1000);
                Console.Clear();
                menu2();
            }
        }

        public static void vm2()
        {

            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO Valid Mail... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] FitBitVM - (Disabled)", Color.Red);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] AmazonVM", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] OriginVM", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [4] DiscordVM - (Disabled)", Color.Red);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                vm2();


            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                amazon.GMX();


            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                origin.GMX();


            }
            if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                vm2();


            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Thread.Sleep(1000);
                Console.Clear();
                vm();
            }
        }


            public static void mc()
        {

            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO Minecraft... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] Minecraft Checker", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] Hypixel Scan - (Disabled)", Color.Red);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                mc11.mcstart();
                

            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Modules1();

            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {


            }
            if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad1)
            {


            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Thread.Sleep(1000);
                Console.Clear();
                menu2();
            }

        }

        public static void vm()
        {

            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO Valid Mail... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] PayPal Valid Mail     [5] FaceBook Valid Mail", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] Ebay Valid Mail       [6] Minecraft Valid Mail", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] AliExpress Valid Mail [7] Apple Valid Mail - (Disabled)", Color.Red);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [4] PSN Valid Mail        [8] NetflixVM", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back                  [9] Next Page...", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                pp.pp1();
                Prsc.checkppp();

            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                EbayVMC.Ebay();
                Prsc.ebayvm();

            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                AliVM.alivmi();
                Prsc.checkali();

            }
            if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                psnvm.psnstartt();
                Prsc.checkpsnvm();

            }
            if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                fbvm.Ebay();
                Prsc.fbvm();

            }
            if (keyInfo.Key == ConsoleKey.D6 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                mc11.mcstart();

            }
            if (keyInfo.Key == ConsoleKey.D7 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                vm();

            }
            if (keyInfo.Key == ConsoleKey.D8 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                netflixvm.GMX();

            }
            if (keyInfo.Key == ConsoleKey.D9 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                vm2();
            }

            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Thread.Sleep(1000);
                Console.Clear();
                menu2();
            }

        }

        public static void filtermenu()
        {

            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO Combo Filter... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Prsc.module();
            Colorful.Console.WriteLine("               [1] Yahoo Filter      [5] Gmx.de Filter      [9] Full Extract", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] Yandex Filter     [6] Gmx.com Filter", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] Gmail Filter      [7] Hotmail, Outlook & Live Filter", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [4] Bing Filter       [8] Web.de Filter", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                yahoofilter.yahoofilt();
                Prsc.yahoo();

            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                yandexfilter.yandexfilt();
                Prsc.yandexfilt();

            }
            if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                gmailfilter.gmailfilt();
                Prsc.gmailfilter();

            }
            if (keyInfo.Key == ConsoleKey.D4 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                bringfilter.bing();
                Prsc.bingfilter();

            }
            if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                gmxde.filter();
                Prsc.gmxde();

            }
            if (keyInfo.Key == ConsoleKey.D6 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                gmxcom.filter();
                Prsc.gmxcom();

            }
            if (keyInfo.Key == ConsoleKey.D7 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                hotmailect.filter();
                Prsc.hotmail();

            }
            if (keyInfo.Key == ConsoleKey.D8 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                webde.filter();
                Prsc.webde();

            }
            if (keyInfo.Key == ConsoleKey.D9 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                fullextr.extractfull();
                Prsc.fullextract();
            }
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Thread.Sleep(1000);
                Console.Clear();
                menu2();
            }

        }
    }
}









