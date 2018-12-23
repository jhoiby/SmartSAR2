using System;
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
    public class EditPersonCommandHandler : RequestHandlerBase<EditPersonCommand, CommandResult>
    {
        private MembershipDbContext _dbContext;

        public EditPersonCommandHandler(MembershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected async override Task<CommandResult> HandleCore(EditPersonCommand request, CancellationToken cancellationToken)
        {
            await Execute<MembershipDbContext, Person>(_dbContext, request.Id, agg =>
            {
                agg.SetFirstName(request.FirstName);
                agg.SetLastName(request.LastName);
            });

            return CommandResult.CreateSuccessful();
        }
    }
}
