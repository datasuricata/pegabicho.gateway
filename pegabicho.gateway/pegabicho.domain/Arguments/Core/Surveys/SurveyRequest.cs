using pegabicho.domain.Interfaces.Arguments.Base;
using System;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Arguments.Core.Surveys {
    public class SurveyRequest : IRequest {
        public string TravelId { get; set; }
        public SurveyType Type { get; set; }
        public DateTimeOffset DateDue { get; set; }
        public List<ImageSurveyRequest> Images { get; set; }
    }
}
