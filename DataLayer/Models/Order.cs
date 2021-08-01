using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<ImageOfOrder> Images { get; set; }


    }
}
