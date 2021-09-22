using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Models.Core.Authors
{
    public class Author : DomainObject
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public static Author Create(string name, string lastName)
        {
            return new Author()
            {
                Name = name,
                LastName = lastName
            };
        }
    }
}
