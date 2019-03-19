using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium;
using Selenium.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    public class AddEmployeeSteps
    {
        private IWebDriver driver;
        private Login login;

        [Given(@"I have logged into the portal")]
        public void GivenIHaveLoggedIntoThePortal()
        {
            //ScenarioContext.Current.Pending();
            driver = new ChromeDriver();
           
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            login = new Login(driver);
            login.NavigateToLogInPage();
            login.SetUserName(TestSettings.Username);
            login.SetPassword(TestSettings.Password);
            login.LogIn();
        }
        
        [Given(@"I am on the Benefits Dashboard page")]
        public void GivenIAmOnTheBenefitsDashboardPage()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"I select Add Employee")]
        public void WhenISelectAddEmployee()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be able to enter employee details")]
        public void ThenIShouldBeAbleToEnterEmployeeDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"First name is ‘Jason’")]
        public void ThenFirstNameIsJason()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Last name is ‘Smith’")]
        public void ThenLastNameIsSmith()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Number of dependent is (.*)")]
        public void ThenNumberOfDependentIs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the employee should save")]
        public void ThenTheEmployeeShouldSave()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see the employee in the table")]
        public void ThenIShouldSeeTheEmployeeInTheTable()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the salary should be (.*)")]
        public void ThenTheSalaryShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the dependent should be (.*)")]
        public void ThenTheDependentShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the gross pay should be (.*)")]
        public void ThenTheGrossPayShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the benefit cost should be (.*)")]
        public void ThenTheBenefitCostShouldBe(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the net pay should be (.*)")]
        public void ThenTheNetPayShouldBe(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
