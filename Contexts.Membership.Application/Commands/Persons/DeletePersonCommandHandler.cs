using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Membership.Data;
using MediatR;

namespace Contexts.Membership.Application.Commands.Persons
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Guid>
    {
        private MembershipDbContext _dbContext;

        public DeletePersonCommandHandler(MembershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Persons.Remove(
                await _dbContext.Persons.FindAsync(request.PersonId));

            await _dbContext.SaveChangesAsync();

            return request.PersonId;
        }
    }
}
