using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users {
    public class AddressRequest : IRequest {
        public BuildingType Building { get; set; }
        public int Number { get; set; }
        public int Complement { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string UserId { get; set; }
    }
}
