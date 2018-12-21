using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Common.Interfaces;

namespace Contexts.Common.Results
{
    public class NullNotification : INotification
    {
        public List<string> Errors => new List<string>();

        public bool HasErrors => false;

        public void AddError(string message)
        {
            // TODO: Hmm... what to do here for a null object?
        }
    }
}
