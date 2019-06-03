using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Arguments.Core.Pets;
using pegabicho.domain.Interfaces.Services.Core;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : CoreController {
        private readonly IServicePet servicePet;
        public PetController(IServicePet servicePet) {
            this.servicePet = servicePet;
        }

        [HttpGet("getById")]
        public IActionResult GetById(string id) {
            return Result((PetResponse)servicePet.GetById(id));
        }

        [HttpGet("getByCode")]
        public IActionResult GetByCode(string id) {
            return Result((PetResponse)servicePet.GetByCode(id));
        }

        [HttpGet("listByUser")]
        public IActionResult ListByUser(string id) {
            return Result(servicePet.ListByUser(id).ConvertAll(e => (PetResponse)e));
        }

        [HttpPost("addPet")]
        public IActionResult AddPet([FromBody]PetRequest request) {
            servicePet.AddPet(InjectAccount(request, nameof(request.UserId)));
            return Result(new ResponseBase("Pet criado com sucesso."));
        }

        [HttpPut("changeSize")]
        public IActionResult ChangeSize([FromBody]PetRequest request) {
            servicePet.ChangeSize(request);
            return Result(new ResponseBase("Tamanho alterado com sucesso."));
        }

        [HttpPut("changeProfile")]
        public IActionResult ChangeProfile([FromBody]PetRequest request) {
            servicePet.ChangeProfileImage(request);
            return Result(new ResponseBase("Imagem de perfil alterada com sucesso."));
        }

        [HttpPut("changeGeneral")]
        public IActionResult ChangeGeneral([FromBody]PetRequest request) {
            servicePet.ChangeGeneral(request);
            return Result(new ResponseBase("Dados gerais alterados com sucesso."));
        }

        [HttpDelete("softDelete")]
        public IActionResult SoftDelete(string id) {
            servicePet.SoftDelete(id);
            return Result(new ResponseBase("Registro desativado com sucesso."));
        }
    }
}