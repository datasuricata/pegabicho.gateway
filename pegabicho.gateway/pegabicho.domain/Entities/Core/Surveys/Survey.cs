using pegabicho.domain.Entities.Base;
using System;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Surveys
{
    public class Survey : EntityBase
    {
        public SurveyType Type { get; set; }
        public DateTimeOffset DateDue { get; set; } = DateTime.UtcNow;

        public virtual List<ImageSurvey> Images { get; set; } = new List<ImageSurvey>();
    }
}