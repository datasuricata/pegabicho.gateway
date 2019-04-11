using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Pets;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users 
{
    public class User : EntityBase
    {
        #region [ admission ]

        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        public string Email { get; set; }
        public string Login { get; set; }

        public UserType Type { get; set; }
        public UserStage Stage { get; set; }

        #endregion

        #region [ common ]

        public virtual General General { get; set; }
        public virtual string GeneralId { get; set; }

        public virtual Address Address { get; set; }
        public virtual string AddressId { get; set; }

        public virtual List<Pet> Pets { get; set; } = new List<Pet>();
        public virtual List<Access> Access { get; set; } = new List<Access>();
        public virtual List<Wallet> Wallets { get; set; } = new List<Wallet>();
        public virtual List<Document> Documents { get; set; } = new List<Document>();

        #endregion
    }
}
