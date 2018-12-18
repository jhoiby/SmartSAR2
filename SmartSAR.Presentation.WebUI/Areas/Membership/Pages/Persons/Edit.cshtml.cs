using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Contexts.Membership.Application.Commands.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.WebUI.Pages;
using Presentation.WebUI.Services;
using AutoMapper;
using HtmlTags.Reflection;

namespace Presentation.WebUI.Areas.Membership.Pages.Persons
{
    public class EditModel : PageModelBase
    {
        private IMapper _mapper;

        public EditModel(IMapper mapper)
        {
            _mapper = mapper;
        }

        [BindProperty]
        public Result Data { get; set; }

        public async Task OnGetAsync(Guid personId)
        {
            Data = await Mediator.Send(new Query(personId));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await Mediator.Send(_mapper.Map<EditPersonCommand>(Data));

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

        class QueryHandler : IRequestHandler<Query, Result>
        {
            private DbQueryService _queryService;

            public QueryHandler(DbQueryService queryService)
            {
                _queryService = queryService;
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken) =>
                await _queryService.Query<Result>(
                    "SELECT * FROM Persons WHERE Id = @PersonId",
                    new {request.PersonId});
        }

        public class MappingProfile : Profile
        {
            public MappingProfile() => CreateMap<Result, EditPersonCommand>()
                .ForMember(dest => dest.RequestId, opt => opt.AddTransform(id => Guid.NewGuid()));
        }
    }
}