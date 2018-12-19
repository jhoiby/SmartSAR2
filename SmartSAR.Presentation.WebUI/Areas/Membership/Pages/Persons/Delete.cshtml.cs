using System;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Membership.Application.Commands.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebUI.Pages;
using Presentation.WebUI.Services;

namespace Presentation.WebUI.Areas.Membership.Pages.Persons
{
    public class DeleteModel : PageModelBase
    {
        [BindProperty]
        public Result Data { get; set; }

        public async Task OnGetAsync(Guid personId)
        {
            Data = await Mediator.Send(new Query(personId));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await Mediator.Send(new DeletePersonCommand(Guid.NewGuid(), Data.Id));

            return RedirectToPage("Index");
        }

        public class Query : IRequest<Result>
        {
            public Query(Guid personId)
            {
                PersonId = personId;
            }

            public Guid PersonId { get; set; }
        }

        public class Result
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Result>
        {
            private DbQueryService _queryService;

            public QueryHandler(DbQueryService queryService)
            {
                _queryService = queryService;
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken) =>
                await _queryService.Query<Result>(
                    "SELECT * FROM Persons WHERE Id = @PersonId",
                    new { request.PersonId });
        }
    }
}