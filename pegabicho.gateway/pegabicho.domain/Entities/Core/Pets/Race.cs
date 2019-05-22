using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Pets
{
    public class Race : EntityBase
    {
        #region [ attributes ]

        public string Name { get; private set; }
        public PetSpecie Specie { get; private set; }

        #endregion

        #region [ ctor ]

        public Race(string name, PetSpecie species) {
            Name = name;
            Specie = species;
        }

        protected Race() {
        }

        #endregion

        #region [ methods ]

        public override string ToString() {
            return $"{Name}-({Helpers.EnumUteis.EnumDisplay(Specie)})";
        }

        #endregion
    }
}