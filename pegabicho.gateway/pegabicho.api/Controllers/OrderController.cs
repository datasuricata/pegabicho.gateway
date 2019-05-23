using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;
using pegabicho.domain.Arguments.Base;
using pegabicho.domain.Arguments.Core.Orders;
using pegabicho.domain.Interfaces.Services.Core;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CoreController {
        private readonly IServiceOrder serviceOrder;
        public OrderController(IServiceOrder serviceOrder) {
            this.serviceOrder = serviceOrder;
        }

        [HttpGet("getById")]
        public IActionResult GetById(string id) {
            return Result((OrderResponse)serviceOrder.GetById(id));
        }

        [HttpGet("listOrders")]
        public IActionResult ListOrders() {
            return Result(serviceOrder.ListOrders().ConvertAll(e => (OrderResponse)e));
        }

        [HttpGet("listOrdersByStatus")]
        public IActionResult ListOrderByStatus([FromBody] OrdertStatus status) {
            return Result(serviceOrder.ListOrdersByStatus(status).ConvertAll(e => (OrderResponse)e));
        }

        [HttpPut("designateProvider")]
        public IActionResult Designe([FromBody] OrderRequest request) {
            serviceOrder.DesignateProvider(request);
            return Result(new ResponseBase("Designado com sucesso."));
        }

        [HttpPut("finalizeOrder")]
        public IActionResult Finalize([FromBody]OrderRequest request) {
            serviceOrder.FinalizeOrder(request);
            return Result(new ResponseBase("Ordem de serviço finalizada."));
        }

        [HttpDelete("softDelete")]
        public IActionResult SoftDelete(string id) {
            serviceOrder.SoftDelete(id);
            return Result(new ResponseBase("Registro desativado com sucesso."));
        }
    }
}