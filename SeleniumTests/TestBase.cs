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
        private IWebDriver _driver;
        protected string _baseUrl;

        public TestBase()
        {

        }
        public TestBase(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        ~TestBase()
        {
            //_driver.Quit();
        }

        public IWebDriver StartBrowser()
        {
            string webBrowser = System.Configuration.ConfigurationManager.AppSettings["Browser"]; ;
            DesiredCapabilities caps;

            bool runOnSauceLab = Convert.ToBoolean(ConfigurationManager.AppSettings["RunOnSaucelab"]);

            switch (webBrowser.ToLower())
            {
                case "firefox":
                    if (runOnSauceLab)
                    {
                        caps = DesiredCapabilities.Firefox();
                        caps.SetCapability(CapabilityType.Platform, ConfigurationManager.AppSettings["Platform"]);
                        caps.SetCapability(CapabilityType.Version, ConfigurationManager.AppSettings["FireFoxVersion"]);
                        caps.SetCapability("j6", "Testing Selenium 2 with C# on Sauce");
                        caps.SetCapability("username", "hmnd42009");
                        caps.SetCapability("accessKey", "0cc5c5c4-db5a-4e69-bfd0-67889d3557e0");
                        _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps);
                    }
                    else
                    {
                        _driver = new FirefoxDriver();
                    }
                    break;

                case "iexplore":
                    if (runOnSauceLab)
                    {
                        caps = DesiredCapabilities.InternetExplorer();
                        caps.SetCapability(CapabilityType.Platform, ConfigurationManager.AppSettings["Platform"]);
                        caps.SetCapability(CapabilityType.Version, ConfigurationManager.AppSettings["IexploreVersion"]);
                        caps.SetCapability("j6", "Testing Selenium 2 with C# on Sauce");
                        caps.SetCapability("username", "hmnd42009");
                        caps.SetCapability("accessKey", "0cc5c5c4-db5a-4e69-bfd0-67889d3557e0");
                        _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps);
                    }
                    else
                    {
                        _driver = new InternetExplorerDriver();
                    }
                    break;

                case "chrome":
                    if (runOnSauceLab)
                    {

                        caps = DesiredCapabilities.Chrome();
                        caps.SetCapability(CapabilityType.Platform, ConfigurationManager.AppSettings["Platform"]);
                        caps.SetCapability(CapabilityType.Version, "");
                        caps.SetCapability("j6", "Testing Selenium 2 with C# on Sauce");
                        caps.SetCapability("username", "xingeryu");
                        caps.SetCapability("accessKey", "66647a62-0334-41a5-92ea-0c80b14a5a50");
                        _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps);
                    }
                    else
                    {
                        _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), new ChromeOptions(), TimeSpan.FromMinutes(5));
                    }
                    break;
                default:
                    break;
            }

            //_driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            //_driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(300));
            //_driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(300));

            _driver.Manage().Window.Maximize();

            return _driver;
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(_baseUrl + url);
        }
    }

}
