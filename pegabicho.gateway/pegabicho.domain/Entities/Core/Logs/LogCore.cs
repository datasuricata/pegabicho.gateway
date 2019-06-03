using pegabicho.domain.Entities.Base;
using pegabicho.domain.Interfaces.Repositories.Core.Logs;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Logs
{
    /// <summary>
    /// Use this for generic logs from entities changes
    /// Only to store sensive data
    /// </summary>
    public class LogCore : EntityBase, ILogCore
    {
        public string Ip { get; private set; }
        public string UserId { get; private set; }
        public string Payload { get; private set; }
        public LogType Type { get; private set; }
        public ModuleService Service { get; private set; }

        protected LogCore() {

        }

        public LogCore(string ip, string userId, string payload, LogType type, ModuleService service) {
            Ip = ip;
            UserId = userId;
            Payload = payload;
            Type = type;
            Service = service;
        }
    }
}
