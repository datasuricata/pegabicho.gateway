using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Surveys
{
    public class ImageSurvey : EntityBase
    {
        #region [ attributes ]

        public string ImageUri { get; private set; }
        public string ImageThumbsUri { get; private set; }

        /// <summary>
        /// Receiver's subscription full name
        /// </summary>
        public string FullName { get; private set; }
        public SurveyImage Type { get; private set; }

        public string SurveyId { get; private set; }
        public Survey Survey { get; private set; }

        #endregion


        #region [ ctor ]

        protected ImageSurvey() {

        }

        /// <summary>
        /// Vincule to any survey
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="imageUri"></param>
        /// <param name="fullName"></param>
        /// <param name="type"></param>
        public ImageSurvey(string surveyId, string imageUri, string fullName, SurveyImage type) {
            ImageUri = imageUri;
            FullName = fullName;
            SurveyId = surveyId;
            Type = type; 
        }

        /// <summary>
        /// Create a simple instance
        /// </summary>
        /// <param name="imageUri"></param>
        /// <param name="fullName"></param>
        /// <param name="type"></param>
        public ImageSurvey(string imageUri, string fullName, SurveyImage type) {
            ImageUri = imageUri;
            FullName = fullName;
            Type = type;
        }

        #endregion

        #region [ methods ]

        public void SaveThumbs(string thumbsUri) {
            ImageThumbsUri = thumbsUri;
        }
        
        #endregion
    }
}
