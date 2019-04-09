using pegabicho.domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pegabicho.domain.Arguments.Core.Users
{
    public class User : EntityBase
    {
        #region [ admission ]

        [DataType(DataType.Password)]
        public virtual string Password { get; set; }

        public string Email { get; set; }
        public string Login { get; set; }

        public virtual Access Access { get; set; }
        public virtual string AccessId { get; set; }

        #endregion

        #region [ common ]

        public virtual General GeneralInfo { get; set; }
        public virtual string GeneralInfoId { get; set; }

        public virtual Address Address { get; set; }
        public virtual string AddressId { get; set; }

        public virtual List<Wallet> Wallets { get; set; } = new List<Wallet>();
        public virtual List<Document> Documents { get; set; } = new List<Document>();

        #endregion
    }
}
