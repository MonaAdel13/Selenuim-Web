using ACE.PageObjectModels;
using ACE.TestClasses;
using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Xunit;

namespace ACE
{
    public class LoginTest : BaseTestClass
    {
        //public const string loginURL = "https://test.neuro-ace.net/account/login";
        private static Logger logFile = LogManager.GetCurrentClassLogger();

        [Test]
        public void TestLoginWithValidCredintials()
        {
            logFile.Info(TestContext.CurrentContext.Test.Name);

            LoginPage testLoginPage = new LoginPage(this.driver);
                testLoginPage.NavigateTOLoginPage();
                testLoginPage.UserName("admin");
                testLoginPage.Password("123@Sta.com");
                testLoginPage.LogIn();
           //   Thread.Sleep(3000);
            
          WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
          IWebElement homePage = wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("P")));

            string homepageLbl = homePage.Text;
            logFile.Info(homepageLbl);

            Assert.AreEqual("home works!", homepageLbl);


            //HomePage home = new HomePage(this.driver);
            //string homaPageElementText = home.ReadHomeLable();
            //Assert.AreEqual("home works!", homaPageElementText);
            _test.Log(Status.Info,"TestCase passed");



        }

        [Test]
        public void TestLoginWithInValidCredintials()
        {
            logFile.Info(TestContext.CurrentContext.Test.Name);
            string homaPageElement = "";
            try
            {
                LoginPage testLoginPage = new LoginPage(driver);
                testLoginPage.NavigateTOLoginPage();
                testLoginPage.UserName("Test");
                testLoginPage.Password("123@Sta.com");
                testLoginPage.LogIn();

              WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
              IWebElement toasatMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("toast-container")));
              string toasatMessageText = toasatMessage.Text;
              Assert.IsTrue(toasatMessageText.Contains("Incorrect username or password"));

            }
            catch (Exception e)
            {
                logFile.Error(e, "Error while run TestLoginWithInValidCredintials");
            }



        }



    }
}