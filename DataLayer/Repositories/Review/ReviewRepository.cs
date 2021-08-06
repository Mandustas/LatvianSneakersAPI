using DataLayer.Contexts;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly LatvianSneakersContext _latvianSneakersContext;

        public ReviewRepository(LatvianSneakersContext latvianSneakersContext)
        {
            _latvianSneakersContext = latvianSneakersContext;
        }
        public bool SaveChanges()
        {
            return _latvianSneakersContext.SaveChanges() >= 0;
        }
        public IEnumerable<Review> Get()
        {
            var reviews = _latvianSneakersContext.Reviews
                .ToList();
            return reviews;

        }
        public Review GetById(int id)
        {
            var review = _latvianSneakersContext.Reviews
                .FirstOrDefault(p => p.Id == id);
            return review;
        }
        public void Create(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }
            _latvianSneakersContext.Add(review);
        }


        public void Delete(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }
            _latvianSneakersContext.Remove(review);
        }

        public void Update(Review review)
        {

        }
    }
}
