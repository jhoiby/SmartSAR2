using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Common.Interfaces;
using Contexts.Common.Results;
using Contexts.Membership.Data;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand, ICommandResult>
    {
        private MembershipDbContext _dbContext;

        public EditPersonCommandHandler(MembershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICommandResult> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _dbContext.Persons.FindAsync(request.Id);

            person.SetFirstName(request.FirstName);
            person.SetLastName(request.LastName);

            await _dbContext.SaveChangesAsync();

            return CommandResult.CreateSuccessfulResult();
        }
    }
}
