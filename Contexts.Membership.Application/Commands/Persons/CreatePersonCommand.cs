﻿using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Common.Interfaces;
using Contexts.Common.Results;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class CreatePersonCommand : IRequest<CommandResult>
    {
        public CreatePersonCommand()
        {
        }

        public CreatePersonCommand(Guid requestId, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            RequestId = requestId;
        }

        public Guid RequestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
