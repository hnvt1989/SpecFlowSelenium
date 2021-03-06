﻿using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Selenium.Pages
{
    public class Login
    {
        private IWebDriver driver;
        private TestBase _testBase;

        public Login(TestBase testBase)
        {
            driver = testBase.WebDriver;
            _testBase = testBase;

            //lazy loading, wait will start only if we perform operation on control
            RetryingElementLocator factory = new RetryingElementLocator(driver, TimeSpan.FromMinutes(2));
            PageFactory.InitElements(this,factory);
        }

        public string LoginUrl
        {
            get { return _testBase.SiteUrl + "login.html"; }
        }

        [FindsBy(How = How.Name, Using = "form-username")]
        [CacheLookup] //The CacheLookup property will tell Selenium to cache the web object the first time it is found
        private IWebElement Username;

        [FindsBy(How = How.Name, Using = "form-password")]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement LoginButton;


        public void NavigateToLogInPage()
        {
            driver.Navigate().GoToUrl(LoginUrl);
            
        }

        public void SetUserName(string username)
        {
            Username.SendKeys(username);
        }

        public void SetPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void LogIn()
        {
            LoginButton.Click();
        }
    }
}
