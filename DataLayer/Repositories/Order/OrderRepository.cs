using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LatvianSneakersContext _latvianSneakersContext;

        public OrderRepository(LatvianSneakersContext latvianSneakersContext)
        {
            _latvianSneakersContext = latvianSneakersContext;
        }
        public bool SaveChanges()
        {
            return _latvianSneakersContext.SaveChanges() >= 0;
        }
        public IEnumerable<Order> Get(int? Id = null)
        {
            var orders = _latvianSneakersContext.Orders
                .Include(i => i.Images)
                .ToList();
            if (Id != null)
            {
                orders = orders.Where(i => i.Id == Id).ToList();
            }
            return orders;

        }
        public Order GetById(int id)
        {
            var order = _latvianSneakersContext.Orders
                .FirstOrDefault(p => p.Id == id);
            return order;
        }
        public Order GetWithImgsById(int id)
        {
            var order = _latvianSneakersContext.Orders
                .Include(i => i.Images)
                .FirstOrDefault(p => p.Id == id);
            return order;
        }
        public void Create(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _latvianSneakersContext.Add(order);
        }


        public void Delete(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _latvianSneakersContext.Remove(order);
        }

        public void Update(Order order)
        {

        }
    }
}
