using pegabicho.domain.Entities.Core.Surveys;
using pegabicho.domain.Interfaces.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pegabicho.domain.Arguments.Core.Surveys {
    public class SurveyResponse : IResponse {
        public string Id { get; set; }
        public string Type { get; set; }
        public string DateDue { get; set; }
        public List<string> Images { get; set; }

        public static explicit operator SurveyResponse(Survey v) {
            return v == null ? null : new SurveyResponse {
                Id = v.Id,
                DateDue = v.DateDue.ToString("dd/MM/yyyy"),
                Type = Helpers.EnumUteis.EnumDisplay(v.Type),
                Images = v.Images?.Select(x => x.ImageThumbsUri).ToList(),
            };
        }
    }
}
