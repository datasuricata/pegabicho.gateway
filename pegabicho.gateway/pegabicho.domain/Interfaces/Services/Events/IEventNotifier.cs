using pegabicho.domain.Notifications;
using System;
using System.Collections.Generic;
 
namespace pegabicho.domain.Interfaces.Services.Events
{
    public interface IEventNotifier : IDisposable
    {
        void Add<N>(string message);
        void AddException<N>(string message, Exception exception = null);
        bool HasAny();
        IEnumerable<Notification> GetNotifications();
    }
}
