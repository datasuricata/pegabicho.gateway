using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users
{
    public class User : EntityBase
    {

        #region [ attributes ]

        [DataType(DataType.Password)]
        public virtual string Password { get; private set; }
        public string Email { get; private set; }

        public UserType Type { get; private set; }
        public UserStage Stage { get; private set; }

        public General General { get; private set; }
        public Address Address { get; private set; }

        public List<Pet> Pets { get; private set; } = new List<Pet>();
        public List<Access> Access { get; private set; } = new List<Access>();
        public List<Wallet> Wallets { get; private set; } = new List<Wallet>();
        public List<Document> Documents { get; private set; } = new List<Document>();

        #endregion

        #region [ ctor ]

        protected User()
        {
        }

        public User(string email, string password)
        {
            Password = DataSecurity.Encrypt(password);
            Email = email;
        }

        #endregion

        #region [ user steps ]

        public User Register(UserType type, string email, string password)
        {
            return new User(email, password)
            {
                Stage = type == UserType.Client ? UserStage.Aproved : UserStage.Pending,
                Type = type,
            };
        }

        public void AddGeneral(GenderType type, string phone, string cellPhone, string firstName, string lastName, DateTimeOffset userDate) {
            General = new General(type, phone, cellPhone, firstName, lastName, userDate);
        }

        public void AddBussines(string activity, string inscMunicipal, string inscEstadual, string representation) {
            General.Bussinses(activity, inscEstadual, inscMunicipal, representation);
        }

        public void AddAddress(string addressLine, int complement, BuildingType building, int number, string district, string city, string stateProvince, string country, string postalCode) {
            Address = new Address(addressLine, complement, building, number, district, city, stateProvince, country, postalCode);
        }

        // TODO Register Office to B.O. and Vitrine

        public void ChangeStage(UserStage stage) {
            Stage = stage;
        }

        public void ChangeType(UserType type) {
            Type = type == UserType.Root ? Type : type;
        }

        #endregion
    }
}
