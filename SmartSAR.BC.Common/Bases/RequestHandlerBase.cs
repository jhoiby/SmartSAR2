using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Common.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Contexts.Common.Bases
{
    public abstract class RequestHandlerBase<TRequest, TResponse> 
        : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TResponse result = await HandleCore(request, cancellationToken);

            return result;
        }

        protected abstract Task<TResponse> HandleCore(TRequest request, CancellationToken cancellationToken);

        protected async Task<CommandResult> Execute<TDbContext, TAggregate>(
            TDbContext dbContext, Guid id, Func<TAggregate, CommandResult> func)
                where TAggregate : AggregateRootBase
                where TDbContext : DbContext
        {
            CommandResult result;
            
            try
            {
                var aggregate = await dbContext.Set<TAggregate>().FindAsync(id);
                result = func(aggregate);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result = CommandResult.FromException(ex, "An error occurred while executing a command.");
            }

            return result;
        }
    }
}
