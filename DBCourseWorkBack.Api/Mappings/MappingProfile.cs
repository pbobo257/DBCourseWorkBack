using AutoMapper;
using DBCourseWorkBack.Api.DTOs;
using DBCourseWorkBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Api.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<CustomerCreateDTO, Customer>();
        }
    }
}
