using pegabicho.domain.Notifications;
using System;
using System.Collections.Generic;

namespace pegabicho.domain.Interfaces.Services.Events
{
    public interface IEventNotifier
    {
        void Notify<N>(string message);
        void NotifyException<N>(string message, Exception exception = null);
        bool HasNotification();
        IEnumerable<Notification> GetNotifications();
    }
}
