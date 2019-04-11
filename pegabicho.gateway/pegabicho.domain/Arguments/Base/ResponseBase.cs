using pegabicho.domain.Notifications;

namespace pegabicho.domain.Arguments.Base
{
    public class ResponseBase 
    {
        public ResponseBase(string msg) => Message.Value = msg; 
        public Notification Message { get; set; } = new Notification("Operação realizada com sucesso.");
    }
}
