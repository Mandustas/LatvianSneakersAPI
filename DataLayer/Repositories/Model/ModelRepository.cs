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
        public IEnumerable<Model> Get(int? BrandId = null)
        {
            var models = _latvianSneakersContext.Models
                .ToList();
            if (BrandId != null)
            {
                models = models.Where(b => b.BrandId == BrandId).ToList();
            }

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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _latvianSneakersContext.Add(model);
        }


        public void Delete(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _latvianSneakersContext.Remove(model);
        }

        public void Update(Model model)
        {
        }
    }
}
