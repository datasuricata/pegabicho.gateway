using pegabicho.domain.Interfaces.Arguments.Base;

namespace pegabicho.domain.Arguments.Base {
    public class ResponseBase : IResponse
    {
        private string Message { get; set; }
        public ResponseBase() => Message = "Operação realizada com sucesso.";
        public ResponseBase(string msg) => Message = msg;
    }
}
