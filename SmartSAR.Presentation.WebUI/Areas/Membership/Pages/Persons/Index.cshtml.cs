using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts.Membership.Application;
using Contexts.Membership.Application.Queries.Persons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.WebUI.Pages;

namespace Presentation.WebUI.Areas.Membership.Pages.Persons
{
    public class IndexModel : PageModelBase
    {
        public async Task OnGet()
        {
            Data = await Mediator.Send(new GetAllPersonsQuery());
        }

        [BindProperty]
        public List<PersonDto> Data { get; set; }
    }
}