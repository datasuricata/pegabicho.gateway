using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Interfaces.Services.Core;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : CoreController {
        private readonly IServiceUser serviceUser;
        public ComponentController(IServiceUser serviceUser) {
            this.serviceUser = serviceUser;
        }

        [HttpGet("dropdown/user/services")]
        public IActionResult UserServices() {
            return Result(ToEnumDropDown<ModuleService>());
        }

        [HttpGet("dropdown/user/documents")]
        public IActionResult UserDocs() {
            return Result(ToEnumDropDown<DocumentType>());
        }

        [HttpGet("dropdown/user/type")]
        public IActionResult UserTypes() {
            return Result(ToEnumDropDown<UserType>(nameof(UserType.Root)));
        }

        [HttpGet("dropdown/address/building")]
        public IActionResult BuildingType() {
            return Result(ToEnumDropDown<BuildingType>());
        }

        [HttpGet("dropdown/order/type")]
        public IActionResult OrderType() {
            return Result(ToEnumDropDown<OrderType>());
        }
    }
}