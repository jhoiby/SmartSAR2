using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Common.Interfaces;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class EditPersonCommand : IRequest<ICommandResult>
    {
        public EditPersonCommand()
        {
        }

        public EditPersonCommand(Guid requestId, Guid id, string firstName, string lastName)
        {
            RequestId = requestId;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid RequestId { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

