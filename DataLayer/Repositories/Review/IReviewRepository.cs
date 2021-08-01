using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface IReviewRepository
    {
        bool SaveChanges();
        IEnumerable<Review> Get();
        Review GetById(int id);
        void Create(Review review);
        void Delete(Review review);
        void Update(Review review);
    }
}
