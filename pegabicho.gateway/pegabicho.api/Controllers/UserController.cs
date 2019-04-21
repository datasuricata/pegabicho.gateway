using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Interfaces.Services.Core;
using System.Threading.Tasks;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CoreController {
        private readonly IServiceUser serviceUser;
        public UserController(IServiceUser serviceUser) {
            this.serviceUser = serviceUser;
        }

        [HttpGet]
        [Route("all/getById")]
        public IActionResult GetById(string id) {
            return Result(serviceUser.GetById(id));
        }

        [HttpPost]
        [Route("all/registerStep")]
        public async Task<IActionResult> RegisterStep([FromBody]UserInitialRequest request) {
            await serviceUser.StepRegister(request);
            return Result(new ResponseBase($"Usuário {request.Email} criado com sucesso."));
        }
    }
}