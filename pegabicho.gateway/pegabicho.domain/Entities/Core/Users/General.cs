using pegabicho.domain.Entities.Base;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users
{
    public class General : EntityBase
    {
        #region [ attributes ]

        public GenderType Type { get; private set; }

        public string Phone { get; private set; }
        public string CellPhone { get; private set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTimeOffset UserDate { get; private set; }

        public string Activity { get; private set; }
        public string InscEstadual { get; private set; }
        public string InscMunicipal { get; private set; }
        public string Representation { get; private set; }

        public string UserId { get; private set; }
        public User User { get; private set; }

        #endregion

        #region [ ctor ]

        protected General() {
        }

        public General(GenderType type, string phone, string cellPhone, string firstName, string lastName, DateTimeOffset userDate) {
            Type = type;
            Phone = phone;
            LastName = lastName;
            UserDate = userDate;
            CellPhone = cellPhone;
            FirstName = firstName;
        }

        #endregion

        #region [ methods ]

        public string GetName() {
            return $"{FirstName} {LastName}";
        }

        public void Bussinses(string activity, string inscEstadual, string inscMunicipal, string representation) {
            Activity = activity;
            InscEstadual = inscEstadual;
            InscMunicipal = inscMunicipal;
            Representation = representation;
        }
        
        #endregion
    }
}
