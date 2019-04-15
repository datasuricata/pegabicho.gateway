using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Surveys
{
    public class ImageSurvey : EntityBase
    {
        public string ImageUri { get; set; }
        public string ImageThumbsUri { get; set; }

        /// <summary>
        /// Receiver's subscription full name
        /// </summary>
        public string FullName { get; set; } 
        public SurveyImage Type { get; set; }
    }
}
