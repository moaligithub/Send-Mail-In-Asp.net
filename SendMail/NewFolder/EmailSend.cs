using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMail.NewFolder
{
    public class EmailSend : IEmailSend
    {
        private readonly MailSettings _mailSettings;
        public EmailSend(IOptions<MailSettings> mailSetting)
        {
            _mailSettings = mailSetting.Value;
        }

        public async Task SendMail(string Email, string Subject, string Body)
        {
            MimeMessage message = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Email),
                Subject = Subject
            };

            message.To.Add(MailboxAddress.Parse(Email));

            BodyBuilder builder = new BodyBuilder();

            builder.HtmlBody = Body;
            message.Body = builder.ToMessageBody();
            message.From.Add(new MailboxAddress(_mailSettings.DesplayName, _mailSettings.Email));

            using var stm = new SmtpClient();
            stm.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            stm.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await stm.SendAsync(message);
            stm.Disconnect(true);
        }
    }
}
