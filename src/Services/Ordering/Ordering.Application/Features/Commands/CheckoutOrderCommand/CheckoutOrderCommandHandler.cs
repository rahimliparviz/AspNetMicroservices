using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Repositories;
using Ordering.Application.Contracts.Services;
using Microsoft.Extensions.Logging;
using Ordering.Application.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Commands.CheckoutOrderCommand
{
    public class CheckoutOrderCommandHandler:IRequestHandler<CheckoutOrderCommand,int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(ILogger<CheckoutOrderCommandHandler> logger, IEmailService emailService, IMapper mapper, IOrderRepository orderRepository)
        {
            _logger = logger;
            _emailService = emailService;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            //TODO remove mailing functionality for simplicity
            await SendMail(newOrder);

            return newOrder.Id;
        }

        private async Task SendMail(Order newOrder)
        {
            var email = new Email() 
                { To = "test@gmail.com",
                    Body = $"Order was created.",
                    Subject = "Order was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Order {newOrder.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}