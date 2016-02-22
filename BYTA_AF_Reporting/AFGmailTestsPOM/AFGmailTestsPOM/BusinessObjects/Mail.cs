using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFGmailTestsPOM.BusinessObjects
{
    public class Mail
    {
        public string MailHeader;
        public string MailReceiver;
        public string MailBody;

        public void setHeader(string MailHeader)
        {
            this.MailHeader = MailHeader;
        }

        public void setReceiver(string MailReceiver)
        {
            this.MailReceiver = MailReceiver;
        }

        public void setMailBody(string MailBody)
        {
            this.MailBody = MailBody;
        }

        public Mail createMail(string MailHeader, string MailReceiver, string MailBody)
        {
            Mail newMail = new Mail();
            newMail.setHeader(MailHeader);
            newMail.setReceiver(MailReceiver);
            newMail.setMailBody(MailBody);
            return newMail;
        }

    }
}
