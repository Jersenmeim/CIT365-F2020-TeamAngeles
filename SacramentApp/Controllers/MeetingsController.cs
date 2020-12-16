using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentApp.Data;
using SacramentApp.Models;
using Spire.Pdf;
using Spire.Pdf.Graphics;

namespace SacramentApp.Models
{
    public class MeetingsController : Controller
    {
        private readonly SacramentAppContext _context;

        public MeetingsController(SacramentAppContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index(
           string sortOrder,
           string currentFilter,
           string searchString,
           int? pageNumber,
           string DateInit, string DateEnd, string dateInitFilter, string dateEndFilter)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (DateInit != null)
            {
                pageNumber = 1;
            }
            else
            {
                DateInit = dateInitFilter;
            }
            if (DateEnd != null)
            {
                pageNumber = 1;
            }
            else
            {
                DateEnd = dateEndFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            ViewData["DateInitFilter"] = DateInit;
            ViewData["DateEndFilter"] = DateEnd;
            DateTime DateInitTemp = Convert.ToDateTime(DateInit);
            DateTime DateEndTemp = Convert.ToDateTime(DateEnd);
            var meetings = from s in _context.Meeting
                           orderby s.Date descending
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                meetings = meetings.Where(s => s.ConductingLeader.Contains(searchString)).OrderByDescending(s => s.Date);

            }
            if (!(DateInitTemp == default(DateTime)) && !(DateEndTemp == default(DateTime)))
            {
                meetings = meetings.Where(s => s.Date >= DateInitTemp && s.Date <= DateEndTemp).OrderByDescending(s => s.Date);

            }
            else if (!(DateInitTemp == default(DateTime)))
            {
                meetings = meetings.Where(s => s.Date >= DateInitTemp).OrderByDescending(s => s.Date);
            }
            else if (!(DateEndTemp == default(DateTime)))
            {
                meetings = meetings.Where(s => s.Date <= DateEndTemp).OrderByDescending(s => s.Date);
            }

            switch (sortOrder)
            {
               
                case "Date":
                    meetings = meetings.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    meetings = meetings.OrderByDescending(s => s.Date);
                    break;       
            }

            int pageSize = 5;
            return View(await PaginatedList<Meeting>.CreateAsync(meetings.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(s => s.Talks)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,ConductingLeader,OpeningHymn,Invocation,SacramentHymn,IntermediateHymn,ClosingHymn,Benediction")] Meeting meeting)
        {
            var dateMeeting = await _context.Meeting
         .Include(s => s.Talks)
         .AsNoTracking()
         .FirstOrDefaultAsync(m => m.Date == meeting.Date);
            if (dateMeeting != null)
            {
                ModelState.AddModelError(string.Empty, "There exists a register for this date");
            }
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,ConductingLeader,OpeningHymn,Invocation,SacramentHymn,IntermediateHymn,ClosingHymn,Benediction")] Meeting meeting)
        {
            if (id != meeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.FindAsync(id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditSpeakers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting

            .Include(s => s.Talks)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }




        //This Section Describe How to Print


        public async Task<IActionResult> Print(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
            .Include(s => s.Talks)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (meeting == null)
            {
                return NotFound();
            }



            //Create New File
            var fileName = meeting.Date.ToShortDateString();
            fileName = fileName.Replace('/', '_');
            fileName = "sacrament_Meeting_agenda_" + fileName.Replace('-', '_') + ".pdf";

            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();
            doc.PageSettings.Margins = new PdfMargins(0);
            PdfMargins margins = new PdfMargins(60, 60, 60, 60);

            
            doc.Template.Top = CreateHeaderTemplate(doc, margins);
            doc.Template.Bottom = new PdfPageTemplateElement(doc.PageSettings.Size.Width, margins.Bottom);
            doc.Template.Left = new PdfPageTemplateElement(margins.Left, doc.PageSettings.Size.Height);
            doc.Template.Right = new PdfPageTemplateElement(margins.Right, doc.PageSettings.Size.Height);










            //draw text in header space
            
            SizeF pageSize = doc.PageSettings.Size;
            float x = margins.Left;
            float y = 0;
            float width = page.Canvas.ClientSize.Width;
            float height = page.Canvas.ClientSize.Height;
            float init = pageSize.Width - x - width - 2;
            float end = width - 20;


            PdfSolidBrush brush = new PdfSolidBrush(Color.Black);
            PdfTrueTypeFont fontRegular = new PdfTrueTypeFont(new Font("Helvetica", 14f, FontStyle.Regular));
            PdfTrueTypeFont fontBold = new PdfTrueTypeFont(new Font("Helvetica", 14f, FontStyle.Bold));
            PdfStringFormat alignLeft = new PdfStringFormat(PdfTextAlignment.Left);
            PdfStringFormat alignRight = new PdfStringFormat(PdfTextAlignment.Right);
            PdfStringFormat alignCenter = new PdfStringFormat(PdfTextAlignment.Center);
            PdfStringFormat alignJustify = new PdfStringFormat(PdfTextAlignment.Justify);

            //draw line
            PdfPen pen = new PdfPen(PdfBrushes.Black, 0.3f);
                                                                                        //vertical; and Horizontal
            page.Canvas.DrawString("Date: ", fontBold, brush, pageSize.Width - x - width - 2, 40);
            page.Canvas.DrawString(meeting.Date.ToShortDateString(), fontRegular, brush, pageSize.Width - x - width + 35, 40);



            page.Canvas.DrawString("Conducting: ", fontBold, brush, pageSize.Width - x - width - 2, 60);
            page.Canvas.DrawString(meeting.ConductingLeader, fontRegular, brush, pageSize.Width - x - width + 80, 60);

            page.Canvas.DrawString("Announcements: ", fontBold, brush, pageSize.Width - x - width - 2, 80);

            page.Canvas.DrawLine(pen, init, y + 110, end, y + 110);
            page.Canvas.DrawLine(pen, init, y + 130, end, y + 130);
            page.Canvas.DrawLine(pen, init, y + 150, end, y + 150);




            page.Canvas.DrawString("Opening hymn: ", fontBold, brush, pageSize.Width - x - width - 2, 170);
            page.Canvas.DrawString(meeting.OpeningHymn, fontRegular, brush, pageSize.Width - x - width + 105, 170);


            page.Canvas.DrawString("Invocation: ", fontBold, brush, pageSize.Width - x - width - 2, 190);
            page.Canvas.DrawString(meeting.Invocation, fontRegular, brush, pageSize.Width - x - width + 80, 190);



            page.Canvas.DrawString("Ward and Stake Bussiness: ", fontBold, brush, pageSize.Width - x - width - 2, 210);
            page.Canvas.DrawLine(pen, init, y + 240, end, y + 240);
            page.Canvas.DrawLine(pen, init, y + 260, end, y + 260);
            page.Canvas.DrawLine(pen, init, y + 280, end, y + 280);


            page.Canvas.DrawString("Sacrament hymn: ", fontBold, brush, pageSize.Width - x - width - 2, 300);
            page.Canvas.DrawString(meeting.SacramentHymn, fontRegular, brush, pageSize.Width - x - width + 125, 300);



            page.Canvas.DrawString("Speakers", fontBold, brush, pageSize.Width - x - width - 2, 330);

         
            int count = 0;
            int vPosition = 340;
            int totalSpeakers = meeting.Talks.Count();

            foreach (var item in meeting.Talks)
            {
                count++;
                string ordinalNumber = "";
                switch (count)
                {
                    case 1:
                        ordinalNumber = count + "st ";
                        break;
                    case 2:
                        ordinalNumber = count + "nd";
                        break;
                    case 3:
                        ordinalNumber = count + "rd";
                        break;
                    default:
                        ordinalNumber = count + "th";
                        break;
                }
                string speaker = ordinalNumber + " Speaker: ";
                vPosition = vPosition + 20;


                page.Canvas.DrawString(speaker, fontBold, brush, pageSize.Width - x - width - 2, vPosition);
                page.Canvas.DrawString(item.NameSpeaker, fontRegular, brush, pageSize.Width - x - width + 90, vPosition);
                page.Canvas.DrawString("Topic:", fontBold, brush, width - 250, vPosition);
                page.Canvas.DrawString(item.Topic, fontRegular, brush, width - 195, vPosition);






            }

            vPosition = vPosition + 40;



            page.Canvas.DrawString("Benediction: ", fontBold, brush, pageSize.Width - x - width - 2, vPosition + 40);
            page.Canvas.DrawString(meeting.Benediction, fontRegular, brush, pageSize.Width - x - width + 85, vPosition + 40);


            if (count == 2 && meeting.IntermediateHymn != null)
            {
                vPosition = vPosition + 20;
                page.Canvas.DrawString("Intermideate Hymn: ", fontBold, brush, pageSize.Width - x - width - 2, vPosition);
                page.Canvas.DrawString(meeting.IntermediateHymn, fontRegular, brush, pageSize.Width - x - width + 130, vPosition);
            }

           


            page.Canvas.DrawString("Closing hymn: ", fontBold, brush, pageSize.Width - x - width - 2, vPosition + 20);
            page.Canvas.DrawString(meeting.ClosingHymn, fontRegular, brush, pageSize.Width - x - width + 100, vPosition + 20);



            var path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/pdfsavedfiles", fileName);
            doc.SaveToFile(path);
            doc.Close();
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));

        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        private PdfPageTemplateElement CreateHeaderTemplate(PdfDocument doc, PdfMargins margins)
        {
            //get page size
            SizeF pageSize = doc.PageSettings.Size;

            //create a PdfPageTemplateElement object as header space
            PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Top);
            headerSpace.Foreground = false;

            //declare two float variables
            float x = margins.Left;
            float y = 0;
            //draw line in header space
            PdfPen pen = new PdfPen(PdfBrushes.Gray, 2);
            headerSpace.Graphics.DrawLine(pen, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2);

            //draw text in header space
            PdfTrueTypeFont font = new PdfTrueTypeFont(new Font("Helvetica", 25f, FontStyle.Bold));
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
            String headerText = "SACRAMENT MEETING AGENDA";
            SizeF size = font.MeasureString(headerText, format);
            headerSpace.Graphics.DrawString(headerText, font, PdfBrushes.Gray, pageSize.Width - x - size.Width + 165, margins.Top - (size.Height + 5), format);

            //return headerSpace
            return headerSpace;
        }

















        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.Id == id);
        }
    }
}
