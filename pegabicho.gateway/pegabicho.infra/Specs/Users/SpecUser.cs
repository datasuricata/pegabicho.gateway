using pegabicho.domain.Entities.Core.Users;
using pegabicho.infra.Specs.Base;
using System;
using System.Linq.Expressions;

namespace pegabicho.infra.Specs.Users {
    public abstract class SpecUser : SpecBase<User> {
        public static Func<User, bool> Auth(User user) {
            return x => x.Email == user.Email && x.Password == user.Password;
        }
        public static Expression<Func<User, bool>> AuthExpression(User user) {
            return eActiveRecord(x => x.Email == user.Email && x.Password == user.Password);
        }
    }
}
