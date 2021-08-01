using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IBrandRepository
    {
        bool SaveChanges();
        IEnumerable<Brand> Get();
        Brand GetById(int id);
        void Create(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
