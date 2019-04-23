using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// {!ATENTION!} Use this only for data seeder
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="general"></param>
        /// <param name="address"></param>
        /// <param name="pets"></param>
        /// <param name="wallets"></param>
        /// <param name="profiles"></param>
        /// <param name="documents"></param>
        /// <returns></returns>
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

        #region [ create ]

        /// <summary>
        /// Initial Step to register any yser
        /// </summary>
        /// <param name="type"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="profiles"></param>
        /// <returns></returns>
        public static User Register(UserType type, string email, string password) {
            return new User(email, password) {
                Profiles = new List<Access> { Access.Register(type) },
            };
        }

        public void AddGeneral(GenderType type, string phone, string cellPhone, string firstName, string lastName, DateTime birthDate) {
            General = new General(type, phone, cellPhone, firstName, lastName, birthDate);
        }

        public void AddDocument(List<Document> document) {
            Documents = document;
        }

        public void AddAddress(string addressLine, int complement, BuildingType building, int number, string district, string city, string stateProvince, string country, string postalCode) {
            Address = new Address(addressLine, complement, building, number, district, city, stateProvince, country, postalCode);
        }

        public void AddPets(List<Pet> pets) {
            Pets = pets;
        }

        public void AddBussines(string activity, string inscMunicipal, string inscEstadual, string representation) {
            General.Bussinses(activity, inscEstadual, inscMunicipal, representation);
        }

        public void AddProfile(UserType type, List<ModuleService> modules) {
            Profiles.Add(Access.Register(type, modules));
        }

        #endregion
    }
}