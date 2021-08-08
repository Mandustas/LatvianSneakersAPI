using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IModelRepository
    {
        bool SaveChanges();
        IEnumerable<Model> Get(int? BrandId = null);
        Model GetById(int id);
        void Create(Model model);
        void Delete(Model model);
        void Update(Model model);
    }
}
