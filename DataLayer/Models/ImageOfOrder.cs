using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class ImageOfOrder
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public bool IsVideo { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
