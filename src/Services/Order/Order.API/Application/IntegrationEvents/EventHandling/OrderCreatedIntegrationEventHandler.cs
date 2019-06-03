using EventBus.Core.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Order.API.Application.IntegrationEvents.Events;
using Order.API.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Application.IntegrationEvents.EventHandling
{
    public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
    {
        private readonly MailKitOptions _mailSettings;
        private readonly MailSendOptions _mailOptions;
        private readonly IEMailService _emailService;
        private readonly ILogger<OrderCreatedIntegrationEventHandler> _logger;

        public OrderCreatedIntegrationEventHandler(
            IOptions<MailKitOptions> mailSettings,
            IOptions<MailSendOptions> mailOptions,
            IEMailService emailService,
            ILogger<OrderCreatedIntegrationEventHandler> logger)
        {
            _mailSettings = mailSettings.Value;
            _mailOptions = mailOptions.Value;
            _emailService = emailService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task Handle(OrderCreatedIntegrationEvent @event)
        {
            _logger.LogDebug($"Handling the `Order Created` event from Order service");

            var orderId = @event.Id.ToString("N");


            MimeMessage _message = new MimeMessage();
            _message.To.Add(new MailboxAddress(_mailOptions.MailTo));
            _message.From.Add(new MailboxAddress(_mailSettings.Email));
            _message.Subject = "ORDER CREATED:: " + orderId;
            _message.Body = new TextPart(TextFormat.Html)
            {
                Text = "ORDER CREATED:: " + orderId
            };


            await _emailService.SendAsync(_message);


            await Task.FromResult(false);
        }
    }
}
