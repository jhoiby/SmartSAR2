using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Contexts.Common.Interfaces;

namespace Contexts.Common.Results
{
    public class CommandResult : ICommandResult
    {
        private readonly INotificationDictionary _errors;
        private readonly dynamic _data;

        private CommandResult(INotificationDictionary resultErrorDictionary, dynamic data)
        {
            _errors = resultErrorDictionary ?? new NotificationDictionary();
            _data = data; // Null allowed
        }

        public bool IsSuccess => !(_errors.Count > 0);

        public INotificationDictionary ErrorMessages => _errors;

        public dynamic Data => _data;

        public static CommandResult CreateSuccessfulResult()
        {
            // Builds an empty result
            return new CommandResult(new NotificationDictionary(), new object());
        }

        public static implicit operator bool(CommandResult result)
        {
            return result.IsSuccess;
        }
    }
}
