using Newtonsoft.Json;
using pegabicho.domain.Interfaces.Arguments.Base;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Pets {
    public class PetRequest : IRequest {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public PetSize Size { get; set; }
        public DateTime BirthDate { get; set; }
        public float Weight { get; set; }
        public string RaceId { get; set; }

        [JsonIgnore]
        public string UserId { get; set; }
    }
}
