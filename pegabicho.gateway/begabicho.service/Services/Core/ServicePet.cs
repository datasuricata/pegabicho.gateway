using pegabicho.domain.Arguments.Core.Pets;
using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using pegabicho.service.Validators.Core.Pets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pegabicho.service.Services.Core {
    public class ServicePet : ServiceApp<Pet>, IServicePet {

        public ServicePet(IServiceProvider provider) : base(provider) {
        }

        public Pet GetById(string id) {
            try {
                return repository.GetBy(x => !x.IsDeleted && x.Id == id);
            } catch (Exception e) {
                Notifier.AddException<ServicePet>("Erro ao localizar pet pelo identificador.", e);
                return null;
            }
        }

        public Pet GetByCode(string code) {
            try {
                return repository.GetByReadOnly(x => !x.IsDeleted &&
                    x.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase),
                        i => i.Race);
            } catch (Exception e) {
                Notifier.AddException<ServicePet>("Erro ao obter informações do pet", e);
                return null;
            }
        }

        public List<Pet> ListByUser(string userId) {
            try {
                return repository.ListByReadOnly(x => !x.IsDeleted && x.UserId == userId, i => i.Race)
                    .ToList();
            } catch (Exception e) {
                Notifier.AddException<ServicePet>("Erro ao listar pets", e);
                return null;
            }
        }

        /// <summary>
        /// Register a new pet for logged user
        /// </summary>
        /// <param name="request"></param>
        public void AddPet(PetRequest request) {
            try {
                var pet = new Pet(request.Name, request.ImageUri, request.Size, request.BirthDate, request.Weight, request.RaceId, request.UserId);
                ValidRegister<PetValidator>(pet);

            } catch (Exception e) {
                Notifier.AddException<ServicePet>("Erro ao cadastrar um novo pet.", e);
            }
        }

        /// <summary>
        /// Change size info located by id
        /// </summary>
        /// <param name="request"></param>
        public void ChangeSize(PetRequest request) {
            try {
                var pet = GetById(request.Id);
                pet.ChangeSize(request.Size);
                repository.Update(pet);
            } catch (Exception e) {
                Notifier.AddException<ServicePet>("Erro ao atualizar informações de tamanho do pet.", e);
            }
        }

        /// <summary>
        /// Change profile info and image process por minification thumbs
        /// </summary>
        /// <param name="request"></param>
        public void ChangeProfileImage(PetRequest request) {
            try {
                var pet = GetById(request.Id);
                //todo image thumbs
                pet.ChangeProfileImage(request.ImageUri, null);
                repository.Update(pet);
            } catch (Exception e) {
                Notifier.AddException<ServicePet>("Erro ao atualizar imagem de perfil.", e);
            }
        }

        /// <summary>
        /// Update general infos from pet
        /// </summary>
        /// <param name="request"></param>
        public void ChangeGeneral(PetRequest request) {
            try {
                var pet = GetById(request.Id);
                pet.ChangeGeneral(request.BirthDate, request.Name, request.Weight);
                repository.Update(pet);
            } catch (Exception e) {
                Notifier.AddException<ServicePet>("sdas", e);
            }
        }

        /// <summary>
        /// Flag IsDeleted = true, for soft delete
        /// </summary>
        /// <param name="id"></param>
        public void SoftDelete(string id) {
            try {
                repository.SoftDelete(GetById(id));
            } catch (Exception e) {
                Notifier.AddException<ServicePet>("Erro ao desativar registro.", e);
            }
        }
    }
}