using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Api.DTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Article { get; set; }
        public double Weight { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
