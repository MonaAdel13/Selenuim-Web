using OpenQA.Selenium;

namespace ACE
{
    internal class HomepageTest
    {
        private IWebDriver driverTest;

        public HomepageTest(IWebDriver driverTest)
        {
            this.driverTest = driverTest;
        }
    }
}