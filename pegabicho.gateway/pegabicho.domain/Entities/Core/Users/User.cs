using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users {
    public class User : EntityBase {

        #region [ attributes ]

        [DataType(DataType.Password)]
        public virtual string Password { get; private set; }
        public string Email { get; private set; }


        public General General { get; private set; }
        public Address Address { get; private set; }


        public List<Pet> Pets { get; private set; } = new List<Pet>();
        public List<Wallet> Wallets { get; private set; } = new List<Wallet>();
        public List<Access> Profiles { get; private set; } = new List<Access>();
        public List<Document> Documents { get; private set; } = new List<Document>();

        #endregion

        #region [ ctor ]

        // use to data seed
        public static User Seeder(string email, string password, General general, Address address, List<Pet> pets, List<Wallet> wallets, List<Access> profiles, List<Document> documents) {
            return new User(email, password) {
                Profiles = profiles,
                Address = address,
                Documents = documents,
                General = general,
                Pets = pets,
                Wallets = wallets,
            };
        }

        protected User() {
        }

        public User(string email, string password) {
            Password = DataSecurity.Encrypt(password);
            Email = email;
        }

        #endregion

        #region [ user steps ]

        public User Register(UserType type, string email, string password, List<Access> profiles) {
            return new User(email, password) {
                Profiles = profiles,
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

        //TODO FREE REGISTER FOR BACKOFFICE
        #endregion
    }
}
