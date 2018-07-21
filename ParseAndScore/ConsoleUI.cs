using System;
using System.Collections.Generic;


namespace ParseAndScore
{
    public class ConsoleUI
    {


        public void ConsoleAction()
        {

            Console.WriteLine("Option 1 - Process html file");
            Console.WriteLine("Option 2 - Retrieve scores by file name");
            Console.WriteLine("Option 3 - Retrieve scores by date range");
            Console.WriteLine("Option 4 - Retrive all scores in database");
            Console.WriteLine("\n");
            Console.WriteLine("Enter the number for the listed options above");
            Console.WriteLine("Press Return to quit program");
            var userOption = Console.ReadLine();

            if (userOption == 1 .ToString() || userOption == 2.ToString()|| 
                userOption == 3.ToString()|| userOption == 4.ToString() )
            {
                switch (userOption.ToString())
                {
                    case ("1"):
                        ProcessUserFile();
                        break;
                    case ("2"):
                        RetrieveByFileName();
                        break;
                    case ("3"):
                        RetrieveFileByDateRange();
                        break;
                    case ("4"):
                        GetAllRecordsInDatabase();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                return;
            }


        }

        private static void ProcessUserFile()
        {
            Console.WriteLine("Drag and drop the file onto the Console window:");
            var userFileName = Console.ReadLine();
            var processingLogic = new ProcessingLogic();

            var result = processingLogic.ProcessingFile(userFileName);
        }

        private static void RetrieveByFileName()
        {
            Console.WriteLine("Enter the name of the file to retrieve");
            var userFileName = Console.ReadLine();
            var processingLogic = new ProcessingLogic();
           var output = processingLogic.RetrieveHtmlScores(userFileName);
            PrintOutput(output);
        }


        private static void RetrieveFileByDateRange()
        {
            Console.WriteLine("Datetime can be searched using the format YYYY-MM-dd");
            Console.WriteLine("Enter starting date:");
            var start = Console.ReadLine();
            DateTime startTime = DateTime.Parse(start);
            Console.WriteLine("Enter the ending date:");
            var end = Console.ReadLine();
            DateTime endTime = DateTime.Parse(end);

            var processingLogic = new ProcessingLogic();
            var output = processingLogic.RetrieveScoresByDateRange(start, end);
            PrintOutput(output);
        }

        private static void GetAllRecordsInDatabase()
        {
            Console.WriteLine("Are you sure you wish to print all records? Type Y to proceed, any key to exit");
           
            var userAnswer = Console.ReadLine();
            if (userAnswer.ToLower().Equals("y"))
            {
                var processingLogic = new ProcessingLogic();
                var output = processingLogic.RetrieveAllScores();
                PrintOutput(output);
            }
            else
            {
                Console.WriteLine("You're not really sure or you're having doubts! Im out!!!");
                return;
            }
         
        }


        private static void PrintOutput(List<ResponseInfo> output)
        {

            var headerValues = new ResponseInfo();
            //Console.WriteLine("0----5---10---15---20---25---30---35---40---45---50---55---60---65---70---75---80---85---90" +
            //    "---95--100------110-------120");
            Console.WriteLine("\n");
            Console.WriteLine("{0}____{1}_________{2}_________{3}____{4}____{5}____{6}____{7}_____{8}",
                nameof(headerValues.Id), nameof(headerValues.FileName), nameof(headerValues.MinScore), nameof(headerValues.MaxScore), nameof(headerValues.AverageScore),
                nameof(headerValues.Tag), nameof(headerValues.Score), nameof(headerValues.TotalScore), nameof(headerValues.ProcessingDate));
            Console.WriteLine("\n");
            if (output?.Count==0)
            {
                Console.WriteLine("No Files or Data Returned");
            }

            else
            {
                foreach (var item in output)
                {
                    Console.WriteLine("{0}    {1}         {2}         {3}    {4}    {5}    {6}    {7}    {8}", string.Format("{0,0} ", item.Id), string.Format("{0,-5} ", item.FileName), string.Format("{0,-7} ", item.MinScore), string.Format("{0,-7} ", item.MaxScore), string.Format("{0,-7} ", item.AverageScore.ToString("F")),
                    string.Format("{0,-7} ", item.Tag), string.Format("{0,-5} ", item.Score), string.Format("{0,0} ", item.TotalScore), string.Format("{0,0} ", item.ProcessingDate));
                }
                Console.WriteLine("\n");
            }     
        }


    }
}
