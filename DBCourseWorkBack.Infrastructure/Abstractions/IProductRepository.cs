﻿using DBCourseWorkBack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWorkBack.Infrastructure.Abstractions
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}
