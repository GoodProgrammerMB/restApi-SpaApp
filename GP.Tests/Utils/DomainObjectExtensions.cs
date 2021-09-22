using GP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Tests.Utils
{
    public static class DomainObjectExtensions
    {
        public static TDomainObject AddToInMemory<TDomainObject>(this TDomainObject @this, DbContext context)
            where TDomainObject : class, IDomainObject
        {
            context.Add(@this);
            context.SaveChanges();

            return @this;
        }
    }
}
