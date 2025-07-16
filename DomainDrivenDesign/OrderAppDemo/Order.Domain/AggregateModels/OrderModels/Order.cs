using Order.Domain.Events;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class Order: BaseEntity, IAggregateRoot
    {
        
        public DateTime OrderDate { get; private set; }

        public string Description { get; private set; }

        public string UserName { get; set; }
        public string OrderStatus { get; private set; }
        public Address Address{ get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order(DateTime orderDate, string description, string userName, string orderStatus, Address address, ICollection<OrderItem> orderItems)
        {

            if (OrderDate < DateTime.Now)
                throw new Exception("Order date must be greater than now");

            if (address.City == "")
                throw new Exception("city connot be empty");

            OrderDate = orderDate;
            Description = description;
            UserName = userName;
            OrderStatus = orderStatus;
            Address = address;
            OrderItems = orderItems;

            AddDomainEvents(new OrderStartedDomainEvent("", this));
        }

        public void AddOrderItem(int quantity, decimal price, int productId)
        {
            OrderItem item = new(quantity, price, productId);

            OrderItems.Add(item);
        }
    }
}
