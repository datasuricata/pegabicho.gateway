using FluentValidation;
using pegabicho.domain.Entities.Core.Users;

namespace pegabicho.service.Validators.Core.Users {
    public class UserValidator : AbstractValidator<User> {
        public UserValidator() {
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Endereço de e-mail é obrigatório.")
                .EmailAddress().WithMessage("É necessário um e-mail válido.");
            //.EmailValidator("autotech.curitiba.br"); //valida o dominio

            //RuleFor(r => r.UserDate)
            //    .Must(ClienteMaiorDeIdade).WithMessage("Idade minima 18 anos.");
        }

        //private static bool ClienteMaiorDeIdade(DateTimeOffset dataNascimento) {
        //    return dataNascimento <= DateTimeOffset.Now.AddYears(-18);
        //}
    }
}
