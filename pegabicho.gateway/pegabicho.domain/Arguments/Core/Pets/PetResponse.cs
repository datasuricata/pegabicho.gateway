﻿using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Interfaces.Arguments.Base;

namespace pegabicho.domain.Arguments.Core.Pets {
    public class PetResponse : IResponse{
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Size { get; set; }
        public string Race { get; set; }
        public string BirthDate { get; set; }
        public float Weight { get; set; }

        public static explicit operator PetResponse(Pet v) {
            return v == null ? null : new PetResponse {
                Id = v.Id,
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
