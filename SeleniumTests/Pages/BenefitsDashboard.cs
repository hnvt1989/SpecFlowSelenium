using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium.Pages
{
    public class BenefitsDashboard
    {
        private IWebDriver driver;

        public BenefitsDashboard(IWebDriver _driver)
        {
            this.driver = _driver;

            //lazy loading, wait will start only if we perform operation on control
            RetryingElementLocator factory = new RetryingElementLocator(driver, TimeSpan.FromMinutes(2));

            PageFactory.InitElements(this,factory);
        }

        public string DashboardUrl
        {
            get { return TestSettings.SiteUrl + "home.html"; }
        }

        [FindsBy(How = How.Id, Using = "btnAddEmployee")]
        [CacheLookup] //The CacheLookup property will tell Selenium to cache the web object the first time it is found
        private IWebElement AddEmployeeButton;

        public void ClickAddEmployeeButton()
        {
            AddEmployeeButton.Click();
        }
    }

    public class AddEmployeeModal
    {
        private IWebDriver driver;

        public AddEmployeeModal(IWebDriver _driver)
        {
            this.driver = _driver;

            //lazy loading, wait will start only if we perform operation on control
            RetryingElementLocator factory = new RetryingElementLocator(driver, TimeSpan.FromMinutes(2));

            PageFactory.InitElements(this, factory);
        }

        [FindsBy(How = How.CssSelector, Using = "#employees-form > div:nth-child(1) > div > input")]
        [CacheLookup] //The CacheLookup property will tell Selenium to cache the web object the first time it is found
        private IWebElement FirstName;

        [FindsBy(How = How.CssSelector, Using = "# employees-form > div:nth-child(2) > div > input")]
        [CacheLookup] //The CacheLookup property will tell Selenium to cache the web object the first time it is found
        private IWebElement LastName;

        [FindsBy(How = How.CssSelector, Using = "# employees-form > div:nth-child(3) > div > input")]
        [CacheLookup] //The CacheLookup property will tell Selenium to cache the web object the first time it is found
        private IWebElement Dependants;

        [FindsBy(How = How.CssSelector, Using = "# employees-form > div:nth-child(4) > div > button.btn.btn-primary")]
        [CacheLookup] //The CacheLookup property will tell Selenium to cache the web object the first time it is found
        private IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#employees-form > div:nth-child(4) > div > button.btn.btn-default")]
        [CacheLookup] //The CacheLookup property will tell Selenium to cache the web object the first time it is found
        private IWebElement CloseButton;

        public void SetFirstName(string firstName)
        {
            FirstName.SendKeys(firstName);
        }

        public void SetLastName(string lastName)
        {
            LastName.SendKeys(lastName);
        }

        public void SetDependants(int numOfDependants)
        {
            Dependants.SendKeys(numOfDependants.ToString());
        }

        public void ClickSubmit()
        {
            SubmitButton.Click();
        }
    }
}
