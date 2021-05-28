using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACE.PageObjectModels
{
    class PlateLayoutPage
    {
        IWebDriver driver;

        private static Logger log = LogManager.GetCurrentClassLogger();
        private By PLIcon = By.XPath("/html/body/app-root/div/side-menu/p-sidebar/div/div/p-scrollpanel/div/div[1]/div/ul/li[7]/a");
        private By CreateNewPLButton = By.XPath("//*[@id=\"header-btn\"]");
        private By plateLayoutName = By.Id("plateLayoutName");
        private By plateLayoutTypeDropDown = By.XPath("//*[@id=\"createPlateLayoutForm\"]/div[2]/p-dropdown/div/div[2]/span");  
        private By plateLayoutType_W96 = By.XPath("//*[@id=\"createPlateLayoutForm\"]/div[2]/p-dropdown/div/div[3]/div/ul/p-dropdownitem[1]/li");
        private By plateLayoutType_W384 = By.XPath("//*[@id=\"createPlateLayoutForm\"]/div[2]/p-dropdown/div/div[3]/div/ul/p-dropdownitem[2]/li");
        private By resetBtn = By.Id("btnReset");
        private By cancelBtn = By.Id("btnCancel");
        private By createPLBtn = By.Id("btnCreate");

        private By wellsTableCells = By.TagName("td");


        private PlateLayoutType SelectedPLType;

      public  enum PlateLayoutType
        { 
            W96,
            W384
        }
        enum Rows 
        {
            A = 1,
            B = 2,
            C=  3,
            D = 4,
            E = 5,
            F = 6,
            G = 7,
            H = 8,
            I = 9,
            J = 10, 
            K = 11,
            L = 12,
            M = 13,
            N = 14,
            O = 15,
            P = 16

            
        }


        public  PlateLayoutPage(IWebDriver driverFromTest)
        {
            this.driver = driverFromTest;
        }

        public void NavigateToPlateLayoutPage()
        {
            try
            {
                driver.FindElement(PLIcon).Click();
                log.Info("User Naigated to Plate Layout Page successfully");
            }
            catch (Exception e)
            {
                log.Error("An Error occured while navigating to Palte Layout page " + e);
            }
        }


        public void NavigatetoNewPLPage()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement CreateNewPLButtonIcon = wait.Until(ExpectedConditions.ElementIsVisible(CreateNewPLButton));
                CreateNewPLButtonIcon.Click();

               // driver.FindElement(CreateNewPLButton).Click();
             //   Thread.Sleep(3000);
                log.Info("A new plate layout is created successfully");
            }
            catch (Exception e)
            {
                log.Error("An Error occured while creating a new plate layout " + e);

            }
        }
        public void SetPLData(string name, PlateLayoutType plateLyoutType)
        {
        
            //     driver.FindElement(plateLayoutName).SendKeys(name);
            SetLayoutName(name);
            log.Info("Plate Layout dropdown is opened");
            
            SelectPlateLayoutType( plateLyoutType);
            log.Info("Plate Layout type is selected");

        }
        private int ReturnMaxCountforRows()
        {
            switch (SelectedPLType)
            {
                case PlateLayoutType.W96:
                    return 8;
                   

                case PlateLayoutType.W384:
                    return 16;
                    

                default:
                    return 0;
                  
            }

            //if (SelectedPLType == PlateLayoutType.W96)
            //{
            //    return 8;
            //}
            //if (SelectedPLType == PlateLayoutType.W384)
            //{
            //    return 16;
            //}
            //return 0;
        }
        private int ReturnMaxCountforColumns()
        {
            switch (SelectedPLType)
            {
                case PlateLayoutType.W96:
                    return 11;


                case PlateLayoutType.W384:
                    return 23;


                default:
                    return 0;

            }
        }
        //This method workls for select random button or select all based on the boolen paramter
        //
        //
            public void SelectRandomWells( bool selectAll)
        {
            Random randomCountforRows = new Random();
            Random radomCountforColumns = new Random();
            //if ( maxRowsNumber > ReturnMaxCountforRows() || maxColumnsNumber > ReturnMaxCountforColumns())
            //{
            //    throw new Exception("Invalid max count entered");
            //}

                var rows = selectAll ? ReturnMaxCountforRows() : randomCountforRows.Next(1, ReturnMaxCountforRows());
                for (int rowNumber = 1; rowNumber <= rows; rowNumber++)
                {

                    var columns = selectAll ? ReturnMaxCountforColumns() : radomCountforColumns.Next(1, ReturnMaxCountforColumns());
                    for (int columnNumber = 1; columnNumber <= columns; columnNumber++)
                    {
                        var buttonsRowName = (Rows)rowNumber;
                        string buttonName = buttonsRowName.ToString() + columnNumber.ToString();

                        ClickButtonByName(buttonName);
                    }
                }
            
        }

        public void SelectSpecificWells(int rowNumber,int ColumnNumber)
        {
            if ( rowNumber > ReturnMaxCountforRows() || ColumnNumber > ReturnMaxCountforColumns())
            {
                throw new Exception("Invalid max count entered");
            }
            var buttonsRowName = (Rows)rowNumber;
            string buttonName = buttonsRowName.ToString() + ColumnNumber.ToString();
            ClickButtonByName(buttonName);
        }

        private void ClickButtonByName(string buttonName)
        {
            var button = driver.FindElement(By.Name(buttonName));
                button.Click();
        }
        public void ResetSelectedWells()
        {
            driver.FindElement(resetBtn).Click();
        }

        public void CancelPlayeLayoutCreation()
        {
            driver.FindElement(cancelBtn).Click();

        }
        public void CreatePL()
        {
            try 
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                IWebElement createPlateLayoutBtn = wait.Until(ExpectedConditions.ElementToBeClickable(createPLBtn));
                createPlateLayoutBtn.Click();
                log.Info("createPlateLayoutBtn is clicked");


                //driver.FindElement(createPLBtn).Click();

            }
            catch (Exception e)
            {
                log.Error(e);
            }

        }
        private void SetLayoutName(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement plateLayoutNameTextBox = wait.Until(ExpectedConditions.ElementIsVisible(plateLayoutName));
            plateLayoutNameTextBox.SendKeys(name);
          //  driver.FindElement(plateLayoutName).SendKeys(name);
        }

        private void  SelectPlateLayoutType(PlateLayoutType plateLayoutType)
        {
            driver.FindElement(plateLayoutTypeDropDown).Click();

            switch (plateLayoutType)
            {
                case PlateLayoutType.W96:
                    driver.FindElement(plateLayoutType_W96).Click();
                    log.Info($"Plate layout {plateLayoutType} is selected successfully");
                    break;

                case PlateLayoutType.W384:
                    driver.FindElement(plateLayoutType_W384).Click();
                    log.Info($"Plate layout {plateLayoutType} is selected successfully");
                    break;

                default:
                    driver.FindElement(plateLayoutType_W96).Click();
                    log.Info("The default is selected ");
                    break;
            }

            //return plateLyoutType;
        }



    }
}
