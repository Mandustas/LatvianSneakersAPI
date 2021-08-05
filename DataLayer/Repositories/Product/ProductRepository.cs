using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LatvianSneakersContext _latvianSneakersContext;

        public ProductRepository(LatvianSneakersContext latvianSneakersContext)
        {
            _latvianSneakersContext = latvianSneakersContext;
        }
        public bool SaveChanges()
        {
            return _latvianSneakersContext.SaveChanges() >= 0;
        }
        public IEnumerable<Product> Get(IEnumerable<Size> sizes, int? BrandId = null, int? ModelId = null, bool? isNew = null, bool? PriceOrder = null)
        {
            var products = _latvianSneakersContext.Products
               .Include(u => u.Sizes)
               .Include(i => i.Images)
               .Include(b => b.Brand)
               .ToList();

            if (BrandId != null)
            {
                products = products.Where(b => b.BrandId == BrandId).ToList();
            }
            if (ModelId != null)
            {
                products = products.Where(b => b.ModelId == ModelId).ToList();
            }
            if (sizes != null && sizes.Count() != 0)
            {
                foreach (var product in products)
                {
                    var availableSizes = new List<Size>();
                    foreach (var size in product.Sizes)
                    {
                        if (sizes.Any(s => s.Value == size.Value))
                        {
                            availableSizes.Add(size);
                        }
                    }

                    product.Sizes = availableSizes;
                }
                products = products.Where(s => s.Sizes.Count() != 0).ToList();
            }
            if (isNew != null)
            {
                products = products.OrderBy(p => p.DateCreate).ToList();
            }
            if (PriceOrder != null)
            {
                if (PriceOrder == true)
                {
                    products = products.OrderBy(p => p.Price).ToList();
                }
                else
                {
                    products = products.OrderByDescending(p => p.Price).ToList();
                }

            }

            return products;

        }

        public Product GetById(int id)
        {
            var product = _latvianSneakersContext.Products
                .FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public Product GetByIdWithSizes(int id)
        {
            var product = _latvianSneakersContext.Products
                .Include(u => u.Sizes)
                .Include(i => i.Images)
                .FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public void Create(Product product)
        {
            throw new NotImplementedException();
        }
        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

    }
}
