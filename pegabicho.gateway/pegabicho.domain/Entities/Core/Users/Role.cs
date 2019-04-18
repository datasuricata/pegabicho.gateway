using pegabicho.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users {
    public class Role : EntityBase {

        public LevelAccess Level { get; private set; }
        public ModuleService Module { get; private set; }

        public string ProfileId { get; private set; }
        public Access Profile { get; private set; }

        protected Role() {

        }

        public Role(LevelAccess level, ModuleService module) {
            Module = module;
            Level = level;
        }

        public static IEnumerable<Role> GenerateRoles(UserType type, List<Role> roles = null) {

            switch (type) {
                case UserType.Client:
                    return GetRoleClient();
                case UserType.Rider:
                    return GetRoleRider();
                default:
                    return null;
            }
        }

        #region [ generate roles ]

        private static IEnumerable<Role> GetRoleClient() {
            return Enum.GetValues(typeof(ModuleService))
                .Cast<ModuleService>()
                .Select(x => new Role(LevelAccess.Basic, x))
                .ToList();
        }

        private static IEnumerable<Role> GetRoleRider() {
            return new List<Role> {
                new Role(LevelAccess.Basic, ModuleService.Transport)
            };
        }

        #endregion
    }
}
