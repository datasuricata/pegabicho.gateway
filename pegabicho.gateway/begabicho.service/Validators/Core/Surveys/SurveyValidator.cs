using FluentValidation;
using pegabicho.domain.Entities.Core.Surveys;

namespace pegabicho.service.Validators.Core.Surveys {
    public class SurveyValidator : AbstractValidator<Survey> {
        public SurveyValidator() {
            RuleFor(r => r.TravelId)
                .NotEmpty().WithMessage("É obrigatorio a chave da viajem para prosseguir.");

            RuleFor(r => r.Images)
                .ForEach(x => x.SetValidator(new ImageSurveyValidator()));
        }
    }
}
