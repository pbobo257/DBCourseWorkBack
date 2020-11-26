using DBCourseWorkBack.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCourseWorkBack.Domain.Models
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Article { get; set; }
        public double Weight { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
