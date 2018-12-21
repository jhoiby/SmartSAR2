using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Common.Interfaces;

namespace Contexts.Common.Results
{
    public class Notification : INotification
    {
        private List<string> _errors = new List<string>();

        public List<string> Errors => _errors;

        public bool HasErrors => (_errors.Count > 0);

        public void AddError(string message)
        {
            _errors.Add(string);
        }
    }
}
