using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    class Program
    {
        static void Main(string[] args)
        {
            var appName = "Html Parse & Score";
            var appVersion = "1.0";
            var appAuthor = "Lakeem Muhammad";
            Console.WriteLine("{0}: {1} Version: Created by: {2}", appName, appVersion, appAuthor);
            Console.WriteLine("\n");
            var progFlag = true;

            while (progFlag)
            {
                var appConsole = new ConsoleUI();
                appConsole.ConsoleAction();
                Console.WriteLine("Do you wish to continue? Y or N");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "y") { progFlag = true; }
                else { progFlag = false; }

            }
            
        }
    }
}
