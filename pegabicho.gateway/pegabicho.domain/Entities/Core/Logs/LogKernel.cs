using pegabicho.domain.Entities.Base;
using pegabicho.domain.Interfaces.Repositories.Core.Logs;

namespace pegabicho.domain.Entities.Core.Logs
{
    /// <summary>
    /// Use this for generic exception events from server
    /// Only to store sensive data
    /// </summary>
    public class LogKernel : EntityBase, ILogKernel
    {
        public string UserId { get; set; }
        public string Payload { get; set; }
        public bool Fixed { get; set; }
    }
}
