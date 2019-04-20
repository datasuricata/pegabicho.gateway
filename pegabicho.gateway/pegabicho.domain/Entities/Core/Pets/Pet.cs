using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Users;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Pets
{
    public class Pet : EntityBase
    {
        #region [ attributes ]

        //TODO Carteira clínica

        public string Name { get; private set; }
        public string ImageUri { get; private set; }
        public string ImageThumbsUri { get; private set; }

        public PetSize Size { get; private set; }
        public PetSpecie Specie { get; private set; }

        public DateTime BirthDate { get; private set; }

        public float Weight { get; private set; }

        public Race Race { get; private set; }

        #endregion

        #region [ ctor ]

        public Pet(string name, string imageUri, string imageThumbsUri, PetSize size, PetSpecie specie, DateTime birthDate, float weight, Race race) {
            Name = name;
            ImageUri = imageUri;
            ImageThumbsUri = imageThumbsUri;
            Size = size;
            Specie = specie;
            BirthDate = birthDate;
            Weight = weight;
            Race = race;
        }

        protected Pet() {

        }

        #endregion
    }
}
