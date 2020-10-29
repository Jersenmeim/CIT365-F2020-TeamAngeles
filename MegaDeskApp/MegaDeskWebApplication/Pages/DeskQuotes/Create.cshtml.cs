using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWebApp.Models;

namespace MegaDeskWebApp.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWebApp.Models.MegaDeskWebAppContext _context;

        public CreateModel(MegaDeskWebApp.Models.MegaDeskWebAppContext context)
        {
            _context = context;
        }
        public List<DesktopMaterial> MaterialList = 
            Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyDeskQuote = new DeskQuote();


            if (await TryUpdateModelAsync<DeskQuote>(
                emptyDeskQuote,
                "deskQuote",
                s => s.FirstName, 
                s => s.LastName, 
                s => s.QuoteDate, 
                s => s.RushDays, 
                s => s.Width, 
                s => s.Depth,
                s => s.NumberOfDrawers, 
                s => s.DesktopMaterial))
            {
                _context.DeskQuote.Add(emptyDeskQuote);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Details", new { id = emptyDeskQuote.ID });
            }

            return null;


        }
    }
}