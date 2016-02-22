using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AFGmailTestsPOM.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AFGmailTestsPOM.Pages
{
    public class MailBoxPage : BasePage
    {
        //public MailBoxPage()
        //{
        //    PageFactory.InitElements(TestBase.driver, this);
        //}

        public MailBoxPage(IWebDriver browser): base(browser)
        {
            PageFactory.InitElements(browser, this);
        }
        public IWebDriver PageBrowser { get { return Browser; } }

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji T-I-KE L3']")]
        public IWebElement newMailbnt { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@method='POST']//textarea")]
        public IWebElement toField { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@method='POST']//input[@name='subjectbox']")]
        public IWebElement subjField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        public IWebElement bodyField { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@data-tooltip='Сохранить и закрыть']")]
        public IWebElement saveAndClose { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://mail.google.com/mail/u/0/#drafts']")]
        public IWebElement drafts { get; set; }

        public IWebElement requiredMail(string subj)
        {
            string a = string.Format("//span[contains(., '{0}')]", subj);
            IWebElement requiredMail = Browser.FindElement(By.XPath(a));
            return requiredMail;
        }

        [FindsBy(How = How.XPath, Using = "//form[@method='POST']/div[2]//span")]
        public IWebElement receiverToCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//form[@method='POST']/input[@name='subject']")]
        public IWebElement subjToCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        public IWebElement bodyToCheck { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji aoO T-I-atl L3']")]
        public IWebElement sendMailbtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://mail.google.com/mail/u/0/#sent']")]
        public IWebElement sent { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://accounts.google.com/SignOutOptions?hl=ru&continue=https://mail.google.com/mail&service=mail']")]
        public IWebElement profile { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='gb_71']")]
        public IWebElement logOut { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='link_vsm']")]
        public IWebElement sentConfirmation { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='q']")]
        public IWebElement searchField { get; set; }
    }
}
