using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Common
{
    public class ChromeDriverManager
    {
        private IWebDriver webDriver;

        public void QuiteWebDriver()
        {
            if(webDriver != null)
            {
                webDriver.Quit();
                webDriver = null;
            }
        }
        public IWebDriver GetWebDriver()
        {
            if (webDriver == null)
            {
                webDriver = new ChromeDriver();
                webDriver.Manage().Window.Maximize();

            }

            return webDriver;
        }
       // public void Launch()
     //   {
     //       ChromeOptions options = new ChromeOptions();
     //       webDriver.AddArgument("--incognito");
     //       webDriver = new ChromeDriver(options);
     //       webDriver.Manage().Window.Maximize();
    //        webDriver.Manage().Cookies.DeleteAllCookies();
    //    }

    }
}
