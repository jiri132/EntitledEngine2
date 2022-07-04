using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitledEngine2.Engine.Core
{
    class Debug
    {
        public static void Log(string s)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[LOG] - {s}");
            Console.ResetColor();
        }
        public static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] - {s}");
            Console.ResetColor();
        }

        public static void Error(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] - {s}");
            Console.ResetColor();
        }
        public static void CustomLog(string s, ConsoleColor c)
        {
            Console.ForegroundColor = c;

            Console.WriteLine($"[LOG] - {s}");
            Console.ResetColor();
        }
    }
}
