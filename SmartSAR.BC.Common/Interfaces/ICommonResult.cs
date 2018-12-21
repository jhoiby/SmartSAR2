using System;
using System.Collections.Generic;
using System.Text;

namespace Contexts.Common.Interfaces
{
    public interface ICommonResult
    {
        bool Succeeded { get; }

        IResultNotifier Notifier { get; }

        dynamic Data { get; }
    }
}
