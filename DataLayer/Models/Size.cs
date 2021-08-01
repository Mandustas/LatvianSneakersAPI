using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public List<ProductSize> ProductSizes { get; set; }


    }
}
