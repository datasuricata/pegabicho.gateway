using FluentValidation;
using pegabicho.domain.Entities.Core.Orders;
using System;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.service.Validators.Core.Travel {
    public class OrderValidator : AbstractValidator<Order> {
        public OrderValidator() {
            RuleFor(r => r.ClientId)
                .NotNull().WithMessage("Um cliente deve ser atribuido a nova ordem de serviço.");
            RuleFor(r => r.Type)
                .Must(TypeValid).WithMessage("Ordem de serviço não definido.");
        }

        private static bool TypeValid(OrderType type) {
            return Enum.IsDefined(typeof(OrderType), type);
        }
    }
}
