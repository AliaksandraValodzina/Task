using System;
using FrameworkDesign;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestForBussinessLogic
{
    // (h) Tests
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
            [TestMethod()]
            [ExpectedException(typeof(System.NotImplementedException))]
            public void ClickTest()
            {
                string buttonNameTest = "Ok";
                Business business = new Business();
                business.Click(buttonNameTest);
            }

            [TestMethod()]
            [ExpectedException(typeof(System.NotImplementedException))]
            public void SetTextTest()
            {
                string textTest = "Ok";
                string xPathTest = "//td[@id='unit']/span";
                Business business = new Business();
                business.SetText(textTest, xPathTest);
            }
        
    }
}
