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
    public class EmployeesController : Controller
    {
        private readonly WebAppTestDbContext _context;

        public EmployeesController(WebAppTestDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(int? Id)
        {
            if(Id == null)
            {
                return _context.EmployeeSet != null ?
                         View(await _context.EmployeeSet.ToListAsync()) :
                         Problem("Entity set 'WebAppTestDbContext.EmployeeSet'  is null.");
            }
            else
            {
                var model = await _context.EmployeeSet.Where(e => e.IdDepartment == Id).ToListAsync();
                return View(model);
            }
             
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeSet == null)
            {
                return NotFound();
            }

            var employee = await _context.EmployeeSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Sex,Birthday,Address,IdDepartment,Img,Password,Create_At")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeSet == null)
            {
                return NotFound();
            }

            var employee = await _context.EmployeeSet.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Sex,Birthday,Address,IdDepartment,Img,Password,Create_At")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeSet == null)
            {
                return NotFound();
            }

            var employee = await _context.EmployeeSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeSet == null)
            {
                return Problem("Entity set 'WebAppTestDbContext.EmployeeSet'  is null.");
            }
            var employee = await _context.EmployeeSet.FindAsync(id);
            if (employee != null)
            {
                _context.EmployeeSet.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.EmployeeSet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
