using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Travels;
using System;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Surveys
{
    public class Survey : EntityBase
    {
        #region [ attributes ]

        public SurveyType Type { get; private set; }
        public DateTimeOffset DateDue { get; private set; } = DateTimeOffset.UtcNow;

        public List<ImageSurvey> Images { get; private set; } = new List<ImageSurvey>();

        public string TravelId { get; private set; }
        public Travel Travel { get; private set; }

        #endregion

        #region [ ctor ]

        protected Survey() {

        }

        public Survey(SurveyType type, string travelId, List<ImageSurvey> images) {
            Type = type;
            Images = images;
            TravelId = travelId;
        }

        #endregion

        #region [ methods ]

        public void ChangeType(SurveyType type) {
            Type = type;
        }

        #endregion
    }
}