using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using pegabicho.api.Controllers.Base;
using pegabicho.api.Hubs;
using System.Threading.Tasks;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : CoreController {

        IHubContext<NotifyHub> hub;

        public SignalRController(IHubContext<NotifyHub> hub) {
            this.hub = hub;
        }

        [HttpGet("showRoutes")]
        public IActionResult Show() {
            return Result(new { Global = "NotifyAll", Group = "NotifyGroup", });
        }

        [HttpGet("pushToAll")]
        public async Task SendPushAsync(string msg) {
            await hub.Clients.All.SendAsync("NotifyAll", JsonConvert.SerializeObject(msg));
        }

        [HttpPost("pushToGroup")]
        public async Task JoinGroup([FromBody]string orderId, string msg) {
            await hub.Clients.Group(orderId).SendAsync("NotifyGroup", JsonConvert.SerializeObject(msg));
        }
    }
}