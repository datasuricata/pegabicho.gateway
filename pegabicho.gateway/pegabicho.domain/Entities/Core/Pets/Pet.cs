using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Users;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Pets {
    public class Pet : EntityBase
    {
        #region [ attributes ]

        //todo clinical wallet?

        public string Name { get; private set; }
        public string ImageUri { get; private set; }
        public string ImageThumbsUri { get; private set; }
        public string Code { get; private set; } = $"{LetterHash(2)}-{CustomHash(4)}-{CustomHash(4)}";

        public PetSize Size { get; private set; }

        public DateTime BirthDate { get; private set; }

        public float Weight { get; private set; }

        public string RaceId { get; private set; }
        public Race Race { get; private set; }

        public string UserId { get; private set; }
        public User User { get; private set; }

        #endregion

        #region [ ctor ]

        public Pet(string name, string imageUri, PetSize size, DateTime birthDate, float weight, Race race) {
            Name = name;
            ImageUri = imageUri;
            Size = size;
            BirthDate = birthDate;
            Weight = weight;
            Race = race;
        }

        public Pet(string name, string imageUri, PetSize size, DateTime birthDate, float weight, string raceId, string userId) {
            Name = name;
            ImageUri = imageUri;
            Size = size;
            BirthDate = birthDate;
            Weight = weight;
            RaceId = raceId;
            UserId = userId;
        }

        protected Pet() {

        }

        #endregion

        #region [ methods ]

        public void ChangeSize(PetSize size) {
            Size = size;
        }

        public void ChangeProfileImage(string imageUri, string imageThumbs) {
            ImageUri = string.IsNullOrEmpty(imageUri) ? ImageUri : imageUri;
            ImageThumbsUri = string.IsNullOrEmpty(imageThumbs) ? ImageThumbsUri : imageThumbs;
        }

        public void ChangeGeneral(DateTime? date, string name, float weight){
            BirthDate = date.HasValue ? date.Value : BirthDate;
            Name = string.IsNullOrEmpty(name) ? Name : name;
            Weight = weight == 0 ? Weight : weight;
        }

        #endregion
    }
}
