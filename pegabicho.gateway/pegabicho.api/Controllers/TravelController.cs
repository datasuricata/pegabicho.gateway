﻿using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Arguments.Core.Travel;
using pegabicho.domain.Interfaces.Services.Core;
using System.Threading.Tasks;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : CoreController {

        private readonly IServiceTravel serviceTravel;

        public TravelController(IServiceTravel serviceTravel) {
            this.serviceTravel = serviceTravel;
        }

        [HttpPost]
        public IActionResult AddTravel(TravelRequest request) {
            serviceTravel.AddTravel(InvokeAccount(request, nameof(TravelRequest.ClientId)));
            //hub.
            return Result(new ResponseBase(""));
        }
    }
}