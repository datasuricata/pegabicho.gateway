using Microsoft.AspNetCore.Authorization;
using pegabicho.domain.Entities;
using System;
using System.Linq;

namespace pegabicho.api.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthModule : AuthorizeAttribute
    {
        public AuthModule(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enums.ModuleService)))
                throw new ArgumentException("Role not is a module service.");

            this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthLevel : AuthorizeAttribute
    {
        public AuthLevel(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enums.LevelAccess)))
                throw new ArgumentException("Role not is a level access.");

            this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
    }
}
