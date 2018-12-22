using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Common.Interfaces;

namespace Contexts.Common.Results
{
    public class NotificationDictionary : Dictionary<string, string>, INotificationDictionary
    {
        /// <summary>
        /// A collection of errors that occured during handling of a command. The key
        /// contains the name of the parameter, if any, that triggered the error. The value
        /// contains the error message. If the error message is not related to a specific paramater
        /// or other identifiable item specific to the command/query the key may be set to "".
        ///
        /// This types in this class were chosen to work easily with MVC ModelError dictionaries.
        /// </summary>
        public NotificationDictionary()
        {
        }

        public NotificationDictionary(string key, string value)
        {
            this.Add(key, value);
        }

        // Attempts to add pair to the dictionary. If the key already exists, appends the
        // value to the existing value with an optional delimeter between. This is useful when,
        // for example, adding multiple error strings for a given parameter (key).
        public void AddOrAppend(string key, string value, string delimiter = "")
        {
            string originalValue = "";

            if (this.ContainsKey(key))
            {
                originalValue = this.GetValueOrDefault(key);
                this.Remove(key);
                this.Add(key, originalValue + delimiter + value);
            }
            else
            {
                this.Add(key, value);
            }
        }
    }
}
