using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IBannerRepository
    {
        bool SaveChanges();
        IEnumerable<Banner> Get();
        Banner GetById(int id);
        void Create(Banner banner);
        void Delete(Banner banner);
        void Update(Banner banner);
    }
}
