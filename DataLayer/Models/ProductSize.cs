using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class ProductSize
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public Product Product { get; set; }
        public Size Size { get; set; }

    }
}
