using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Common.Interfaces;
using Contexts.Common.Results;
using Contexts.Membership.Data;
using Contexts.Membership.Domain.Entities.PersonAggregate;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{

    // TODO: REMOVE THESE PERSON CRUD METHODS. They are not true DDD and are here only to assist
    // TODO: with developing the first architectural spike.

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ICommandResult>
    {
        private MembershipDbContext _membershipDb;

        public CreatePersonCommandHandler(MembershipDbContext membershipDb)
        {
            _membershipDb = membershipDb;
        }

        public async Task<ICommandResult> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.FirstName, request.LastName);
            
            _membershipDb.Persons.Add(person);
            await _membershipDb.SaveChangesAsync();

            return CommandResult.CreateSuccessfulResult();
        }
    }
}
