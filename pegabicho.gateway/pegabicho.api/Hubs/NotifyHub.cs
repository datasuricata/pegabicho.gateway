using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace pegabicho.api.Hubs {
    public class NotifyHub : Hub {
        /// <summary>
        /// join into group for city general view
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task JoinCity(string cityId) => await Groups.AddToGroupAsync(Context.ConnectionId, cityId);

        /// <summary>
        /// join into ticket for general view by group ticket
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task JoinGroup(string orderId) => await Groups.AddToGroupAsync(Context.ConnectionId, orderId);
    }
}
