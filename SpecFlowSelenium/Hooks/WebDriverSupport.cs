using BoDi;
using Selenium.Pages;
using Selenium;
using TechTalk.SpecFlow;
using System;

namespace SpecFlowSelenium.Hooks
{
        [Binding]
        public class WebDriverSupport : IDisposable
        {
            private readonly IObjectContainer objectContainer;
            private TestBase _testBase;

            public WebDriverSupport(IObjectContainer objectContainer)
            {
                this.objectContainer = objectContainer;
            }

            [BeforeScenario]
            public void InitializeWebDriver()
            {
                _testBase = new TestBase();
                objectContainer.RegisterInstanceAs(_testBase);
            }

            [AfterScenario]
            public void Dispose()
            {
                //_testBase?.Dispose();
            }
        }
}
