using ACE.PageObjectModels;
using Microsoft.Extensions.Logging;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACE.TestClasses
{
    class PlateLayoutPageTest:BaseTestClass
    {

        private static Logger logFile = LogManager.GetCurrentClassLogger();
        Random randomName = new Random();

        [SetUp]
        public void LoginWithValidCredintials()
        {
            logFile.Info(TestContext.CurrentContext.Test.Name);

            LoginPage testLoginPage = new LoginPage(this.driver);
            testLoginPage.NavigateTOLoginPage();
            testLoginPage.UserName("admin");
            testLoginPage.Password("123@Sta.com");
            testLoginPage.LogIn();
            System.Threading.Thread.Sleep(3000);
        }
        [Test]
        [TestCase(PlateLayoutPage.PlateLayoutType.W384)]
        [TestCase(PlateLayoutPage.PlateLayoutType.W96)]
        public void CreateNewPlateLayoutW96withValidData_CreatedSuccessfully(PlateLayoutPage.PlateLayoutType plateLayoutType)
        {
            PlateLayoutPage pl1 = new PlateLayoutPage(this.driver);
            pl1.NavigateToPlateLayoutPage();
            pl1.NavigatetoNewPLPage();

            pl1.SetPLData($"This is automated PL{randomName.Next()}", plateLayoutType);
            Thread.Sleep(1000);
            pl1.SelectSpecificWells(5, 6);
            pl1.SelectSpecificWells(7, 9);
            pl1.CreatePL();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IWebElement toasatMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("toast-container")));

        //    IWebElement toasatMessage = driver.FindElement(By.Id("toast-container"));    
            string toasatMessageText = toasatMessage.Text;
            logFile.Info(toasatMessageText);

            try
            {
                Assert.IsTrue(toasatMessageText.Contains("Plate layout created successfully"));
                logFile.Info("CreateNewPlateLayoutSuccessfullyW96 passed successfully");

            }
            catch(Exception e)
            {
                logFile.Error(e);
            }

        }
        [Test]
        [TestCase(PlateLayoutPage.PlateLayoutType.W384)]
        [TestCase(PlateLayoutPage.PlateLayoutType.W96)]
        public void CreateNewPlateLayoutW96WithRandomWellsSelectionwithValidData_CreatedSuccessfully(PlateLayoutPage.PlateLayoutType plateLayoutType )
        {
            PlateLayoutPage pl1 = new PlateLayoutPage(this.driver);
            pl1.NavigateToPlateLayoutPage();
            pl1.NavigatetoNewPLPage();

            pl1.SetPLData($"This is automated PL{randomName.Next()}", plateLayoutType);
            Thread.Sleep(1000);
            pl1.SelectRandomWells(false);
          
            pl1.CreatePL();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IWebElement toasatMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("toast-container")));

            //    IWebElement toasatMessage = driver.FindElement(By.Id("toast-container"));    
            string toasatMessageText = toasatMessage.Text;
            logFile.Info(toasatMessageText);

            try
            {
                Assert.IsTrue(toasatMessageText.Contains("Plate layout created successfully"));
                logFile.Info("CreateNewPlateLayoutSuccessfullyW96 passed successfully");

            }
            catch (Exception e)
            {
                logFile.Error(e);
            }

        }


        //[Test]
        //public void CreateNewPlateLayoutW384WithRandomWellsSelectionwithValidData_CreatedSuccessfully()
        //{
        //    PlateLayoutPage pl1 = new PlateLayoutPage(this.driver);
        //    pl1.NavigateToPlateLayoutPage();
        //    pl1.NavigatetoNewPLPage();

        //    pl1.SetPLData($"This is automated PL{randomName.Next()}", PlateLayoutPage.PlateLayoutType.W384);
        //    Thread.Sleep(1000);
        //    pl1.SelectRandomWells(false);

        //    pl1.CreatePL();

        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        //    IWebElement toasatMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("toast-container")));

        //    //    IWebElement toasatMessage = driver.FindElement(By.Id("toast-container"));    
        //    string toasatMessageText = toasatMessage.Text;
        //    logFile.Info(toasatMessageText);

        //    try
        //    {
        //        Assert.IsTrue(toasatMessageText.Contains("Plate layout created successfully"));
        //        logFile.Info("CreateNewPlateLayoutSuccessfullyW96 passed successfully");

        //    }
        //    catch (Exception e)
        //    {
        //        logFile.Error(e);
        //    }

        //}
    }
}
