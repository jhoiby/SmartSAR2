using Contexts.Common.Interfaces;
using Contexts.Common.Results;

namespace Contexts.Common.Bases
{
    public class AggregateRootBase : EntityBase, IAggregateRoot
    {
        protected CommandResult _result;

        public AggregateRootBase()
        {
            ResetResult();
        }

        protected void ResetResult()
        {
            _result = CommandResult.CreateWithNotifications(NotificationDictionary.CreateEmpty());
        }

        protected void AddNotification(string key, string value)
        {
            _result.Notifications.AddOrAppend(key, value);
        }
    }
}
