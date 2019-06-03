using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Arguments.Core.Users;
using pegabicho.domain.Interfaces.Services.Core;
using System.Collections.Generic;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CoreController {
        private readonly IServiceUser serviceUser;
        public UserController(IServiceUser serviceUser) {
            this.serviceUser = serviceUser;
        }

        #region [ get ]

        [HttpGet("getById")]
        public IActionResult GetById(string id) {
            return Result((UserResponse)serviceUser.GetById(id));
        }

        [HttpGet("getByEmail")]
        public IActionResult GetByEmail(string email) {
            return Result((UserResponse)serviceUser.GetByEmail(email));
        }

        [HttpGet("listUsers")]
        public IActionResult ListUsers() {
            return Result(serviceUser.ListUsers().ConvertAll(e => (UserResponse)e));
        }

        #endregion

        #region [ post ]

        [HttpPost("registerStep")]
        public IActionResult RegisterStep([FromBody]UserRequest request) {
            serviceUser.InitialRegister(request);
            return Result(new ResponseBase($"Usuário {request.Email} criado com sucesso."));
        }

        [HttpPost("registerGeneral")]
        public IActionResult RegisterGeneral([FromBody]GeneralRequest request) {
            serviceUser.GeneralRegister(request);
            return Result(new ResponseBase("Informações atualizadas."));
        }

        [HttpPost("registerDocuments")]
        public IActionResult RegisterDocuments([FromBody]List<DocumentRequest> request) {
            serviceUser.DocumentsRegister(request, Logged);
            return Result(new ResponseBase("Documentos adicionados."));
        }

        [HttpPost("registerAddress")]
        public IActionResult RegisterAddress([FromBody]AddressRequest request) {
            serviceUser.AddressRegister(request);
            return Result(new ResponseBase("Endereço adicionado."));
        }

        #endregion

        #region [ put ]

        [HttpPut("registerBussines")]
        public IActionResult RegisterBussines([FromBody]BussinesRequest request) {
            serviceUser.BussinesRegister(request);
            return Result(new ResponseBase("Informações da empresa registradas."));
        }

        [HttpPut("updateBussines")]
        public IActionResult UpdateBussines([FromBody]BussinesRequest request) {
            //serviceUser.
            return Result(new ResponseBase("Informações da empresa atualizadas."));
        }

        [HttpPut("updateGeneral")]
        public IActionResult UpdateGeneral([FromBody]GeneralRequest request) {
            //serviceUser.
            return Result(new ResponseBase("Informaçõe gerais atualziadas com sucesso."));
        }

        [HttpPut("updateDocument")]
        public IActionResult UpdateDocument([FromBody]DocumentRequest request) {
            //serviceUser.
            return Result(new ResponseBase("Documento atualizado com sucesso."));
        }

        [HttpPut("updateAddress")]
        public IActionResult UpdateAddress([FromBody]AddressRequest request) {
            //serviceUser.
            return Result(new ResponseBase("Endereço atualizado com sucesso."));
        }

        #endregion

        #region [ delete ]

        [HttpDelete("softDelete")]
        public IActionResult SoftDeleteUser(string id) {
            //serviceUser.
            return Result(new ResponseBase("Usuário desativado com sucesso."));
        }

        #endregion
    }
}