using System;
using System.Collections.Generic;
using System.Text;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class CreatePersonCommand
    {
        public CreatePersonCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
