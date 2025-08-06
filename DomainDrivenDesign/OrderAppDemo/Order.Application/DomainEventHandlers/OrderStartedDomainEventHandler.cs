using MediatR;
using Order.Application.Repositories;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.DomainEventHandlers
{
    public class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyerRepository buyerRepository;
        public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository;
        }

        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if(notification.Order.UserName == "")
            {
                var buyer = new Buyer(notification.Order.UserName);
                //buyerRepository.Add(buyer));    //create buyer and get new id

                // set order's buyerId
            }
            return Task.CompletedTask;
        }
    }
}
