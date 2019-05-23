using pegabicho.domain.Arguments.Core.Surveys;
using pegabicho.domain.Entities.Core.Surveys;
using System.Collections.Generic;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Interfaces.Services.Core {
    public interface IServiceSurvey {
        Survey GetById(string id);
        List<Survey> ListSurveys();
        List<Survey> ListSurveysByType(SurveyType type);
        void AddSurvey(SurveyRequest request);
        void SoftDelete(string id);
    }
}
