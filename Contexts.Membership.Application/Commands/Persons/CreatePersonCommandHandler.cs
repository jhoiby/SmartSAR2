using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Membership.Data;
using MediatR;
using SmartSAR.BC.Membership.Domain.Aggregates;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
    {
        private MembershipDbContext _membershipDb;

        public CreatePersonCommandHandler(MembershipDbContext membershipDb)
        {
            _membershipDb = membershipDb;
        }

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.FirstName, request.LastName);

            _membershipDb.Persons.Add(person);
            await _membershipDb.SaveChangesAsync();

            return person.Id;
        }
    }
}
