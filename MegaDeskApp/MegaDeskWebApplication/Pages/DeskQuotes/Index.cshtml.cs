using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebApp.Models;

namespace MegaDeskWebApp.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebApp.Models.MegaDeskWebAppContext _context;

        public IndexModel(MegaDeskWebApp.Models.MegaDeskWebAppContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<DeskQuote> DeskQuote { get; set; }


        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<DeskQuote> deskQuoteIQ = from s in _context.DeskQuote
                                                select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                deskQuoteIQ = deskQuoteIQ.Where(s => s.LastName.Contains(searchString)
                || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    deskQuoteIQ = deskQuoteIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    deskQuoteIQ = deskQuoteIQ.OrderBy(s => s.QuoteDate);
                    break;
                case "date_desc":
                    deskQuoteIQ = deskQuoteIQ.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    deskQuoteIQ = deskQuoteIQ.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 5;

            DeskQuote = await PaginatedList<DeskQuote>.CreateAsync(
                deskQuoteIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
