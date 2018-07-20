using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    public class ConsoleUI
    {


        public void ConsoleAction()
        {

            // PrintUserOptionMessage();
            Console.WriteLine("Press 1, 2, 3, or 4");
            var userOption = Console.ReadLine();
            
            switch (userOption.ToString())
            {
                case ("1"):
                    OptionOne();
                    break;
                case ("2"):
                    OptionTwo();
                    break;
                case ("3"):
                    OptionThree();
                    break;
                case ("4"):
                    OptionFour();
                    break;
                default:
                    break;
            }

        }




        //
        private static void OptionOne()
        {
            Console.WriteLine("Enter the name of the file to process or Drag and drop location:");
            var userFileName = Console.ReadLine();
            var processingLogic = new ProcessingLogic();

            var result = processingLogic.ProcessingFile(userFileName);
            //TODO Output format


        }

        private static void OptionTwo()
        {
            Console.WriteLine("Enter the name of the file to retrieve");
            var userFileName = Console.ReadLine();
            var processingLogic = new ProcessingLogic();
           var output = processingLogic.RetrieveHtmlScores(userFileName);
            PrintOutput(output);
        }


        private static void OptionThree()
        {

        }

        private static void OptionFour()
        {

        }






        //TODO Console output formatting

        private static void PrintUserOptionMessage()
        {
            //Option 1 - Process html file
            //Option 2 - Retrieve scores by file name
            //Option 3 - Retrieve scores by date range
            //Option 4 - Retrive all scores in database
            //Any other key to esc or quit program
            //Console.WriteLine("Please select an option to continune");
            Console.WriteLine("Press 1, 2, 3, or 4");
        }

        private static void PrintOutput(List<ResponseInfo> output)
        {
            //TODO format 
            var test = new ResponseInfo();

            //Console.WriteLine("0----5---10---15---20---25---30---35---40---45---50---55---60---65---70---75---80---85---90" +
            //    "---95--100------110-------120");

            Console.WriteLine("{0}____{1}_________{2}_________{3}____{4}____{5}____{6}____{7}_____{8}",
                nameof(test.Id), nameof(test.FileName), nameof(test.MinScore), nameof(test.MaxScore), nameof(test.AverageScore),
                nameof(test.Tag), nameof(test.Score), nameof(test.TotalScore), nameof(test.ProcessingDate));


            foreach (var item in output)
            {
             Console.WriteLine("{0}    {1}         {2}         {3}    {4}    {5}    {6}    {7}    {8}", string.Format("{0,0} ", item.Id), string.Format("{0,-5} ", item.FileName), string.Format("{0,-7} ", item.MinScore), string.Format("{0,-7} ", item.MaxScore), string.Format("{0,-7} ", item.AverageScore.ToString("F")),
             string.Format("{0,-7} ", item.Tag), string.Format("{0,-5} ", item.Score), string.Format("{0,0} ", item.TotalScore), string.Format("{0,0} ", item.ProcessingDate));
            }
        }



    }
}
