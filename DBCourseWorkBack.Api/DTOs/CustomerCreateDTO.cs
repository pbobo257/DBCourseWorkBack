using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Api.DTOs
{
    public class CustomerCreateDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Bonuses { get; set; }
    }
}
