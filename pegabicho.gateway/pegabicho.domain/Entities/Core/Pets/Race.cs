using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Pets
{
    public class Race : EntityBase
    {
        public string Name { get; private set; }
        public PetSpecie Specie { get; private set; }

        public Pet Pet { get; private set; }
        public string PetId { get; private set; }

        public Race(string name, PetSpecie species) {
            Name = name;
            Specie = species;
        }

        protected Race() {
        }
    }
}