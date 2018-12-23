using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Common.Bases;
using Contexts.Common.Interfaces;
using Contexts.Common.Results;
using Contexts.Membership.Data;
using MediatR;
using SmartSAR.BC.Membership.Domain.Aggregates;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class EditPersonCommandHandler : RequestHandlerBase<EditPersonCommand, ICommandResult>
    {
        private MembershipDbContext _dbContext;

        public EditPersonCommandHandler(MembershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected async override Task<ICommandResult> HandleCore(EditPersonCommand request, CancellationToken cancellationToken)
        {
            Execute<MembershipDbContext, Person>(_dbContext, request.Id, agg =>
            {
                agg.SetFirstName(request.FirstName);
                agg.SetLastName(request.LastName);
            });

            return CommandResult.CreateSuccessfulResult();
        }
    }
}
