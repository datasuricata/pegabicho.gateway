using pegabicho.domain.Entities.Base;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users
{
    public class Address : EntityBase
    {
        public BuildingType Building { get; private set; }

        public int Number { get; private set; }
        public int Complement { get; private set; }

        public string AddressLine { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string StateProvince { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }

        public virtual User User { get; private set; }
        public virtual string UserId { get; private set; }

        public virtual List<Siege> Sieges { get; private set; }

        protected Address()
        {

        }

        public Address(string addressLine, int complement, BuildingType building, int number, string district, string city, string stateProvince, string country, string postalCode)
        {
            AddressLine = addressLine;
            Complement = complement;
            Building = building;
            Number = number;
            District = district;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            PostalCode = postalCode;
        }
    }
}
