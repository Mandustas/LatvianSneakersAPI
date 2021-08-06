using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        private readonly LatvianSneakersContext _latvianSneakersContext;

        public BannerRepository(LatvianSneakersContext latvianSneakersContext)
        {
            _latvianSneakersContext = latvianSneakersContext;
        }
        public bool SaveChanges()
        {
            return _latvianSneakersContext.SaveChanges() >= 0;
        }
        public IEnumerable<Banner> Get()
        {
            var banners = _latvianSneakersContext.Banners
                .ToList();
            return banners;

        }
        public Banner GetById(int id)
        {
            var banner = _latvianSneakersContext.Banners
                .FirstOrDefault(p => p.Id == id);
            return banner;
        }
        public void Create(Banner banner)
        {
            if (banner == null)
            {
                throw new ArgumentNullException(nameof(banner));
            }
            _latvianSneakersContext.Add(banner);
        }


        public void Delete(Banner banner)
        {
            if (banner == null)
            {
                throw new ArgumentNullException(nameof(banner));
            }
            _latvianSneakersContext.Remove(banner);
        }

        public void Update(Banner banner)
        {
            
        }
    }
}
