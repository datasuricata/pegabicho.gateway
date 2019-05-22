using FluentValidation;
using pegabicho.domain.Entities.Core.Travels;

namespace pegabicho.service.Validators.Core.Travels {
    public class TravelValidator : AbstractValidator<Travel> {
        public TravelValidator() {
            RuleFor(r => r.OrderId)
                .NotNull()
                .WithMessage("Você deve vincular uma ordem de serviço a corrida.");
        }
    }
}
