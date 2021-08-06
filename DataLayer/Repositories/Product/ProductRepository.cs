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
        public IEnumerable<Product> Get(IEnumerable<Size> sizes, int? BrandId = null, int? ModelId = null, int? Id = null)
        {
            var products = _latvianSneakersContext.Products
               .Include(u => u.Sizes)
               .Include(i => i.Images)
               .Include(b => b.Brand)
               .Include(m => m.Model)
               .ToList();
            if (Id != null)
            {
                products = products.Where(i => i.Id == Id).ToList();
            }
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
        public Product GetWithSizesAndImagesById(int id)
        {
            var product = _latvianSneakersContext.Products
                .Include(i => i.Images)
                .Include(s => s.ProductSizes)
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
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _latvianSneakersContext.Add(product);
        }
        public void Update(Product product)
        {

        }
        public void Delete(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _latvianSneakersContext.Remove(product);
        }

    }
}
