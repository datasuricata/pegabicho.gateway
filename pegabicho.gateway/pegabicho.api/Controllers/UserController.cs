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

        [HttpGet]
        [Route("getById")]
        public IActionResult GetById(string id) {
            return Result(serviceUser.GetById(id));
        }

        [HttpGet]
        [Route("listUsers")]
        public IActionResult ListUsers() {
            return Result(serviceUser.ListAll());
        }

        #endregion

        #region [ post ]

        [HttpPost]
        [Route("registerStep")]
        public IActionResult RegisterStep([FromBody]UserRequest request) {
            serviceUser.InitialRegister(request);
            return Result(new ResponseBase($"Usuário {request.Email} criado com sucesso."));
        }

        [HttpPost]
        [Route("registerGeneral")]
        public IActionResult RegisterGeneral([FromBody]GeneralRequest request) {
            serviceUser.GeneralRegister(request);
            return Result(new ResponseBase("Informações atualizadas."));
        }

        [HttpPost]
        [Route("registerDocuments")]
        public IActionResult RegisterDocuments([FromBody]List<DocumentRequest> request) {
            serviceUser.DocumentsRegister(request, Logged);
            return Result(new ResponseBase("Documentos adicionados."));
        }

        [HttpPost]
        [Route("registerAddress")]
        public IActionResult RegisterAddress([FromBody]AddressRequest request) {
            serviceUser.AddressRegister(request);
            return Result(new ResponseBase("Endereço adicionado."));
        }

        #endregion

        #region [ put ]

        [HttpPut]
        [Route("registerBussines")]
        public IActionResult RegisterBussines([FromBody]BussinesRequest request) {
            serviceUser.BussinesRegister(request);
            return Result(new ResponseBase("Informações da empresa registradas."));
        }

        [HttpPut]
        [Route("updateBussines")]
        public IActionResult UpdateBussines([FromBody]BussinesRequest request) {
            //serviceUser.
            return Result(new ResponseBase("Informações da empresa atualizadas."));
        }

        [HttpPut]
        [Route("updateGeneral")]
        public IActionResult UpdateGeneral([FromBody]GeneralRequest request) {
            //serviceUser.
            return Result(new ResponseBase("Informaçõe gerais atualziadas com sucesso."));
        }

        [HttpPut]
        [Route("updateDocument")]
        public IActionResult UpdateDocument([FromBody] DocumentRequest request) {
            //serviceUser.
            return Result(new ResponseBase("Documento atualizado com sucesso."));
        }

        [HttpPut]
        [Route("updateAddress")]
        public IActionResult UpdateAddress([FromBody] AddressRequest request) {
            //serviceUser.
            return Result(new ResponseBase("Endereço atualizado com sucesso."));
        }

        #endregion

        #region [ delete ]

        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteUser(string id) {
            //serviceUser.
            return Result(new ResponseBase("Usuário deletado com sucesso."));
        }

        [HttpDelete]
        [Route("softDeleteUser")]
        public ResponseBase SoftDeleteUser(string id) {
            //serviceUser.
            return new ResponseBase("Usuário desativado com sucesso.");
        }

        #endregion

        #region [ custom ]

        #endregion
    }
}