using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
    public class TimeSheetsController : Controller
    {
        private readonly WebAppTestDbContext _context;

        public TimeSheetsController(WebAppTestDbContext context)
        {
            _context = context;
        }

        // GET: TimeSheets
        public async Task<IActionResult> Index()
        {
              return _context.TimeSheetSet != null ? 
                          View(await _context.TimeSheetSet.ToListAsync()) :
                          Problem("Entity set 'WebAppTestDbContext.TimeSheetSet'  is null.");
        }

        // GET: TimeSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeSheetSet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheetSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // GET: TimeSheets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeSheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEmployment,Start,BreakStart,BreakEnd,End")] TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeSheet);
        }

        // GET: TimeSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeSheetSet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheetSet.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEmployment,Start,BreakStart,BreakEnd,End")] TimeSheet timeSheet)
        {
            if (id != timeSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSheetExists(timeSheet.Id))
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
            return View(timeSheet);
        }

        // GET: TimeSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeSheetSet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheetSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // POST: TimeSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeSheetSet == null)
            {
                return Problem("Entity set 'WebAppTestDbContext.TimeSheetSet'  is null.");
            }
            var timeSheet = await _context.TimeSheetSet.FindAsync(id);
            if (timeSheet != null)
            {
                _context.TimeSheetSet.Remove(timeSheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetExists(int id)
        {
          return (_context.TimeSheetSet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
