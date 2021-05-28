using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ACE.PageObjectModels
{
    public class HomePage
    { 
        public string homePageURL = "https://test.neuro-ace.net/";
        private  By homeWorksLabl = By.TagName("p");
       // By homeWorksLabl = By.XPath("/html/body/app-root/div/div/app-home/p");
        IWebDriver driver;
       
        public HomePage(IWebDriver driverFromTest)
        {
            this.driver = driverFromTest;
        }
        public string ReadHomeLable()
        {
            return driver.FindElement(homeWorksLabl).Text;  
        }

    }
}
