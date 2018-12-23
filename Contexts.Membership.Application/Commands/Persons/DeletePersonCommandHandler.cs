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
            // TODO: Clean up this ugly code by creating a new Execute method to handle EF commands (as opposed to Aggregate commands

             var executionResult = await Execute<MembershipDbContext, PersonAggregate>(_dbContext, request.PersonId, 
                    p =>
                    {
                        CommandResult result;
                        try
                        {
                            _dbContext.Set<PersonAggregate>().Remove(p);
                            result = CommandResult.Empty;
                        }
                        catch(NullReferenceException ex)
                        {
                            result = CommandResult.FromException(ex, "Error: Unable to locate the object in the database.");
                        }

                        return result;
                    });

            return executionResult;
        }
    }
}
