using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Variables
    {
        public static int threads = 0;
        public static string proxyprotocol = "";
        public static List<string> combos;
        public static List<string> proxies1;
        public static int proxytotal = 0;
        public static int combototal = 0;
        public static readonly object WriteLock = new object();
        public static int free = 0;
        public static int comboindex = 0;
        public static int cpm = 0;
        public static int cpm_aux = 0;
        public static int check = 0;
        public static int error = 0;
        public static int hit = 0;
        public static int bad = 0;
        public static int other = 0;
        public static int gmail = 0;
        public static int yandex = 0;
        public static int yahoo = 0;
        public static int hotmail = 0;
        public static int live = 0;
        public static int outlook = 0;
        public static int gmx = 0;
        public static int aol = 0;
        public static int googlemail = 0;
        public static int rocketmail = 0;
        public static int nl = 0;
        public static int eu = 0;
        public static int org = 0;
        public static int couk = 0;
        public static int net = 0;
        public static int com = 0;
        public static int fr = 0;
        public static int ru = 0;
        public static int es = 0;
        public static int de = 0;
    }
}
