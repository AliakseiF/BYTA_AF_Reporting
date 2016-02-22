using AFGmailTestsPOM.BusinessObjects;
using AFGmailTestsPOM.Pages;
using AFGmailTestsPOM.Workflows;
using log4net;
using log4net.Config;
using NUnit.Framework;

//copy of maintest for selenium grid task execution
namespace AFGmailTestsPOM.Tests
{
    [TestFixture]
    //[Parallelizable]
    public class MainTestUsingBusinessObject : TestBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainTestUsingBusinessObject));
        //private IWebDriver driver;
        [SetUp]
        public void SayHello()
        {
            //Console.WriteLine("Starting gmail test...");
            driver.Navigate().GoToUrl(HomePage);
        }

        [TearDown]
        public void SayBye()
        {
            //Console.WriteLine("Finishing gmail test...");
            driver.Quit();
        }

        [Test]
        public void MainGmailTestBO()
        {
            //XmlConfigurator.Configure();
            //BasicConfigurator.Configure();
            log.Warn("Starting test with Logging");
            log.Info("1. Add logging for step in your solution with log4net libraries. Use different log level, e.g. info, error - DONE");

            LoginPage loginPage = new LoginPage(driver);
            LoginPageWf.LoginToGmail(loginPage, UserName, UserPass);
            Assert.That(driver.Url.Equals("https://mail.google.com/mail/u/0/#inbox"), "Log in failed");
            string to = UserName + "@gmail.com";
            string subj = "Test subject " + Random;
            string body = "Test mail body text: " + Random;
            Mail mail = new Mail();
            mail = mail.createMail(subj, to, body);
            MailBoxPage mailPage = new MailBoxPage(driver);
            MailBoxPageWf.CreateAndSaveNewMail(mailPage, mail);
            MailBoxPageWf.CheckDraft(mailPage, mail);
            MailBoxPageWf.SendMailAndCheck(mailPage, mail);
            MailBoxPageWf.LogOut(mailPage);
            Assert.That(driver.Title == "Gmail");

        }
    }
}
