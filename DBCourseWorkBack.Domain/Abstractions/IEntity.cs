using System;
using System.Collections.Generic;
using System.Text;

namespace DBCourseWorkBack.Domain.Abstractions
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
