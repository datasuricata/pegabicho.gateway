using pegabicho.domain.Interfaces.Arguments.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Surveys {
    public class ImageSurveyRequest : IRequest {
        public string ImageUri { get; set; }
        public string FullName { get; set; }
        public SurveyImage Type { get; set; }
    }
}