using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFDbFirstDemo2.Models;

namespace EFDbFirstDemo2.Controllers
{
    public class EfDemo2Controller : Controller
    {
        private readonly EmpDbContext _context;

        public EfDemo2Controller(EmpDbContext context)
        {
            _context = context;
        }

        // GET: EfDemo2
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblEmployees.ToListAsync());
        }

        // GET: EfDemo2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.TblEmployees
                .FirstOrDefaultAsync(m => m.Ecode == id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return View(tblEmployee);
        }

        // GET: EfDemo2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EfDemo2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ecode,Ename,Salary,Deptid")] TblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmployee);
        }

        // GET: EfDemo2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.TblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }
            return View(tblEmployee);
        }

        // POST: EfDemo2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ecode,Ename,Salary,Deptid")] TblEmployee tblEmployee)
        {
            if (id != tblEmployee.Ecode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmployeeExists(tblEmployee.Ecode))
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
            return View(tblEmployee);
        }

        // GET: EfDemo2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.TblEmployees
                .FirstOrDefaultAsync(m => m.Ecode == id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return View(tblEmployee);
        }

        // POST: EfDemo2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblEmployee = await _context.TblEmployees.FindAsync(id);
            if (tblEmployee != null)
            {
                _context.TblEmployees.Remove(tblEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmployeeExists(int id)
        {
            return _context.TblEmployees.Any(e => e.Ecode == id);
        }
    }
}
