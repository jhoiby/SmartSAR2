using System;
using System.Collections.Generic;
using System.Text;
using SmartSAR.BC.Common.Bases;
using SmartSAR.BC.Common.Extensions;

namespace SmartSAR.BC.Membership.Domain.Aggregates
{
    public class Person : AggregateRootBase
    {
        private string _firstName;
        private string _lastName;

        public Person(string firstName, string lastName)
        {
            _firstName = firstName.Require().Trim();
            _lastName = lastName.Require().Trim();
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
    }
}
