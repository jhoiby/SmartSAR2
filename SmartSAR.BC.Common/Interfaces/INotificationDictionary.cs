using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Contexts.Common.Interfaces
{
    public interface INotificationDictionary : IDictionary<string, string>
    {
        void AddOrAppend(string key, string value, string delimiter = "");
    }
}