using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Contexts.Common.Interfaces;

namespace Contexts.Common.Results
{
    public class CommandResult
    {
        private CommandResult()
        {
            Notifications = NotificationDictionary.CreateEmpty();
        }

        public bool NoNotifications => !(Notifications.Count > 0);

        public NotificationDictionary Notifications { get; private set; }

        public Exception Exception { get; private set; }

        public dynamic Data { get; private set; }

        public static CommandResult Empty => new CommandResult();

        public static CommandResult FromException(Exception ex, string uiNotification = "")
        {
            return new CommandResult
            {
                Exception = ex,
                Notifications = new NotificationDictionary("", uiNotification)
            };
        }

        public static CommandResult FromNotification(string key, string value)
        {
            return new CommandResult
            {
                Notifications = new NotificationDictionary(key, value)
            };
        }

        public static CommandResult FromNotifications(NotificationDictionary notifications)
        {
            return new CommandResult{Notifications = notifications};
        }
    }
}
