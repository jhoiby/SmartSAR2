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
        [BindProperty]
        public CreatePersonCommand Data { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // TODO: Handle validation errors

            await Mediator.Send(Data);

            return RedirectToPage("Index");
        }
    }
}