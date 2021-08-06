using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly LatvianSneakersContext _latvianSneakersContext;

        public BrandRepository(LatvianSneakersContext latvianSneakersContext)
        {
            _latvianSneakersContext = latvianSneakersContext;
        }
        public bool SaveChanges()
        {
            return _latvianSneakersContext.SaveChanges() >= 0;
        }
        public IEnumerable<Brand> Get()
        {
            var brands = _latvianSneakersContext.Brands
                .Include(u => u.Models)
                .ToList();
            foreach (var brand in brands)
            {
                foreach (var model in brand.Models)
                {
                    model.Brand = null;
                }       
            }

            return brands;

        }
        public Brand GetById(int id)
        {
            var brands = _latvianSneakersContext.Brands
                .FirstOrDefault(p => p.Id == id);
            return brands;
        }
        public void Create(Brand brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }
            _latvianSneakersContext.Add(brand);
        }


        public void Delete(Brand brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }
            _latvianSneakersContext.Remove(brand);
        }

        public void Update(Brand brand)
        {
        }
    }
}
