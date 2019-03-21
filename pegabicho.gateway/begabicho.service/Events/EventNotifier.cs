using begabicho.shared.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace begabicho.service.Events
{
    public class EventNotifier : IEventNotifier, IDisposable
    {
        #region [ parameters ]

        protected Notifier Notifier;
        private bool disposed = false;

        #endregion

        #region [ ctor ]

        public EventNotifier() => Notifier = new Notifier();

        #endregion

        #region [ methods ]

        public void CreateNotification<N>(string message) => Notifier.Notifications.Add(new Notification { Key = typeof(N).Name, Value = message, StatusCode = 400 });

        public void CreateNotification<N>(string message, Exception exception = null)
        {
            var stack = new StackTrace(exception);
            var frames = stack.GetFrames();

            string[] path = new string[frames.Count()];
            string[] lines;

            int i = 0;

            string ex = exception.InnerException?.InnerException == null ? exception.Message : exception.InnerException.InnerException.Message;
            ex += exception.InnerException == null ? "" : $"{Environment.NewLine} Inner Exception: {Environment.NewLine} {exception.InnerException.Message}";

            if (ex.Contains(Environment.NewLine))
                lines = ex.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            else
                lines = new string[] { ex };

            foreach (var x in frames)
            {
                path[i++] = $"{i}. ↓ {x.GetMethod().Name}";
            }

            Notifier.Notifications.Add(new Notification
            {
                Key = typeof(N).Name,
                Value = message,
                Exception = lines,
                StatusCode = 500,
                Call = path
            });
        }

        public IEnumerable<Notification> GetNotification() => Notifier.Notifications.AsEnumerable();

        #endregion

        #region [ overrides ]

        public override string ToString() => JsonConvert.SerializeObject(Notifier);

        #endregion

        #region [ validator ]

        public bool HasNotification() => Notifier.HasAny;

        #endregion

        #region [ dispose ]

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    Notifier.Notifications.Clear();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
