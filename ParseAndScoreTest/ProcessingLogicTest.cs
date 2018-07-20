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
            resultsList= processingLogic.ProcessingFile(htmlLocation);

            Assert.IsNotNull(resultsList.htmlKeyValueList);
            Assert.IsTrue(resultsList.htmlKeyValueList.Contains(testTag));

        }




    }
}
