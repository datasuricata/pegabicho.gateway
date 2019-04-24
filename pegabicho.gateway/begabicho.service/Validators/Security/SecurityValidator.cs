using FluentValidation;
using pegabicho.domain.Entities.Core.Users;
using System.Collections.Generic;
using System.Linq;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.service.Validators.Security {
    public class SecurityValidator : AbstractValidator<User> {
        public SecurityValidator() {

            RuleFor(r => r.Profiles)
                .Must(IsBlock).WithMessage("Usuário bloqueado por favor contate o suporte.")
                .Must(IsRecused).WithMessage("Usuário recusado na plataforma contate o suporte.");
        }

        private static bool IsBlock(List<Access> profiles) {
            return profiles.Any(a => a.Stage == UserStage.Blocked);
        }

        private static bool IsRecused(List<Access> profiles) {
            return profiles.Any(a => a.Stage == UserStage.Recused);
        }
    }
}
