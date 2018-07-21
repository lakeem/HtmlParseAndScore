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
        public void Test_AboutUs()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("div", 12);

            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\about-us.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsTrue(resultsList.HtmlKeyValueList.Contains(testTag));

        }

        [TestMethod]
        public void Test_Blog()
        {
            var resultsList = new PageInfoList();
            


            var testTag = new KeyValuePair<string, int>("tt", 0);

            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\blog.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);

            var results = new List<ResponseInfo>();
            try
            {
                var dataAccess = new DataAccess();
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;            
            }

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsNotNull(results);

        }

        [TestMethod]
        public void Test_ContactUs()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("tt", 0);

            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\contact-us.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
                var dataAccess = new DataAccess();
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;
            }

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsNotNull(results);

        }

        [TestMethod]
        public void Test_Index()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("tt", 0);

            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\index.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
                var dataAccess = new DataAccess();
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;
            }

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsNotNull(results);       
        }


        [TestMethod]
        public void Test_Location()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("tt", 0);
            
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\location.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
                var dataAccess = new DataAccess();
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;
            }

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsNotNull(results);
        }


        [TestMethod]
        public void Test_News()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("tt", 0);

            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\news.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);

            var results = new List<ResponseInfo>();
            try
            {
                var dataAccess = new DataAccess();
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;
            }

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsNotNull(results);
        }


        [TestMethod]
        public void Test_Privacy()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("tt", 0);

            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\privacy.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
                var dataAccess = new DataAccess();
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;
            }

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void Test_Signup()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("frame", -15);
            var testLocation  = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\signup.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
                var dataAccess = new DataAccess();
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;
            }

            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsNotNull(results);
            Assert.IsTrue(resultsList.HtmlKeyValueList.Contains(testTag));

        }

       
        [TestMethod]
        public void Test_Terms()
        {
            var resultsList = new PageInfoList();

            var testTag = new KeyValuePair<string, int>("frame", -15);

            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\terms.html";

            var processingLogic = new ProcessingLogic();
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
                var dataAccess = new DataAccess();
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;
            }
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
