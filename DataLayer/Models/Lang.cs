using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Lang
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Banner> Banners { get; set; }

    }
}
