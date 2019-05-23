using pegabicho.domain.Arguments.Core.Surveys;
using pegabicho.domain.Entities.Core.Surveys;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using pegabicho.service.Validators.Core.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.service.Services.Core {
    public class ServiceSurvey : ServiceApp<Survey>, IServiceSurvey {
        public ServiceSurvey(IServiceProvider provider) : base(provider) {
        }

        public Survey GetById(string id) {
            try {
                return repository.GetById(id);
            } catch (Exception e) {
                Notifier.AddException<ServiceSurvey>("Erro ao localizar vistoria pela chave.", e);
                return null;
            }
        }

        public List<Survey> ListSurveys() {
            try {
                return repository.ListByReadOnly(x => !x.IsDeleted)
                    .OrderByDescending(x => x.CreatedAt).ToList();
            } catch (Exception e) {
                Notifier.AddException<ServiceSurvey>("Erro ao listar as vistorias.", e);
                return null;
            }
        }

        public List<Survey> ListSurveysByType(SurveyType type) {
            try {
                return repository.ListByReadOnly(x => !x.IsDeleted && x.Type == type)
                    .OrderByDescending(x => x.CreatedAt).ToList();
            } catch (Exception e) {
                Notifier.AddException<ServiceSurvey>("Erro ao listar as vistorias.", e);
                return null;
            }
        }

        public void AddSurvey(SurveyRequest request) {
            try {
                var images = request.Images.Select(x => new ImageSurvey(x.ImageUri, x.FullName, x.Type)).ToList();
                var survey = new Survey(request.Type, request.TravelId, images);
                ValidRegister<SurveyValidator>(survey);

            } catch (Exception e) {
                Notifier.AddException<ServiceSurvey>("Erro ao criar vistoria", e);
            }
        }

        public void SoftDelete(string id) {
            try {
                repository.SoftDelete(GetById(id));
            } catch (Exception e) {
                Notifier.AddException<ServiceSurvey>("Erro ao desativar registro.", e);
            }
        }
    }
}
