using pegabicho.domain.Entities.Base;

namespace pegabicho.domain.Entities.Core.Pets
{
    public class Race : EntityBase
    {
        public string Name { get; private set; }

        public Pet Pet { get; private set; }
        public string PetId { get; private set; }

        public Race(string name) {
            Name = name;
        }

        protected Race() {
        }
    }
}