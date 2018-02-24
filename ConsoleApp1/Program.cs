using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var order = new Order {Id = 1};
            var orderDetail1 = new OrderDetail(100, order);
            var orderDetail2 = new OrderDetail(200, order);
            var orderDetail3 = new OrderDetail(300, order);
            order.OrderDetails = new[] {orderDetail1, orderDetail2, orderDetail3};

            foreach (var orderDetail in order.OrderDetails)
            {
                Console.WriteLine($"Detail ID: {orderDetail.Id} for the Order ID: {order.Id}");
            }
        }
    }

    public interface IBar
    {
        int Id { get; set; }
        IEnumerable<IBaz> Bazes { get; set; }
    }

    public interface IBaz
    {
        int Id { get; set; }
        IBar Parent { get; }
    }

    public interface IOrder
    {
        int Id { get; set; }
        IEnumerable<IOrderDetail> OrderDetails { get; set; }
    }

    public interface IOrderDetail
    {
        int Id { get; set; }
        IOrder Parent { get; }
    }

    class Order : IOrder 
    {
        public int Id { get; set; }
        public IEnumerable<IOrderDetail> OrderDetails { get; set; } = new List<IOrderDetail>();
    }

    class OrderDetail : IOrderDetail
    {
        public int Id { get; set; }
        public IOrder Parent { get; }

        public OrderDetail(int id, IOrder parent)
        {
            Id = id;
            Parent = parent;
        }
    }
}
