using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace begabicho.shared.Notifications
{
    public class Notifier
    {
        public List<Notification> Notifications { get; set; }
        public bool HasAny => Notifications.Any();

        public Notifier() => Notifications = new List<Notification>();
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
        public string Id { get; set; }
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
