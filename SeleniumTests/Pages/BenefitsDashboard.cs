using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium.Pages
{
    public class BenefitsDashboard
    {
        private IWebDriver driver;
        private TestBase _testBase;

        public BenefitsDashboard(TestBase testBase)
        {
            this._testBase = testBase;
            this.driver = testBase.WebDriver;

            //lazy loading, wait will start only if we perform operation on control
            RetryingElementLocator factory = new RetryingElementLocator(driver, TimeSpan.FromMinutes(2));

            PageFactory.InitElements(this,factory);
        }

        public string DashboardUrl
        {
            get { return _testBase.SiteUrl + "home.html"; }
        }

        [FindsBy(How = How.Id, Using = "btnAddEmployee")]
        [CacheLookup] //The CacheLookup property will tell Selenium to cache the web object the first time it is found
        private IWebElement AddEmployeeButton;

        [FindsBy(How = How.Id, Using = "employee-table")]
        private IWebElement EmployeeTable;

        public void ClickAddEmployeeButton()
        {
            AddEmployeeButton.Click();
        }

        public IWebElement GetRowByLastName(string lastName)
        {
            return EmployeeTable.FindElement(By.XPath("//td[./text()='" + lastName + "']")).FindElement(By.XPath(".."));
        }
    }
}
