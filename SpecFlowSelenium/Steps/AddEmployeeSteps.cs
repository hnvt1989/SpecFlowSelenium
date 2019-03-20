using NUnit.Framework;
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
            //TODO Verify the Benefit Dashboard page ?
        }
        
        [When(@"I select Add Employee")]
        public void WhenISelectAddEmployee()
        {
            dashboard.ClickAddEmployeeButton();
        }
        
        [Then(@"I should be able to enter employee details")]
        public void ThenIShouldBeAbleToEnterEmployeeDetails()
        {
            Thread.Sleep(10000);//TODO: Validating the Add Employee Modal instead of waiting for 10 seconds
        }
        
        [Then(@"First name is ‘Jason’")]
        public void ThenFirstNameIsJason()
        {
            addEmployeeModal.SetFirstName("Jason");
        }
        
        [Then(@"Last name is ‘Smith’")]
        public void ThenLastNameIsSmith()
        {
            addEmployeeModal.SetLastName("Smith");
        }
        
        [Then(@"Number of dependent is (.*)")]
        public void ThenNumberOfDependentIs(int p0)
        {
            addEmployeeModal.SetDependants(p0);
        }
        
        [Then(@"the employee should save")]
        public void ThenTheEmployeeShouldSave()
        {
            addEmployeeModal.ClickSubmit();
        }
        
        [Then(@"I should see the employee in the table")]
        public void ThenIShouldSeeTheEmployeeInTheTable()
        {
            Assert.AreEqual(dashboard.GetRowByLastName("Smith").Displayed, true);
        }
        
        [Then(@"the salary should be (.*)")]
        public void ThenTheSalaryShouldBe(Decimal p0)
        {
            Assert.AreEqual(p0.ToString(), dashboard.GetRowByLastName("Smith").FindElement(By.CssSelector("td:nth-child(4)")).Text);
        }

        [Then(@"the dependent should be (.*)")]
        public void ThenTheDependentShouldBe(int p0)
        {
            Assert.AreEqual(p0.ToString(), dashboard.GetRowByLastName("Smith").FindElement(By.CssSelector("td:nth-child(5)")).Text);
        }

        [Then(@"the gross pay should be (.*)")]
        public void ThenTheGrossPayShouldBe(Decimal p0)
        {
            Assert.AreEqual(p0.ToString(), dashboard.GetRowByLastName("Smith").FindElement(By.CssSelector("td:nth-child(6)")).Text);
        }

        [Then(@"the benefit cost should be (.*)")]
        public void ThenTheBenefitCostShouldBe(Decimal p0)
        {
            Assert.AreEqual(p0.ToString(), dashboard.GetRowByLastName("Smith").FindElement(By.CssSelector("td:nth-child(7)")).Text);
        }

        [Then(@"the net pay should be (.*)")]
        public void ThenTheNetPayShouldBe(Decimal p0)
        {
            Assert.AreEqual(p0.ToString(), dashboard.GetRowByLastName("Smith").FindElement(By.CssSelector("td:nth-child(8)")).Text);
        }
    }
}
