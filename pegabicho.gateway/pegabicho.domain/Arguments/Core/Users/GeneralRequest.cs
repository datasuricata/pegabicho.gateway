using pegabicho.domain.Interfaces.Arguments.Base;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users {
    public class GeneralRequest : IRequest {
        public GenderType Type { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserId { get; set; }
    }
}
