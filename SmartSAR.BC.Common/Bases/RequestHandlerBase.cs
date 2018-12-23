using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        protected async void Execute<TDbContext, TAggregate>(TDbContext dbContext, Guid id, Action<TAggregate> action)
            where TAggregate : AggregateRootBase
            where TDbContext : DbContext
        {
            var aggregate = await dbContext.Set<TAggregate>().FindAsync(id);

            action(aggregate);

            await dbContext.SaveChangesAsync();
        } 
    }
}
