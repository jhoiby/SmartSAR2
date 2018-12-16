using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class CreatePersonCommand : IRequest
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
