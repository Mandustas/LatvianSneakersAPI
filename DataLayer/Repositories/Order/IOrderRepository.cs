using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IOrderRepository
    {
        bool SaveChanges();
        IEnumerable<Order> Get();
        Order GetById(int id);
        Order GetWithImgsById(int id);
        void Create(Order order);
        void Delete(Order order);
        void Update(Order order);
    }
}
