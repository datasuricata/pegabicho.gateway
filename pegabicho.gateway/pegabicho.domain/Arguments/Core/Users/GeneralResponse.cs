using pegabicho.domain.Entities.Core.Users;
using pegabicho.domain.Helpers;
using pegabicho.domain.Interfaces.Arguments.Base;

namespace pegabicho.domain.Arguments.Core.Users {
    public class GeneralResponse : IResponse {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }

        public static explicit operator GeneralResponse(General v) {
            return v == null ? null : new GeneralResponse {
                BirthDate = v.BirthDate.ToString("dd/MM/yyyy HH:mm"),
                Type = v.Type.EnumDisplay(),
                CellPhone = v.CellPhone,
                FirstName = v.FirstName,
                LastName= v.LastName,
                Phone = v.Phone,
                Id = v.Id,
            };
        }
    }
}