using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users
{
    public class Document : EntityBase
    {
        #region [ attributes ]

        public string Value { get; private set; }
        public string ImageUri { get; private set; }
        public DocumentType Type { get; private set; }

        public string UserId { get; private set; }
        public User User { get; private set; }

        #endregion

        #region [ ctor ]

        public Document(string value, string imageUri, DocumentType type) {
            Value = value;
            ImageUri = imageUri;
            Type = type;
        }

        protected Document() {

        }

        #endregion

        #region [ methods ]

        public static Document Register(string value, string imageUri, DocumentType type, string userId) {
            return new Document(value, imageUri, type) {
                UserId = userId,
            };
        }

        #endregion
    }
}
