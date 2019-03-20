using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class TestSettings
    {
        public string SiteUrl {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SiteUrl"];
            }
        }
        public string Username {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Username"];
            }
        }

        public string Password {
            get {
                return System.Configuration.ConfigurationManager.AppSettings["Password"];
            }
        }
    }
}
