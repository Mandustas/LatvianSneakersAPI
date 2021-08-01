using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly LatvianSneakersContext _latvianSneakersContext;

        public SizeRepository(LatvianSneakersContext latvianSneakersContext)
        {
            _latvianSneakersContext = latvianSneakersContext;
        }
        public bool SaveChanges()
        {
            return _latvianSneakersContext.SaveChanges() >= 0;
        }
        public IEnumerable<Size> Get()
        {
            var sizes = _latvianSneakersContext.Sizes
                .ToList();
            return sizes;

        }
        public Size GetById(int id)
        {
            var brands = _latvianSneakersContext.Sizes
                .FirstOrDefault(p => p.Id == id);
            return brands;
        }
    }
}
