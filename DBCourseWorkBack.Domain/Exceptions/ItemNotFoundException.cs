using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DBCourseWorkBack.Domain.Exceptions
{
    public class ItemNotFoundException : HttpException
    {
        public ItemNotFoundException() : base(HttpStatusCode.NotFound, "Item not found")
        {
        }
    }
}
