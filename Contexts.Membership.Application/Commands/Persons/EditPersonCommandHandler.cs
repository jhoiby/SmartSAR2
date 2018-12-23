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
            return await Execute<MembershipDbContext, PersonAggregate>(_dbContext, request.Id,
                    p => p.SetName(request.FirstName, request.LastName));
        }
    }
}
