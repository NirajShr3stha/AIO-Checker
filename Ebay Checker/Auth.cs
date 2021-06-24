using System;
using Console = Colorful.Console;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using System.Threading;
using System.Security;
using Ebay_Checker;
using ClassyAIO;

namespace JawBrute
{
    class Auth
    {
        public static string username = "";
        public static string Password = "";

        public static void AuthPart()
        {
        tryAgain:
            Console.Clear();

            Prsc.Initialize();
            Console.Title = "AIO ︱ Login ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Colorful.Console.WriteLine("               [!] Made By: XDWOLF#1337", Color.White);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [1] Login", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [2] Register", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [3] Extend License", Color.BlueViolet);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.D1)
            {
                if (!ApplicationSettings.Login)
                {
                    Console.WriteLine("Login Disabled", Color.Red);
                    goto tryAgain;
                }
                else
                {
                    dynamic jToken = JsonConvert.DeserializeObject(File.ReadAllText("Config.json"));
                    Console.Clear();
                    ASCII.ASCIII();

                    Colorful.Console.WriteLine("               [!] Username:", Color.BlueViolet);
                    Console.ForegroundColor = Color.WhiteSmoke;
                    Colorful.Console.WriteLine("");
                    Colorful.Console.Write("               > ", Color.FloralWhite);
                    username = Console.ReadLine();


                    SecureString password = SecurePassword();
                    Password = new System.Net.NetworkCredential(string.Empty, password).Password;


                    if (API.Login(username, Password))
                    {
                        Colorful.Console.WriteLine("               [!] Logged in...", Color.FloralWhite);

                        string json = "{\n          \"LoginInfo\":\"" + username + ":" + Password + "\",\n          \"Color\":\"" + Program.currentColor + "\",\n          \"DiscordWebhook\":\"" + jToken["DiscordWebhook"] + "\"\n}";
                        File.WriteAllText("Config.json", json);

                        Thread.Sleep(950);
                        Program.isLoggedIn = true;
                        Console.Clear();
                        Program.Main();
                    }
                }
            }
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                if (!ApplicationSettings.Register)
                {
                    Console.WriteLine("Register is disabled!", Color.Red);
                    goto tryAgain;
                }
                else
                {
                    dynamic jToken = JsonConvert.DeserializeObject(File.ReadAllText("Config.json"));
                    Console.Clear();
                    ASCII.ASCIII();

                    Colorful.Console.WriteLine("               [!] Username:", Color.BlueViolet);
                    Colorful.Console.WriteLine("");
                    Colorful.Console.Write("               > ", Color.SpringGreen);
                    username = Console.ReadLine();


                    SecureString password = SecurePassword();
                    Password = new System.Net.NetworkCredential(string.Empty, password).Password;


                    Colorful.Console.WriteLine("               [!] Email:", Color.Blue);
                    Colorful.Console.WriteLine("");
                    Colorful.Console.Write("               > ", Color.SpringGreen);
                    string email = Console.ReadLine();

                    Colorful.Console.WriteLine("               [!] License:", Color.BlueViolet);
                    Colorful.Console.WriteLine("");
                    Colorful.Console.Write("               > ", Color.FloralWhite);
                    string license = Console.ReadLine();


                    if (API.Register(username, Password, email, license))
                    {
                        Colorful.Console.WriteLine("               [!] Registered! ", Color.BlueViolet);

                        string json = "{\n          \"LoginInfo\":\"" + username + ":" + Password + "\",\n          \"Color\":\"" + Program.currentColor + "\",\n          \"DiscordWebhook\":\"" + jToken["DiscordWebhook"] + "\"\n}";
                        File.WriteAllText("Config.json", json);

                        Thread.Sleep(950);
                        Program.isLoggedIn = true;
                        Console.Clear();
                        Program.Main();
                    }

                }
            }
            else if (keyInfo.Key == ConsoleKey.D3)
            {
                dynamic jToken = JsonConvert.DeserializeObject(File.ReadAllText("Config.json"));
                Console.Clear();
                ASCII.ASCIII();

                Colorful.Console.WriteLine("               [!] Username:", Color.BlueViolet);
                Console.ForegroundColor = Color.WhiteSmoke;
                Colorful.Console.WriteLine("");
                Colorful.Console.Write("               > ", Color.SpringGreen);
                username = Console.ReadLine();


                SecureString password = SecurePassword();
                Password = new System.Net.NetworkCredential(string.Empty, password).Password;


                Colorful.Console.WriteLine("               [!] License:", Color.BlueViolet);
                Console.ForegroundColor = Color.WhiteSmoke;
                Colorful.Console.WriteLine("");
                Colorful.Console.Write("               > ", Color.SpringGreen);
                string license = Console.ReadLine();

                if (API.ExtendSubscription(username, Password, license))
                {
                    Colorful.Console.WriteLine("               [!] Succesfully Extended Subscription!", Color.BlueViolet);

                    string json = "{\n          \"LoginInfo\":\"" + username + ":" + Password + "\",\n          \"Color\":\"" + Program.currentColor + "\",\n          \"DiscordWebhook\":\"" + jToken["DiscordWebhook"] + "\"\n}";
                    File.WriteAllText("Config.json", json);

                    Thread.Sleep(950);
                    Program.isLoggedIn = true;
                    Program.Main();
                }
            }
            else
            {
                goto tryAgain;
            }
        }

        public static SecureString SecurePassword()
        {
            Colorful.Console.WriteLine("               [!] Password:", Color.FloralWhite);
            Console.ForegroundColor = Color.FloralWhite;
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            SecureString password = new SecureString();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (!char.IsControl(key.KeyChar))
                {
                    password.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.RemoveAt(password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            return password;
        }
    }
}