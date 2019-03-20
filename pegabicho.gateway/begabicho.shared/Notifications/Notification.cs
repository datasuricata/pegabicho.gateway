using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace begabicho.shared.Notifications
{
    public class Notifier
    {
        public IEnumerable<Notification> Notifications { get; set; } = new List<Notification>();
        public bool HasAny => Notifications.Any();
    }

    public class Notification
    {
        public Notification()
        {
            Id = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            Date = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            Value = "Ops! Algo deu errado.";
        }

        // #for service
        public string Id { get; private set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }

        // #for server
        public int StatusCode { get; set; }
        public string[] Exception { get; set; }
        public string[] Call { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
