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

        [HttpGet]
        [Route("all/getById")]
        public IActionResult GetById(string id) {
            return Result(serviceUser.GetById(id));
        }

        [HttpGet]
        [Route("all/listUsers")]
        public IActionResult ListUsers() {
            return Result(serviceUser.ListAll());
        }

        [HttpPost]
        [Route("all/registerStep")]
        public IActionResult RegisterStep([FromBody]UserRequest request) {
            serviceUser.InitialRegister(request);
            return Result(new ResponseBase($"Usuário {request.Email} criado com sucesso."));
        }

        [HttpPost]
        [Route("all/registerGeneral")]
        public IActionResult RegisterGeneral([FromBody]GeneralRequest request) {
            serviceUser.GeneralRegister(request);
            return Result(new ResponseBase("Informações atualizadas."));
        }

        [HttpPost]
        [Route("all/registerDocuments")]
        public IActionResult RegisterDocuments([FromBody]List<DocumentRequest> request) {
            serviceUser.DocumentsRegister(request, Logged);
            return Result(new ResponseBase("Documentos adicionados."));
        }

        [HttpPost]
        [Route("all/registerAddress")]
        public IActionResult RegisterAddress([FromBody]AddressRequest request) {
            serviceUser.AddressRegister(request);
            return Result(new ResponseBase("Endereço adicionado."));
        }

        [HttpPut]
        [Route("all/registerBussines")]
        public IActionResult RegisterBussines([FromBody]BussinesRequest request) {
            serviceUser.BussinesRegister(request);
            return Result(new ResponseBase("Informações atualizadas."));
        }
    }
}