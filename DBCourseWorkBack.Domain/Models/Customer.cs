using DBCourseWorkBack.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCourseWorkBack.Domain.Models
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string BonusCardNumber { get; set; }
        public int Bonuses { get; set; }
    }
}
