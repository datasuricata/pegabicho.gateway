using pegabicho.domain.Arguments.Core.Pets;
using pegabicho.domain.Entities.Core.Pets;
using System.Collections.Generic;

namespace pegabicho.domain.Interfaces.Services.Core {
    public interface IServicePet {
        Pet GetById(string id);
        Pet GetByCode(string code);
        List<Pet> ListByUser(string userId);
        void AddPet(PetRequest request);
        void ChangeSize(PetRequest request);
        void ChangeProfileImage(PetRequest request);
        void ChangeGeneral(PetRequest request);
        void SoftDelete(string id);
    }
}
