using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Contexts.Common.Interfaces
{
    public interface INotification
    {
        void AddError(string message);
        List<string> Errors { get; }
        bool HasErrors { get; }
    }
}
