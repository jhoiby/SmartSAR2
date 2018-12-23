using Contexts.Common.Bases;
using Contexts.Common.Extensions;
using Contexts.Common.Interfaces;
using Contexts.Common.Results;

namespace Contexts.Membership.Domain.Entities
{
    public class Person : AggregateRootBase
    {
        private string _firstName;
        private string _lastName;

        public Person(string firstName, string lastName)
        {
            SetName(firstName, LastName);
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;

        public void SetFirstName(string firstName)
        {
            // TODO: Fix naive implementation
            _firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            // TODO: Fix naive implementation
            _lastName = lastName;
        }

        public CommandResult SetName(string firstName, string lastName)
        {
            ResetResult();

            if (firstName.Length == 0)
            {
                AddNotification("FirstName", "First name must not be empty");
            }

            if (lastName.Length == 0)
            {
                AddNotification("LastName", "Last name must not be empty.");
            }

            if (_result.NoNotifications)
            {
                _firstName = firstName;
                _lastName = lastName;
            }

            return _result;
        }


    }
}
