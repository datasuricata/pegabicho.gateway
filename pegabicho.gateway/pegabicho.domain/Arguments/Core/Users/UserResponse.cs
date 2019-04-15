using System;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Interfaces.Arguments.Base;

namespace pegabicho.domain.Arguments.Core.Users {
    public class UserResponse : IResponse {
        public static explicit operator UserResponse(User v) {
            throw new NotImplementedException();
        }
    }
}
