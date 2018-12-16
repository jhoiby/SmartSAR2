using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contexts.Membership.Application.Commands.Persons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.WebUI.Pages;

namespace Presentation.WebUI.Areas.Membership.Pages.Persons
{
    public class CreateModel : PageModelBase
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await Mediator.Send(Data);

            Data = new CreatePersonCommand();
            ModelState.Clear();

            return Page();
        }

        [BindProperty]
        public CreatePersonCommand Data { get; set; }
    }
}