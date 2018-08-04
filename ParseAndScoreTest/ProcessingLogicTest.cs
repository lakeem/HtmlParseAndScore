using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseAndScore;

namespace ParseAndScoreTest
{
    /* This Testing class is a live test parsing and database insertion test of each html file
     * 
     * An additional class containing mock test (usign MOQ) will be added later
     */

    [TestClass]
    public class ProcessingLogicTest
    {

        /* An exhaustive testing would include a value check on the post parsing scoring logic.
         * Those test can be added at a later date along with testing values produced along side the 
         * testing data      
         */

        [TestMethod]
        public void Test_AboutUs()
        {
            var resultsList = new HtmlFileInfo();
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\about-us.html";
            IDataAccess dataAccess = new DataAccess();


            var processingLogic = new ProcessingLogic(dataAccess);
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);

            var results = new List<ResponseInfo>();
            try
            {
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
        public void Test_Blog()
        {
            var resultsList = new HtmlFileInfo();
            var testTag = new KeyValuePair<string, int>("tt", 0);
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\blog.html";
            IDataAccess dataAccess = new DataAccess();


            var processingLogic = new ProcessingLogic(dataAccess);
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);

            var results = new List<ResponseInfo>();
            try
            {
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
            var resultsList = new HtmlFileInfo();
            var testTag = new KeyValuePair<string, int>("tt", 0);
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\contact-us.html";
            IDataAccess dataAccess = new DataAccess();

            var processingLogic = new ProcessingLogic(dataAccess);
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
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
            var resultsList = new HtmlFileInfo();
            var testTag = new KeyValuePair<string, int>("tt", 0);
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\index.html";
            IDataAccess dataAccess = new DataAccess();

            var processingLogic = new ProcessingLogic(dataAccess);
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
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
            var resultsList = new HtmlFileInfo();
            var testTag = new KeyValuePair<string, int>("tt", 0);        
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\location.html";
            IDataAccess dataAccess = new DataAccess();
            var processingLogic = new ProcessingLogic(dataAccess);

            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
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
            var resultsList = new HtmlFileInfo();
            var testTag = new KeyValuePair<string, int>("tt", 0);
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\news.html";
            IDataAccess dataAccess = new DataAccess();
            var processingLogic = new ProcessingLogic(dataAccess);

            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
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
            var resultsList = new HtmlFileInfo();
            var testTag = new KeyValuePair<string, int>("tt", 0);
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\privacy.html";
            IDataAccess dataAccess = new DataAccess();

            var processingLogic = new ProcessingLogic(dataAccess);
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
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
            var resultsList = new HtmlFileInfo();
            var testTag = new KeyValuePair<string, int>("frame", -15);
            var testLocation  = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\signup.html";
            IDataAccess dataAccess = new DataAccess();
            var processingLogic = new ProcessingLogic(dataAccess);
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
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
            var resultsList = new HtmlFileInfo();
            var testTag = new KeyValuePair<string, int>("frame", -15);
            var testLocation = AppDomain.CurrentDomain.BaseDirectory;
            var shortPath = @"\data\terms.html";
            IDataAccess dataAccess = new DataAccess();
            var processingLogic = new ProcessingLogic(dataAccess);
            resultsList = processingLogic.ProcessingFile(testLocation + shortPath);
            var results = new List<ResponseInfo>();
            try
            {
                results = dataAccess.GetAllScoresFromFile(resultsList.FileName);
            }
            catch (Exception)
            {
                throw;
            }
            Assert.IsNotNull(resultsList.HtmlKeyValueList);
            Assert.IsNotNull(results);
        }

    }
}
