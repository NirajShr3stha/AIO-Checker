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

namespace  ClassyAIO
{
    class credits
    {
        public static void play()
        {
            string fileName = "config.json";
            Console.Clear();
            Console.Title = "AIO ︱ Credits... ︱ By XDWOLF#1337";
            ASCII.ASCIII();
            Colorful.Console.WriteLine("               [!] Made By XDWOLF#1337", Color.Red);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [!] Configs By XDWOLF#1337", Color.Green);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("               [0] Back", Color.Yellow);
            Colorful.Console.WriteLine("");
            Colorful.Console.WriteLine("");
            Colorful.Console.Write("               > ", Color.FloralWhite);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.D0 || keyInfo.Key == ConsoleKey.NumPad1)
            {
                Console.Clear();
                Program.Main();

            }
        }
    }
}
