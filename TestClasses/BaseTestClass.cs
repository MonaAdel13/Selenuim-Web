using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ACE.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using ACE.Common;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter;
using System.Threading;
using NLog;

namespace ACE.TestClasses
{
    public class BaseTestClass
    {
        protected IWebDriver driver;
        protected ChromeDriverManager webDriverManager;
        protected ExtentReports extentReport;
        private static Logger log = LogManager.GetCurrentClassLogger();
        protected ExtentTest _test;
        [OneTimeSetUp]
        public void CreateDriverSetUp()
        {
            webDriverManager = new ChromeDriverManager();
            extentReport = new ExtentReports();
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\Reports");
            var htmlReporter = new ExtentHtmlReporter($"{dir}\\Reports\\TestResult.html");
            extentReport.AddSystemInfo("Environment", "SQE");
            extentReport.AddSystemInfo("Test Name", TestContext.CurrentContext.Test.Name);
            extentReport.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void SetUp()
        {
            _test = extentReport.CreateTest(TestContext.CurrentContext.Test.Name);
            //this.driver = new ChromeDriver();
            //this.driver.Manage().Window.Maximize();

            this.driver = webDriverManager.GetWebDriver();
        }


        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if(status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                log.Debug($"TestCase- {TestContext.CurrentContext.Test.Name} -Faild");
              CaptureScreenshot(webDriverManager.GetWebDriver(), TestContext.CurrentContext.Test.Name);
                extentReport.AddTestRunnerLogs($"TestCase- {TestContext.CurrentContext.Test.Name} -Faild");
                _test.Fail($"TestCase- {TestContext.CurrentContext.Test.Name} -Faild");
            }
            else
            {
                log.Debug($"TestCase- {TestContext.CurrentContext.Test.Name} - Success");

            }
            this.webDriverManager.QuiteWebDriver();
        }

        private void CaptureScreenshot(IWebDriver webDriver, string testcaseName)
        {
            
            ITakesScreenshot ts = (ITakesScreenshot)webDriver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\ScreenShots");
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Screenshots\\" + testcaseName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath);

        }
        [OneTimeTearDown]
        public void OnTimeTearDown()
        {
            extentReport.Flush();
           // driver.Quit();
        }
    }
}
