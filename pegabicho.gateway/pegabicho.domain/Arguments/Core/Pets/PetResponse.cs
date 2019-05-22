using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Interfaces.Arguments.Base;

namespace pegabicho.domain.Arguments.Core.Pets {
    public class PetResponse : IResponse{
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Size { get; private set; }
        public string Race { get; private set; }
        public string BirthDate { get; private set; }
        public float Weight { get; private set; }

        public static explicit operator PetResponse(Pet v) {
            return v == null ? null : new PetResponse {
                BirthDate = v.BirthDate.ToString("dd/MM/yyyy"),
                Code = v.Code,
                Name = v.Name,
                Weight = v.Weight,
                Race = v.Race?.ToString(),
                Size = Helpers.EnumUteis.EnumDisplay(v.Size),
            };
        }
    }
}
