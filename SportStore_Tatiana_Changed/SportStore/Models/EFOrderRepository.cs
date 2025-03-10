﻿using Microsoft.EntityFrameworkCore;
using SportStore.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDBContext context;

        public EFOrderRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
