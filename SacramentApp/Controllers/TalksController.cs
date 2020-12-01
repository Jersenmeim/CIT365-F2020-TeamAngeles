using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentApp.Data;
using SacramentApp.Models;

namespace SacramentApp.Controllers
{
    public class TalksController : Controller
    {
        private readonly SacramentAppContext _context;

        public TalksController(SacramentAppContext context)
        {
            _context = context;
        }

        // GET: Talks
        public async Task<IActionResult> Index(
        string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            var speeches = from s in _context.Talks
                           join m in _context.Meeting on s.MeetingId equals m.Id
                           orderby m.Date
                           select new TalksMeeting { SpeechData = s, MeetingData = m };


            if (!String.IsNullOrEmpty(searchString))
            {
                speeches = speeches.Where(s => s.SpeechData.NameSpeaker.Contains(searchString)
                || s.SpeechData.Topic.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    speeches = speeches.OrderByDescending(s => s.SpeechData.NameSpeaker);
                    break;
                case "Date":
                    speeches = speeches.OrderBy(s => s.MeetingData.Date);
                    break;
                case "date_desc":
                    speeches = speeches.OrderByDescending(s => s.MeetingData.Date);
                    break;
                default:
                    speeches = speeches.OrderBy(s => s.SpeechData.NameSpeaker);
                    break;
            }

            int pageSize = 5;
            return View(await PaginatedList<TalksMeeting>.CreateAsync(speeches.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Talks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speech = await _context.Talks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speech == null)
            {
                return NotFound();
            }

            return View(speech);
        }

        // GET: Speeches/Create
        public IActionResult Create(int? id)
        {


            ViewData["MId"] = id;



            return View();
        }

        // POST: Speeches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingId,NameSpeaker,Topic")] Talks talks)
        {
            if (ModelState.IsValid)
            {
               
                _context.Add(talks);
                await _context.SaveChangesAsync();
              
                return RedirectToAction("EditSpeakers", "Meetings", new { id = talks.MeetingId });
            }
            return View(talks);
          

        }

        // GET: Speeches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speech = await _context.Talks.FindAsync(id);
            if (speech == null)
            {
                return NotFound();
            }
            return View(speech);
        }

        // POST: Speeches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingId,NameSpeaker,Topic")] Talks talks)
        {
            if (id != talks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalksExists(talks.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("EditSpeakers", "Meetings", new { id = talks.MeetingId });
            }
            return View(talks);
        }

        // GET: Speeches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speech = await _context.Talks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speech == null)
            {
                return NotFound();
            }

            return View(speech);
            //return RedirectToAction("Details", "Meetings", new { id = speech.MeetingId });
        }

        // POST: Speeches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speech = await _context.Talks.FindAsync(id);
            _context.Talks.Remove(speech);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("EditSpeakers", "Meetings", new { id = speech.MeetingId });
        }
        private bool TalksExists(int id)
        {
            return _context.Talks.Any(e => e.Id == id);
        }
    }
}
