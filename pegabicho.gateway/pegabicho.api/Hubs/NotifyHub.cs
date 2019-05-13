using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace pegabicho.api.Hubs {
    public class NotifyHub : Hub {
        public async Task JoinGroup(string groupName) => await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }
}
