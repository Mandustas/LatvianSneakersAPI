using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs
{
    public class BannerCreateAndUpdateDTO
    {
        public string Path { get; set; }
        public int Order { get; set; }
        public int LangId { get; set; }

    }
}
