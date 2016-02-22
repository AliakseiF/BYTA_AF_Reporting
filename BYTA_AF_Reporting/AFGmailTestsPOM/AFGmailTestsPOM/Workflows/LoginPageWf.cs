using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AFGmailTestsPOM.Pages;
using AFGmailTestsPOM.Tests;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AFGmailTestsPOM.Workflows
{
    public static class LoginPageWf
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainTestUsingBusinessObject));
        public static LoginPage LoginToGmail(this LoginPage page,string login, string pass)
        {
            //Console.WriteLine("Log in to gmail...");
            if (page.BackArrow.Displayed)
                page.BackArrow.Click();
            page.LoginField.SendKeys(login);
            page.NextButton.Click();
            page.PassField.SendKeys(pass);
            TestBase.HighlightElementAndTakeSS(page.PageBrowser, page.SingInButton);
            log.Fatal("2-3.	Make screenshot with highlighted element and save it with human-friendly format (e.g. date_time.png) - DONE");
            page.SingInButton.Click();

            //new waiting
            MailBoxPage mailBox = new MailBoxPage(page.PageBrowser);
            TestBase.WaitForElement(page.PageBrowser, mailBox.profile);
            return page;
        }
    }
}
