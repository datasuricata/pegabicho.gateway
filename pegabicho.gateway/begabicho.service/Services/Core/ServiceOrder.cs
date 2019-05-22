using pegabicho.domain.Arguments.Core.Orders;
using pegabicho.domain.Entities.Core.Orders;
using pegabicho.domain.Helpers;
using pegabicho.domain.Interfaces.Services.Core;
using pegabicho.service.Services.Base;
using pegabicho.service.Validators.Core.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.service.Services.Core {
    public class ServiceOrder : ServiceApp<Order>, IServiceOrder {
        public ServiceOrder(IServiceProvider provider) : base(provider) {
        }

        public List<OrderResponse> ListOrders() {
            try {
                var orders = repository.ListByReadOnly(x => !x.IsDeleted).OrderByDescending(x => x.CreatedAt).ToList();
                return orders.ConvertAll(e => (OrderResponse)e);
            } catch (Exception e) {
                Notifier.AddException<ServiceOrder>("Erro ao listar todas as ordens de serviço.", e);
                return null;
            }
        }

        public List<OrderResponse> ListOrdersByStatus(OrdertStatus status) {
            try {
                var orders = repository.ListByReadOnly(x => !x.IsDeleted && x.Status == status)
                    .OrderByDescending(x => x.CreatedAt).ToList();

                return orders.ConvertAll(e => (OrderResponse)e);
            } catch (Exception e) {
                Notifier.AddException<ServiceOrder>($"Erro ao listar todas as order de serviço pelo status {EnumUteis.EnumDisplay(status).ToLower()}", e);
                return null;
            }
        }

        /// <summary>
        /// Create a new generic order into application 
        /// </summary>
        /// <param name="request"></param>
        public Order AddOrder(OrderRequest request) {
            try {
                var order = new Order(request.Type, request.ClientId);
                ValidRegister<OrderValidator>(order);
                return order;
            } catch (Exception e) {
                Notifier.AddException<ServiceOrder>("Não foi possivel completar sua solicitação, tente novamente.", e);
                return null;
            }
        }

        /// <summary>
        /// Vincule the current request provider to any order by Id
        /// </summary>
        /// <param name="request"></param>
        public void DesignateProvider(OrderRequest request) {
            try {
                var order = repository.GetById(request.Id);
                if (order is null)
                    Notifier.Add<ServiceOrder>("Ordem de serviço não localizada.");

                if (string.IsNullOrEmpty(request.ProviderId))
                    Notifier.Add<ServiceOrder>("É obrigatório vincular um provedor à ordem de serviço.");

                order.DesigneProvider(request.ProviderId);
                repository.Update(order);

            } catch (Exception e) {
                Notifier.AddException<ServiceOrder>("Erro ao designar um prestador a ordem de serviço, tente novamente.", e);
            }
        }

        /// <summary>
        /// Finalize the current order by Id
        /// </summary>
        /// <param name="request"></param>
        public void FinalizeOrder(OrderRequest request) {
            try {
                var order = repository.GetById(request.Id);
                if (order is null)
                    Notifier.Add<ServiceOrder>("Ordem de serviço não localizada.");

                order.EndedOrder();
                repository.Update(order);

            } catch (Exception e) {
                Notifier.AddException<ServiceOrder>("Erro ao finalizar ordem de serviço.", e);
            }
        }

        public void SoftDelete(string id) {
            try {
                repository.SoftDelete(repository.GetById(id));
            } catch (Exception e) {
                Notifier.AddException<ServiceOrder>("Erro ao desativar registro pelo identificador", e);
            }
        }
    }
}
