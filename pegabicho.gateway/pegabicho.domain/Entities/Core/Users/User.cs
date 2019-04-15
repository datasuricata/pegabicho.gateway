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

        public UserType Type { get; private set; }
        public UserStage Stage { get; private set; }

        public virtual General General { get; private set; }
        public virtual string GeneralId { get; private set; }

        public virtual Address Address { get; private set; }
        public virtual string AddressId { get; private set; }

        public virtual List<Pet> Pets { get; private set; } = new List<Pet>();
        public virtual List<Access> Access { get; private set; } = new List<Access>();
        public virtual List<Wallet> Wallets { get; private set; } = new List<Wallet>();
        public virtual List<Document> Documents { get; private set; } = new List<Document>();

        #endregion

        #region [ ctor ]

        protected User() {
        }

        public User(string email, string password) {
            Password = DataSecurity.Encrypt(password);
            Email = email;
        }

        #endregion

        #region [ user steps ]

        public User InitialRegister(UserType type, string email, string password) {

            var user = new User(email, password) {
                Type = type
            };

            if (type == UserType.Client)
                user.Stage = UserStage.Aproved;
            else
                user.Stage = UserStage.Pending;

            return user;
        }

        public void GeneralRegister(GenderType type, string phone, string cellPhone, string firstName, string lastName, DateTimeOffset userDate) {
            General = new General(type, phone, cellPhone, firstName, lastName, userDate);
        }

        public void BussinesRegister(string activity, string inscMunicipal, string inscEstadual, string representation) {
            General.Bussinses(activity, inscEstadual, inscMunicipal, representation);
        }

        public void ChangeStage(UserStage stage) {
            Stage = stage;
        }

        public void ChangeType(UserType type) {
            Type = type;
        }

        #endregion
    }
}
