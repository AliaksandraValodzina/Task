using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using Part10_Nuget_MSTest;

namespace MsTest
{
    [TestClass]
    public class Test : BaseClass
    {
        public static BrowserController controller = new BrowserController();

        public TestContext TestContext { get; set; }

        public static StringBuilder Log
        {
            get
            {
                if (s_log == null)
                {
                    s_log = new StringBuilder();
                }

                return s_log;
            }
        }

        static StringBuilder s_log;

        [TestMethod]
        [TestCategory("smoke")]
        //[Ignore]
        //[Timeout(5000), Owner("Mike"), Description("Fix problems")]
        //[ExpectedException(typeof(Exception))]
        [DeploymentItem("Data.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "|DataDirectory|\\Data.xml",
                   "test",
                    DataAccessMethod.Sequential)]
        public void TestMethodSetUp()
        {
            Log.AppendLine("TestMethodSetUp");

            controller.Path = (string)TestContext.DataRow["address"];
            Log.AppendLine("address = " + controller.Path);

            controller.Setup();
        }

        [TestMethod]
        [TestCategory("daily")]
        //[Timeout(1000), Owner("Lora"), Description("Add comments")]
        public void TestMethodTearDown()
        {
            Log.AppendLine("TestMethodTearDown");

            controller.TearDown();
        }


        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Log.AppendLine("ClassInit");

            controller.Driver = new FirefoxDriver();
        }

        [ClassCleanup]
        public static void ClassClean()
        {
            Log.AppendLine("ClassClean");

            string filePath = ConfigurationManager.AppSettings["filePath"];
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(Log);
            }
        }

        [TestInitialize]
        public void TestInit()
        {
            Log.AppendLine("TestInit");

        }

        [TestCleanup]
        public void TestClean()
        {
            Log.AppendLine("TestClean");

            if (controller.BrowserStatus.Equals("on"))
            {
                controller.TearDown();
            }

        }
    }
}
