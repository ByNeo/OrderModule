using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Application.Validations
{
    public class CreateOrderCommandValidator : AbstractValidator<Ordering.Domain.Data.Entities.Order>
    {
        public CreateOrderCommandValidator(ILogger<CreateOrderCommandValidator> logger)
        {
            RuleFor(command => command.AccountId).NotEmpty();
            RuleFor(command => command.OrderDetails).Must(ContainOrderItems).WithMessage("No order items found");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }


        private bool ContainOrderItems(IEnumerable<Ordering.Domain.Data.Entities.OrderDetail> orderDetails)
        {
            return orderDetails.Any();
        }
    }
}
