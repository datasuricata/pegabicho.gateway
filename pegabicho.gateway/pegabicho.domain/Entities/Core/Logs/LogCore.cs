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
        public string Ip { get; set; }
        public string UserId { get; set; }
        public string Payload { get; set; }
        public LogType Type { get; set; }
        public ModuleService Service { get; set; }
    }
}
