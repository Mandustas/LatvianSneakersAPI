using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
    }
}
