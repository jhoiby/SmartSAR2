using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Contexts.Common.Interfaces;

namespace Contexts.Common.Results
{
    public class CommandResult
    {
        private readonly NotificationDictionary _notifications;
        private readonly dynamic _data;

        private CommandResult(NotificationDictionary notificationDictionary, dynamic data)
        {
            _notifications = notificationDictionary ?? new NotificationDictionary();
            _data = data; // Null allowed
        }

        public bool NoNotifications => !(_notifications.Count > 0);

        public NotificationDictionary Notifications => _notifications;

        public dynamic Data => _data;

        public static CommandResult CreateSuccessful(dynamic data = default(object))
        {
            // Builds an empty result
            return new CommandResult(new NotificationDictionary(), data);
        }

        public static CommandResult CreateWithNotifications(NotificationDictionary notifications)
        {
            return new CommandResult(notifications, new object());
        }

        public static implicit operator bool(CommandResult result)
        {
            return result.NoNotifications;
        }
    }
}
