using pegabicho.domain.Entities.Base;
using pegabicho.domain.Interfaces.Repositories.Core.Logs;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Logs
{
    public class LogApp : EntityBase, ILogApp
    {
        public string Ip { get; set; }
        public string Event { get; set; }
        public string Ticket { get; set; }
        public string Message { get; set; }
        public ModuleService Service { get; set; }
    }
}
