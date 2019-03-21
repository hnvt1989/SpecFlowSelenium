using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace Selenium
{
    public class TestBase
    {
        //private IWebDriver _driver;
        protected string _baseUrl;

        public IWebDriver WebDriver { get; protected set; }

        public string SiteUrl
        {
            get
            {
                //return ConfigurationManager.AppSettings["SiteUrl"];
                return "C:\\dev\\QAChallengeSubmission\\SeleniumTests\\";
            }
        }
        public string Username
        {
            get
            {
                //return ConfigurationManager.AppSettings["Username"];
                return "testUser";
            }
        }

        public string Password
        {
            get
            {
                //return ConfigurationManager.AppSettings["Password"];
                return "Test1234";
            }
        }

        public TestBase()
        {
            //string webBrowser = ConfigurationManager.AppSettings["Browser"];
            string webBrowser = "chrome";

            switch (webBrowser.ToLower())
            {
                case "firefox":
                    WebDriver = new FirefoxDriver();
                    break;
                case "iexplore":
                    WebDriver = new InternetExplorerDriver();
                    break;
                case "chrome":
                    WebDriver = new ChromeDriver();
                    break;
                default:
                    break;
            }

            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                //.SetPageLoadTimeout(TimeSpan.FromSeconds(300));
            WebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);

            WebDriver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            WebDriver.Quit();
        }

    }

}
