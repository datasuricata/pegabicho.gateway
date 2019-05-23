using FluentValidation;
using pegabicho.domain.Entities.Core.Surveys;

namespace pegabicho.service.Validators.Core.Surveys {
    public class ImageSurveyValidator : AbstractValidator<ImageSurvey>{
        public ImageSurveyValidator() {
            RuleFor(r => r.FullName)
                .NotEmpty().WithMessage("Nome do responsável é obrigatório.");
            RuleFor(r => r.ImageUri)
                .NotEmpty().WithMessage("Url da imagem é obrigatória");
        }
    }
}
