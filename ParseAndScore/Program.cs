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
            //TODO grap input include a quit condition!!
            var appName = "Html Parse & Score";
            var appVersion = "1.0";
            var appAuthor = "Lakeem Muhammad";
            Console.WriteLine("{0}: {1} Version: Created by: {2}", appName, appVersion, appAuthor);
            Console.WriteLine("\n");

             var appConsole = new ConsoleUI();
             appConsole.ConsoleAction();

            var test2 = Console.ReadLine();






            //TODO place user interaction in console

        }
    }
}
