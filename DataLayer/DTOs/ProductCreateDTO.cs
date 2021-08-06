using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs
{
    public class ProductCreateDTO
    {
        public string Title { get; set; }
        public bool IsPopular { get; set; }
        public bool IsNew { get; set; }
        public bool IsSale { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int[] Sizes { get; set; }
        public string[] Images { get; set; }
    }
}
