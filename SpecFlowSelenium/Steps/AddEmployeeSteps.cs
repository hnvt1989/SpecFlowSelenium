using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium;
using Selenium.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    public class AddEmployeeSteps
    {
        //private IWebDriver driver;
        private Login login;
        private BenefitsDashboard dashboard;
        private AddEmployeeModal addEmployeeModal;

        private TestBase _testBase;

        public AddEmployeeSteps(TestBase testBase)
        {
            this._testBase = testBase;
            login = new Login(_testBase);
            dashboard = new BenefitsDashboard(_testBase);
            addEmployeeModal = new AddEmployeeModal(_testBase);
        }

        [Given(@"I have logged into the portal")]
        public void GivenIHaveLoggedIntoThePortal()
        {

            login.NavigateToLogInPage();
            login.SetUserName(_testBase.Username);
            login.SetPassword(_testBase.Password);
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
            dashboard.ClickAddEmployeeButton();
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be able to enter employee details")]
        public void ThenIShouldBeAbleToEnterEmployeeDetails()
        {
            Thread.Sleep(10000);
            //addEmployeeModal.SetFirstName()
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"First name is ‘Jason’")]
        public void ThenFirstNameIsJason()
        {
            addEmployeeModal.SetFirstName("Jason");
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"Last name is ‘Smith’")]
        public void ThenLastNameIsSmith()
        {
            addEmployeeModal.SetLastName("Smith");
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"Number of dependent is (.*)")]
        public void ThenNumberOfDependentIs(int p0)
        {
            //ScenarioContext.Current.Pending();
            addEmployeeModal.SetDependants(p0);
        }
        
        [Then(@"the employee should save")]
        public void ThenTheEmployeeShouldSave()
        {
            //ScenarioContext.Current.Pending();
            addEmployeeModal.ClickSubmit();
        }
        
        [Then(@"I should see the employee in the table")]
        public void ThenIShouldSeeTheEmployeeInTheTable()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the salary should be (.*)")]
        public void ThenTheSalaryShouldBe(int p0)
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the dependent should be (.*)")]
        public void ThenTheDependentShouldBe(int p0)
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the gross pay should be (.*)")]
        public void ThenTheGrossPayShouldBe(int p0)
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the benefit cost should be (.*)")]
        public void ThenTheBenefitCostShouldBe(Decimal p0)
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the net pay should be (.*)")]
        public void ThenTheNetPayShouldBe(Decimal p0)
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
