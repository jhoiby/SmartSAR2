using System;
using System.Collections.Generic;
using System.Text;

namespace Contexts.Common.Interfaces
{
    public interface ICommandResult
    {
        bool IsSuccess { get; }
        
        INotificationDictionary ErrorMessages { get; }

        dynamic Data { get; }
    }
}
