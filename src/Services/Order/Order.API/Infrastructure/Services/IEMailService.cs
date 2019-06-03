using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Order.API.Infrastructure.Services
{
    public interface IEMailService
    {
        Task SendAsync(MimeMessage message);
    }
}
