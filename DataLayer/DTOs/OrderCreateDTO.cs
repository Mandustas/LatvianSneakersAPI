using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs
{
   public class OrderCreateDTO
    {
        public IEnumerable<OrderImageDTO> Images { get; set; }
    }
}
