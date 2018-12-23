using Contexts.Common.Bases;
using Contexts.Common.Extensions;
using Contexts.Common.Interfaces;
using Contexts.Common.Results;

namespace Contexts.Membership.Domain.Entities
{
    public class PersonAggregate : AggregateRootBase
    {
        private string _firstName;
        private string _lastName;

        private PersonAggregate() // For rehydration by EF
        {
        }

        public PersonAggregate(string firstName, string lastName)
        {
            SetName(firstName, LastName);
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;

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
