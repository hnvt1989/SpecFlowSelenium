using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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

            //TODO: Can we inject the Page Objects as dependencies ?
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
            //TODO more validations of the Benefit Dashboard page
            Assert.AreEqual(true, dashboard.EmployeeTable.Displayed);
            Assert.AreEqual(true, dashboard.AddEmployeeButton.Displayed);
            Assert.AreEqual(true, dashboard.AddEmployeeButton.Enabled);
        }
        
        [When(@"I select Add Employee")]
        public void WhenISelectAddEmployee()
        {
            dashboard.ClickAddEmployeeButton();

            //wait until the Add Employ modal displayed
            var wait = new WebDriverWait(_testBase.WebDriver, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("addEmployeeModal")));
        }
        
        [Then(@"I should be able to enter employee details")]
        public void ThenIShouldBeAbleToEnterEmployeeDetails()
        {
            Assert.AreEqual(true, addEmployeeModal.FirstName.Displayed);
            Assert.AreEqual(true, addEmployeeModal.FirstName.Enabled);
            Assert.AreEqual(true, addEmployeeModal.LastName.Displayed);
            Assert.AreEqual(true, addEmployeeModal.LastName.Enabled);
            Assert.AreEqual(true, addEmployeeModal.Dependants.Displayed);
            Assert.AreEqual(true, addEmployeeModal.Dependants.Enabled);

            //TODO: More validation of the Add Employee Modal ?
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
            //TODO: maybe a row could be a class, for better encapsulating and accessing fields
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
            //NOTE this assertion will fail
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
