using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMail.NewFolder
{
    public interface IEmailSend
    {
        Task SendMail(string Email, string Subject, string Body);
    }
}
