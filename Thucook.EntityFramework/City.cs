using System;
using System.Collections.Generic;

#nullable disable

namespace Thucook.EntityFramework
{
    public partial class City
    {
        public City()
        {
            Locations = new HashSet<Location>();
        }

        public short CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
