using pegabicho.domain.Entities.Base;
using pegabicho.domain.Interfaces.Repositories.Core.Logs;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Logs
{
    public class LogApp : EntityBase, ILogApp
    {
        /// <summary>
        /// Use this for generic logs from application changes
        /// </summary>
        public string Ip { get; private set; }

        /// <summary>
        /// Method name for details event
        /// </summary>
        public string Event { get; private set; }
        public string OrderId { get; private set; }
        public string Message { get; private set; }
        public ModuleService Service { get; private set; }

        protected LogApp() {

        }

        public LogApp(string ip, string eventType, string orderId, string message, ModuleService service) {
            Ip = ip;
            Event = eventType;
            OrderId = orderId;
            Message = message;
            Service = service;
        }
    }
}
