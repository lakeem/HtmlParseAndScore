using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseAndScore;

namespace ParseAndScoreTest
{
    [TestClass]
    public class ProcessingLogicTest
    {

        [TestMethod]
        public void TestAboutUs()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("div", 12);
            var htmlLocation = @"..\..\data\about-us";
            var testLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(htmlLocation);

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsTrue(resultsList.HtmlKeyValueList.Contains(testTag));

        }

        [TestMethod]
        public void TestSignup()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("frame", -15);
            var htmlLocation = @"..\..\data\signup";
            var testLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(htmlLocation);

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsTrue(resultsList.HtmlKeyValueList.Contains(testTag));

        }

       
        [TestMethod]
        public void TestTerms()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("frame", -15);
            var htmlLocation = @"..\..\data\terms";
            var testLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(htmlLocation);

            Assert.IsNotNull(resultsList.HtmlKeyValueList);

        }


        //TODO TEST data get all records
        [TestMethod]
        public void TestBlog()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("tt", 0);
            var htmlLocation = @"..\..\data\blog";
            var testLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(htmlLocation);

            var dataAccess = new DataAccess();
            var results = dataAccess.GetAllScoresFromFile(htmlLocation);
           
            Assert.IsNotNull(resultsList.HtmlKeyValueList);

        }



        [TestMethod]
        public void TestDatabaseConnectivity()
        {
            var fileName = "test1.html";
            var results = new List<ResponseInfo>();
            try
            {
                var storeValues = new DataAccess();
                results = storeValues.GetAllScoresFromFile(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured updating the database {0}", ex.Message);
                throw;
            }
            Assert.IsNotNull(results);
        }


        [TestMethod]
        public void TestDatabaseConnectivity_DateBaseDebugTest()
        {
            var fileName = "test1.html";
            var results = new List<ResponseInfo>();
            try
            {
                var storeValues = new DataAccess();
                results = storeValues.GetAllScoresFromFile(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured updating the database {0}", ex.Message);
                throw;
            }
            Assert.IsNotNull(results);
        }

    }
}
