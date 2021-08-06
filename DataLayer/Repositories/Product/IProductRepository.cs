using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IProductRepository
    {
        bool SaveChanges();
        IEnumerable<Product> Get(IEnumerable<Size> sizes, int? BrandId = null, int? ModelId = null, int? Id = null);
        Product GetById(int id);
        Product GetWithSizesAndImagesById(int id);
        void Create(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
