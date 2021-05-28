using ACE.TestClasses;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE
{
    class LSPage:BaseTestClass
    {
        // private readonly By AlzhiemerProjOpt = By.XPath("(//span[@class='ng-star-inserted'])[1]");
      
        private static Logger log = LogManager.GetCurrentClassLogger();

        private By LSIcon = By.XPath("/html/body/app-root/div/side-menu/p-sidebar/div/div/p-scrollpanel/div/div[1]/div/ul/li[2]/a/div/img");
        private By CreateNewLSButton = By.Id("header-btn");
        private By LSname = By.Id("name");
 
        private readonly By projectDropDown = By.XPath("(//div[@role='button']/span)[1]");
        private readonly By AlzhiemerProjOpt = By.XPath("(//span[@class='ng-star-inserted'])[1]");
        private readonly By AmyotrophicLateralSclerosisProjOpt = By.XPath("(//span[@class='ng-star-inserted'])[2]");
        private readonly By AtaxiaProjOpt = By.XPath("(//span[@class='ng-star-inserted'])[3]");
        private By descriptionTextField = By.Id("description");

      
        public void NavigateToLS()
        {

            driver.FindElement(LSIcon).Click();
            log.Info("User is navigated to Library Synthesis page successfully");

        }
      
      public enum LS_Project
        {
            AlzhiemerProjOpt,
            AmyotrophicLateralSclerosisProjOpt,
            AtaxiaProjOpt

        }

        public void SelectProject(LS_Project projectName)
        {
            switch (projectName)
            {
                case LS_Project.AlzhiemerProjOpt:
                    driver.FindElement(AlzhiemerProjOpt).Click();
                    break;

                case LS_Project.AmyotrophicLateralSclerosisProjOpt:
                    driver.FindElement(AmyotrophicLateralSclerosisProjOpt).Click();
                    break;

                case LS_Project.AtaxiaProjOpt:
                    driver.FindElement(AtaxiaProjOpt).Click();
                    break;

                default:
                     driver.FindElement(AlzhiemerProjOpt).Click();
                    break;
            }
            

        }
    
        public void CreateNewLS()
        {

            driver.FindElement(CreateNewLSButton).Click();
            log.Info("User is navigated to a new Library Synthesis page successfully");

        }

        public void SetName()
        {

        }

    }
}
