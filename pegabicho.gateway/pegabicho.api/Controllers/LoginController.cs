using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Arguments.Core.Security;
using pegabicho.domain.Interfaces.Services.Core;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : CoreController {
        private readonly IServiceUser serviceUser;
        public LoginController(IServiceUser serviceUser) {
            this.serviceUser = serviceUser;
        }

        [Authorize]
        [HttpGet("ValidToken")]
        public IActionResult ValidToken() {
            return Result("Token has been validated.");
        }

        [HttpPost("app/customer")]
        public IActionResult LoginCustomer([FromBody] AuthRequest request) {
            return Result(serviceUser.Authenticate(request, AuthPlataform.Customer));
        }

        [HttpPost("app/provider")]
        public IActionResult LoginProvider([FromBody] AuthRequest request) {
            return Result(serviceUser.Authenticate(request, AuthPlataform.Provider));
        }

        [HttpPost("showplace")]
        public IActionResult LoginShowplace([FromBody] dynamic request) {
            return Result(serviceUser.Authenticate(new AuthRequest {
                Email = (string)request.email,
                Password = (string)request.password
            }, AuthPlataform.Showplace));
        }

        [HttpPost("backoffice")]
        public IActionResult LoginBackOffice([FromBody] dynamic request) {
            return Result(serviceUser.Authenticate(new AuthRequest {
                Email = (string)request.email,
                Password = (string)request.password
            }, AuthPlataform.BackOffice));
        }
    }
}