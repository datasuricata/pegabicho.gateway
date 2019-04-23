using FluentValidation;
using pegabicho.domain.Entities.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace pegabicho.service.Validators.Security {
    public class SecurityValidator : AbstractValidator<User> {
        public SecurityValidator() {
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Endereço de e-mail é obrigatório.")
                .EmailAddress().WithMessage("É necessário um e-mail válido.");


           
        }



    }
}
