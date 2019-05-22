using FluentValidation;
using pegabicho.domain.Entities.Core.Pets;

namespace pegabicho.service.Validators.Core.Pets {
    public class PetValidator : AbstractValidator<Pet> {
        public PetValidator() {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Nome identificador do pet é obrigatório.");
            RuleFor(r => r.RaceId)
                .NotEmpty().WithMessage("Uma raça deve ser definida.");
            RuleFor(r => r.BirthDate)
                .NotEmpty().WithMessage("Informe a data de nascimento no pet.");
            RuleFor(r => r.UserId)
                .NotEmpty().WithMessage("Um usuário deve ser vinculado."); 
        }
    }
}