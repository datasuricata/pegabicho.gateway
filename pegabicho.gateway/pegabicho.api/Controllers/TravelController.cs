using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Arguments.Core.Orders;
using pegabicho.domain.Interfaces.Services.Core;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : CoreController {

        private readonly IServiceTravel serviceTravel;

        public TravelController(IServiceTravel serviceTravel) {
            this.serviceTravel = serviceTravel;
        }

        [HttpPost]
        [Route("all/invokeTravel")]
        [Authorize]
        public IActionResult InvokeTravel(OrderRequest request) {
           
            // todo hub push response for apps
            return Result(new ResponseBase("Procurando motoristas..."));
        }
    }
}
