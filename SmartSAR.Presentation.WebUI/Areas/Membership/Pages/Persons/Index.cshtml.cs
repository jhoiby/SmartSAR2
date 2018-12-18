using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebUI.Pages;
using Microsoft.Extensions.Configuration;
using Presentation.WebUI.Services;

namespace Presentation.WebUI.Areas.Membership.Pages.Persons
{
    public class IndexModel : PageModelBase
    {
        [BindProperty]
        public Result Data { get; set; }

        public async Task OnGetAsync()
        {
            Data = await Mediator.Send(new Query());
        }

        public class Query : IRequest<Result>
        {
        }
        
        public class Result
        {
            public List<Person> Persons { get; set; }

            public class Person
            {
                public Guid Id { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
            }
        }
        public class Handler : IRequestHandler<Query, Result>
        {
            private IConfiguration _appConfig;
            private readonly DbQueryService _queryService;

            public Handler(DbQueryService queryService ,IConfiguration appConfig)
            {
                _appConfig = appConfig;
                _queryService = queryService;
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
                => new Result { Persons = await _queryService.ListQuery<Result.Person>("SELECT * FROM PERSONS") };  
        }
    }
}