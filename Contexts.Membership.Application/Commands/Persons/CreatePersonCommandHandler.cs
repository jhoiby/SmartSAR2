using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmartSAR.BC.Membership.Domain.Aggregates;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
    {
        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.FirstName, request.LastName);

            // TODO: FINISH PERSISTENCE, MAKE ASYNC

            return person.Id;
        }
    }
}
