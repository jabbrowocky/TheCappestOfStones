using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;

using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace THEcapstone
{
    public class SendMail
    {
        
        public void SendEmail(string sendAddress , string userName, string subject, string msgContent, string htmlContent)
        {

            KeyManager key = new KeyManager();
            var apiKey = key.SendGridKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("relay@mysite.com", userName);
            var to = new EmailAddress(sendAddress);
            var htmlTextContent = "<strong>" + htmlContent + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, msgContent, htmlTextContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}