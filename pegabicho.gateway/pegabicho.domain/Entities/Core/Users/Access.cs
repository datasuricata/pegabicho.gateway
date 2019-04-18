using pegabicho.domain.Entities.Base;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users {
    public class Access : EntityBase {

        #region [ attributes ]

        public UserType Type { get; private set; }
        public UserStage Stage { get; private set; }
        public ICollection<Role> Roles { get; private set; } = new List<Role>();

        public string UserId { get; private set; }
        public User User { get; private set; }

        #endregion

        #region [ ctor ]

        public Access(UserType type) {
            Type = type;

            //TODO Refatorar no Utils algo como hasAny paramEnums[] 
            Stage = (type == UserType.Client || type == UserType.Admin 
                || type == UserType.Root) ? UserStage.Aproved : UserStage.Pending;
        }

        protected Access() {
        }

        #endregion

        #region [ methods ]

        public static Access Register(UserType type) {
            return new Access(type) {
                Roles = Role.GenerateRoles(type) as List<Role>,
            };
        }

        public void ChangeStage(UserStage stage) {
            Stage = stage;
        }

        public void ChangeType(UserType type) {
            Type = type == UserType.Root ? Type : type;
        }

        #endregion
    }
}

