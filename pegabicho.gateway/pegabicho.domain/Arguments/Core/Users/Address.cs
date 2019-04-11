using pegabicho.domain.Entities.Base;
using System;
using System.Collections.Generic; 
using System.Text;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users
{
    public class Address : EntityBase
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string Complement { get; set; }

        public BuildingType Building { get; set; }
        public int Number { get; set; }

        public string District { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public double? Altitude { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
