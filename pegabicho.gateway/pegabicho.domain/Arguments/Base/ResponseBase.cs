using pegabicho.domain.Notifications;

namespace pegabicho.domain.Arguments.Base
{
    public class ResponseBase 
    {
        public Notification Message { get; set; }

        public ResponseBase() => Message = new Notification("Operação realizada com sucesso.");
        public ResponseBase(string msg) => Message.Value = msg; 
    }
}
