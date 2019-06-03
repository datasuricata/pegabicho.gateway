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
        public string UserId { get; private set; }
        public string Payload { get; private set; }
        public bool Fixed { get; private set; }

        protected LogKernel() {

        }

        public LogKernel(string userId, string payload) {
            UserId = userId;
            Payload = payload;
        }

        public void Ok() {
            Fixed = true;
        }
    }
}
