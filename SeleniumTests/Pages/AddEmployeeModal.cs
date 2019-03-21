using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.Pages
{
    public class AddEmployeeModal
    {
        private IWebDriver driver;
        private TestBase _testBase;

        public AddEmployeeModal(TestBase testBase)
        {
            this.driver = testBase.WebDriver;

            //lazy loading, wait will start only if we perform operation on control
            RetryingElementLocator factory = new RetryingElementLocator(driver, TimeSpan.FromMinutes(2));
            PageFactory.InitElements(this, factory);
        }

        [FindsBy(How = How.CssSelector, Using = "#employees-form > div:nth-child(1) > div > input")]
        [CacheLookup]
        public IWebElement FirstName;

        [FindsBy(How = How.CssSelector, Using = "#employees-form > div:nth-child(2) > div > input")]
        [CacheLookup]
        public IWebElement LastName;

        [FindsBy(How = How.CssSelector, Using = "#employees-form > div:nth-child(3) > div > input")]
        [CacheLookup]
        public IWebElement Dependants;

        [FindsBy(How = How.CssSelector, Using = "#employees-form > div:nth-child(4) > div > button.btn.btn-primary")]
        [CacheLookup]
        public IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#employees-form > div:nth-child(4) > div > button.btn.btn-default")]
        [CacheLookup]
        public IWebElement CloseButton;

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
