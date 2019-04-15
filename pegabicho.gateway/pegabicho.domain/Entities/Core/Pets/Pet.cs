using pegabicho.domain.Entities.Base;
using pegabicho.domain.Entities.Core.Users;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Pets
{
    public class Pet : EntityBase
    {
        public string Name { get; set; }
        public string ImageUri { get; set; }
        public string ImageThumbsUri { get; set; }

        public PetSize Size { get; set; }
        public PetSpecie Specie { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public float Weight { get; set; }

        public virtual string ReceId { get; set; }
        public virtual Race Rece { get; set; }

        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
