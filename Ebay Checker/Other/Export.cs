using System;
using System.IO;

namespace Template {
    internal class Export {
        public static void Initialize() {
            tempName = $"{DateTime.Now:MM-dd-yy HH;mm tt}";
            modulename = "Results";

            Directory.CreateDirectory("Output");
            Directory.CreateDirectory("Output/" + tempName + "/" + modulename);
        }

        public static void AsResult(string fileName, string content) {
            lock (resultLock) {
                File.AppendAllText(string.Concat(new string[]
                {
                    "Output/",
                    tempName + "/",
                    modulename,
                    fileName,
                    ".txt"
                }), content + Environment.NewLine);
            }
        }

        public static string tempName;
        public static string modulename;
        static object resultLock = new object();
    }
}