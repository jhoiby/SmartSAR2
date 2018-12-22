using System;
using System.Collections.Generic;
using System.Text;
using Contexts.Common.Interfaces;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class DeletePersonCommand : IRequest<ICommandResult>
    {
        public DeletePersonCommand(Guid requestId, Guid personId)
        {
            RequestId = requestId;
            PersonId = personId;
        }

        public Guid RequestId { get; set; }
        public Guid PersonId { get; set; }
    }
}
