using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Common.Interfaces;
using Contexts.Common.Results;
using Contexts.Membership.Data;
using Contexts.Membership.Domain.Entities;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{

    // TODO: REMOVE THESE PERSON CRUD METHODS. They are not true DDD and are here only to assist
    // TODO: with developing the first architectural spike.

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, CommandResult>
    {
        private MembershipDbContext _membershipDb;

        public CreatePersonCommandHandler(MembershipDbContext membershipDb)
        {
            _membershipDb = membershipDb;
        }

        public async Task<CommandResult> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            // TODO: Refactor to use new Execution method pattern

            CommandResult result;

            try
            {
                var person = new PersonAggregate(request.FirstName, request.LastName);
                _membershipDb.Persons.Add(person);
                await _membershipDb.SaveChangesAsync();
                result = CommandResult.Empty;
            }
            catch (Exception ex)
            {
                result = CommandResult.FromException(ex, "An error occurred while saving the Person.");
            }

            return result;
        }
    }
}
