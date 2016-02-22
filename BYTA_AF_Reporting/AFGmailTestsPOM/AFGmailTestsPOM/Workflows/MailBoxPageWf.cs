using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AFGmailTestsPOM.BusinessObjects;
using AFGmailTestsPOM.Pages;
using AFGmailTestsPOM.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;

namespace AFGmailTestsPOM.Workflows
{
    public static class MailBoxPageWf
    {
        //overload to use mail business object
        #region Using Business Object Mail
        public static MailBoxPage CreateAndSaveNewMail(this MailBoxPage page, Mail mail)
        {
            Console.WriteLine("Creating new mail...");
            page.newMailbnt.Click();
            page.toField.SendKeys(mail.MailReceiver);
            page.subjField.SendKeys(mail.MailHeader);
            page.bodyField.Click();
            page.bodyField.SendKeys(mail.MailBody);
            Console.WriteLine("Saving new mail...");
            page.saveAndClose.Click();
            return page;
        }

        public static MailBoxPage CheckDraft(this MailBoxPage page, Mail mail)
        {
            Console.WriteLine("Check draft...");
            page.drafts.Click();
            page.requiredMail(mail.MailHeader).Click();
            string to2 = page.receiverToCheck.GetAttribute("email");
            string subj2 = page.subjToCheck.GetAttribute("value");
            string body2 = page.bodyToCheck.Text;
            Assert.AreEqual(mail.MailReceiver, to2, "to are not equal");
            Assert.AreEqual(mail.MailHeader, subj2, "subj are not equal");
            Assert.AreEqual(mail.MailBody, body2, "body are not equal");
            return page;
        }

        public static MailBoxPage SendMailAndCheck(this MailBoxPage page, Mail mail)
        {
            Console.WriteLine("Sending mail...");
            page.sendMailbtn.Click();

            //Send mail using JS
            //IJavaScriptExecutor js = page.PageBrowser as IJavaScriptExecutor;
            //js.ExecuteScript("arguments[0].click();", page.sendMailbtn);

            //Thread.Sleep(3000);
            //new waiting
            TestBase.WaitForElement(page.PageBrowser, page.sentConfirmation);

            Console.WriteLine("Checking mail...");
            string a = string.Format("//div[@role='main']//span[contains(., '{0}')]", mail.MailHeader);
            page.sent.Click();

            //Thread.Sleep(3000);
            //new waiting
            TestBase.WaitForTab(page.PageBrowser, "#sent");

            var x = page.PageBrowser.FindElements(By.XPath(a)).Count;
            Assert.That(x == 1, "mail was not sent");
            page.drafts.Click();

            //Thread.Sleep(3000);
            //new waiting
            TestBase.WaitForTab(page.PageBrowser, "#drafts");

            var y = page.PageBrowser.FindElements(By.XPath(a)).Count;
            Assert.That(y == 0, "mail is still in draft");
            return page;
        }
        #endregion

        public static MailBoxPage CreateNewMail(this MailBoxPage page, string to, string subj, string body)
        {
            Console.WriteLine("Creating new mail...");
            page.newMailbnt.Click();
            page.toField.SendKeys(to);
            page.subjField.SendKeys(subj);
            page.bodyField.Click();
            page.bodyField.SendKeys(body);

            //Fill subject using Actions
            //new Actions(page.PageBrowser).SendKeys(page.bodyField,"A"+"F"+Keys.Space+body).Build().Perform();

            Console.WriteLine("Saving new mail...");
            page.saveAndClose.Click();
            return page;
        }


        public static MailBoxPage CheckDraft(this MailBoxPage page, string to, string subj, string body)
        {
            Console.WriteLine("Check draft...");
            page.drafts.Click();
            page.requiredMail(subj).Click();
            string to2 = page.receiverToCheck.GetAttribute("email");
            string subj2 = page.subjToCheck.GetAttribute("value");
            string body2 = page.bodyToCheck.Text;
            Assert.AreEqual(to, to2, "to are not equal");
            Assert.AreEqual(subj, subj2, "subj are not equal");
            Assert.AreEqual(body, body2, "body are not equal");
            return page;
        }

        public static MailBoxPage SendMailAndCheck(this MailBoxPage page, string subj)
        {
            Console.WriteLine("Sending mail...");
            page.sendMailbtn.Click();
            
            //Send mail using JS
            //IJavaScriptExecutor js = page.PageBrowser as IJavaScriptExecutor;
            //js.ExecuteScript("arguments[0].click();", page.sendMailbtn);

            //Thread.Sleep(3000);
            //new waiting
            TestBase.WaitForElement(page.PageBrowser, page.sentConfirmation);

            Console.WriteLine("Checking mail...");
            string a = string.Format("//div[@role='main']//span[contains(., '{0}')]", subj);
            page.sent.Click();

            //Thread.Sleep(3000);
            //new waiting
            TestBase.WaitForTab(page.PageBrowser, "#sent");

            var x = page.PageBrowser.FindElements(By.XPath(a)).Count;
            Assert.That(x == 1, "mail was not sent");
            page.drafts.Click();

            //Thread.Sleep(3000);
            //new waiting
            TestBase.WaitForTab(page.PageBrowser, "#drafts");

            var y = page.PageBrowser.FindElements(By.XPath(a)).Count;
            Assert.That(y == 0, "mail is still in draft");
            return page;
        }

        public static MailBoxPage LogOut(this MailBoxPage page)
        {
            Console.WriteLine("Log out...");
            page.profile.Click();
            page.logOut.Click();
            return page;
        }
    }
}
