using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class DeletePersonCommand : IRequest<Guid>
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
