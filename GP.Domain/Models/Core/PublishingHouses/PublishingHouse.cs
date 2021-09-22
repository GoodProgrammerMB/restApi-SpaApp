using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Domain.Models.Core.PublishingHouses
{
    public class PublishingHouse : DomainObject
    {
        public PublishingHouse()
        {

        }
        public PublishingHouse(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
