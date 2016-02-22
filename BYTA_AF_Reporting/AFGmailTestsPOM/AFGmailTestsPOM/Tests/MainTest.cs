using System;
using System.Threading;
using AFGmailTestsPOM.Pages;
using AFGmailTestsPOM.Workflows;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;


namespace AFGmailTestsPOM.Tests
{
    [TestFixture]
    //[Parallelizable]
    public class MainTest : TestBase
    {
        //private IWebDriver driver;
        [SetUp]
        public void SayHello()
        {
            Console.WriteLine("Starting gmail test...");
            driver.Navigate().GoToUrl(HomePage);
        }

        [TearDown]
        public void SayBye()
        {
            Console.WriteLine("Finishing gmail test...");
            driver.Close();
        }

        [Test]
        [Ignore("Ignored by AF")]
        public void MainGmailTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            LoginPageWf.LoginToGmail(loginPage, UserName, UserPass);
            Assert.That(driver.Url.Equals("https://mail.google.com/mail/#inbox"), "Log in failed");

            MailBoxPage mailPage = new MailBoxPage(driver);
            string to = UserName + "@gmail.com";
            string subj = "Test subject " + Random;
            string body = "Test mail body text: " + Random;
            MailBoxPageWf.CreateNewMail(mailPage, to, subj, body);
            MailBoxPageWf.CheckDraft(mailPage,to, subj, body);
            MailBoxPageWf.SendMailAndCheck(mailPage,subj);
            MailBoxPageWf.LogOut(mailPage);
            Assert.That(driver.Title == "Gmail");

        }
    }
}
