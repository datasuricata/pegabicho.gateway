using FluentValidation;
using pegabicho.domain.Entities.Core.Ticket;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.service.Validators.Core.Travel {
    public class TicketValidator : AbstractValidator<Ticket> {
        public TicketValidator() {
            RuleFor(r => r.ClientId)
                .NotNull().WithMessage("Um cliente deve ser atribuido ao ticket.");
            RuleFor(r => r.Type)
                .Must(TypeValid).WithMessage("Ticket de serviço indefinido.");
        }

        private static bool TypeValid(TicketType type) {
            return Enum.IsDefined(typeof(TicketType), type);
        }
    }
}
