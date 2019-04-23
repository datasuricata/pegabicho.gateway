using pegabicho.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users {
    public class Role : EntityBase {

        #region [ attributes ]

        public LevelAccess Level { get; private set; }
        public ModuleService Module { get; private set; }

        public string ProfileId { get; private set; }
        public Access Profile { get; private set; }

        #endregion

        #region [ ctor ]

        protected Role() {

        }

        public Role(LevelAccess level, ModuleService module) {
            Module = module;
            Level = level;
        }

        #endregion

        #region [ methods ]

        public static IEnumerable<Role> GenerateRoles(UserType type, List<ModuleService> modules = null) {
            switch (type) {
                case UserType.Customer:
                    return CustomerRoles();
                case UserType.Enterprise:
                    return ByModulesRoles(modules);
                case UserType.Provider:
                    return ByModulesRoles(modules);
                case UserType.Administrative:
                    return ByModulesRoles(modules);
                default:
                    return null;
            }
        }

        public void ChangRole(LevelAccess level) {
            Level = level;
        }

        #endregion

        #region [ roles ]

        private static IEnumerable<Role> CustomerRoles() {
            return Enum.GetValues(typeof(ModuleService))
                .Cast<ModuleService>().Select(x => new Role(LevelAccess.Basic, x)).ToList();
        }

        private static IEnumerable<Role> ByModulesRoles(List<ModuleService> modules) {
            return modules.Select(x => new Role(LevelAccess.Basic, x)).ToList();
        }

        #endregion
    }
}
