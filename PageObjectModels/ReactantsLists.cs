using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ACE.PageObjectModels
{
    public class ReactantsLists
    {
        
           public string ReactantListsURL = "https://test.neuro-ace.net/reactant-list";
            IWebDriver driver;

            public ReactantsLists(IWebDriver driverFromTest)
            {
                this.driver = driverFromTest;
            }
        public void NavigateTOReactantsListsPage()
        {
            driver.Navigate().GoToUrl(ReactantListsURL);

        }
    }
}
