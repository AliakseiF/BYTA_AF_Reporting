using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AFGmailTestsPOM.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _browser;

        protected IWebDriver Browser
        {
            get { return _browser; }
        }

        public BasePage(IWebDriver browser)
        {
            _browser = browser;
        }
    }
}