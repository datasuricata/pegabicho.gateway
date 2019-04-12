﻿using pegabicho.domain.Interfaces.Arguments.Base;
using pegabicho.domain.Notifications;

namespace pegabicho.domain.Arguments.Base
{
    public class ResponseBase : IResponse
    {
        public Notification Message { get; set; }

        public ResponseBase() => Message = new Notification("Operação realizada com sucesso.");
        public ResponseBase(string msg) => Message.Value = msg; 
    }
}
