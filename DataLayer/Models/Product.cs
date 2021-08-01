using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public bool IsPopular { get; set; }
        public bool IsNew { get; set; }
        public bool IsSale { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public IEnumerable<Image> Images { get; set; }


    }
}
