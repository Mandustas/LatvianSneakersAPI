using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Repositories
{
    public interface ISizeRepository
    {
        bool SaveChanges();
        IEnumerable<Size> Get();
        Size GetById(int id);
    }
}
