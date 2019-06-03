using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Infrastructure.Services
{
    public class EMailService : IEMailService
    {
        private readonly MailKitOptions _options;

        public EMailService(IOptions<MailKitOptions> options)
        {
            _options = options.Value;
        }

        public async Task SendAsync(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_options.SmtpHost, _options.Port, _options.UseSSL);


                client.Authenticate(_options.Username, _options.Password);

                await client.SendAsync(message);
                client.Disconnect(true);
            }
        }
    }
}
