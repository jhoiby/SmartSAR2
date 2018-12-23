using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Common.Bases;
using Contexts.Common.Interfaces;
using Contexts.Common.Results;
using Contexts.Membership.Data;
using Contexts.Membership.Domain.Entities;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class DeletePersonCommandHandler : RequestHandlerBase<DeletePersonCommand, CommandResult>
    {
        private MembershipDbContext _dbContext;

        public DeletePersonCommandHandler(MembershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override async Task<CommandResult> HandleCore(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await Execute<MembershipDbContext, Person>(_dbContext, request.PersonId, agg => 
            _dbContext.Set<Person>().Remove(agg));
            
            return CommandResult.CreateSuccessful();
        }
    }
}
