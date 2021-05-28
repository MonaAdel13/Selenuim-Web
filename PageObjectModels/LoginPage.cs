using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ACE
{
     
  public  class LoginPage
    {
        IWebDriver driver;
        string loginPageURL = "https://test.neuro-ace.net/account/login";

         public string loginURL = "https://test.neuro-ace.net/account/login";

        private static Logger log = LogManager.GetCurrentClassLogger();


        public LoginPage(IWebDriver DriverFromTest)
        {
            this.driver = DriverFromTest;

        }
        public void NavigateTOLoginPage()
        {
            try
            {
                driver.Navigate().GoToUrl(loginPageURL);

            }catch(Exception e)
            {
                log.Error(e,"Navigation failed");
                throw;
            }

        }

        By userNameField = By.Id("username");
        By passwordField = By.Id("password");
        By logInButton = By.XPath("/html/body/app-root/div/div/ng-component/app-outer-form/div/div[2]/form/div[3]/button");

        public void UserName(String userName)
        {
            try { 
                    if (userName != null)
                    {
                        driver.FindElement(userNameField).SendKeys(userName);

                    }
                    else 
                    {
                        log.Error("The username is missing");
                    }
            }
            catch (Exception e)
                    {
                        log.Error(e,"Missing data");

                    }

        }

        public void Password (String password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void LogIn()
        {
            driver.FindElement(logInButton).Click();
        }

        public string GetTitle()
        {
            return driver.Title;
        }
        public string GetURL()
        {
            return driver.Url;
        }

        public void RefreshLOginPage()
        {
            driver.Navigate().Refresh();
        }
    }
}
