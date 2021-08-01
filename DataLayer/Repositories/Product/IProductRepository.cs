using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IProductRepository
    {
        bool SaveChanges();
        IEnumerable<Product> Get(IEnumerable<Size> sizes, int? BrandId = null, int? ModelId = null, bool? isNew = null, bool? PriceOrder = null);
        Product GetById(int id);
        void Create(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
