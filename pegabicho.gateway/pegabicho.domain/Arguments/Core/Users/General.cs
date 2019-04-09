using pegabicho.domain.Entities.Base;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Users
{
    public class General : EntityBase
    {
        public GenderType GenderType { get; set; }

        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset UserDate { get; set; }

        public string InscEstadual { get; set; }
        public string InscMunicipal { get; set; }
        public string Activity { get; set; }
        public string RepresentationName { get; set; }
    }
}
