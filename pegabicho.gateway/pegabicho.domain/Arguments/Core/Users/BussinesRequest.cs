using pegabicho.domain.Interfaces.Arguments.Base;

namespace pegabicho.domain.Arguments.Core.Users {
    public class BussinesRequest : IRequest {
        public string Activity { get; set; }
        public string InscEstadual { get; set; }
        public string InscMunicipal { get; set; }
        public string Representation { get; set; }
        public string UserId { get; set; }
    }
}
