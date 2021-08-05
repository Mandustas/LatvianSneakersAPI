using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly LatvianSneakersContext _latvianSneakersContext;

        public ModelRepository(LatvianSneakersContext latvianSneakersContext)
        {
            _latvianSneakersContext = latvianSneakersContext;
        }
        public bool SaveChanges()
        {
            return _latvianSneakersContext.SaveChanges() >= 0;
        }
        public IEnumerable<Model> Get()
        {
            var models = _latvianSneakersContext.Models
                .ToList();
            

            return models;

        }
        public Model GetById(int id)
        {
            var model = _latvianSneakersContext.Models
                .FirstOrDefault(p => p.Id == id);
            return model;
        }
        public void Create(Model model)
        {
            throw new NotImplementedException();
        }


        public void Delete(Model model)
        {
            throw new NotImplementedException();
        }

        public void Update(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
