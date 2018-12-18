using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Contexts.Membership.Application;
using Contexts.Membership.Application.Queries.Persons;
using Contexts.Membership.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.WebUI.Pages;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Dapper;
using Presentation.WebUI.Services;

namespace Presentation.WebUI.Areas.Membership.Pages.Persons
{
    public class IndexModel : PageModelBase
    {
        public async Task OnGetAsync()
        {
            Data = await Mediator.Send(new Query());
        }

        [BindProperty]
        public Result Data { get; set; }

        public class Query : IRequest<Result>
        {
            // Empty query
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
            private DbQueryService _queryService;

            public Handler(DbQueryService queryService ,IConfiguration appConfig)
            {
                _appConfig = appConfig;
                _queryService = queryService;
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                return _queryService.Query("SELECT * FROM PERSONS");
            }
        }
    }
}