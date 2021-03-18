using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudNomina.Data;

namespace crudNomina.Controllers
{
    public class DeduccionsController : Controller
    {
        private readonly NominaContext _context;

        public DeduccionsController(NominaContext context)
        {
            _context = context;
        }

        // GET: Deduccions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deduccions.ToListAsync());
        }

        // GET: Deduccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduccion = await _context.Deduccions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deduccion == null)
            {
                return NotFound();
            }

            return View(deduccion);
        }

        // GET: Deduccions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deduccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,DependeSalario,Monto,Estado")] Deduccion deduccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deduccion);
        }

        // GET: Deduccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduccion = await _context.Deduccions.FindAsync(id);
            if (deduccion == null)
            {
                return NotFound();
            }
            return View(deduccion);
        }

        // POST: Deduccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,DependeSalario,Monto,Estado")] Deduccion deduccion)
        {
            if (id != deduccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeduccionExists(deduccion.Id))
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
            return View(deduccion);
        }

        // GET: Deduccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduccion = await _context.Deduccions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deduccion == null)
            {
                return NotFound();
            }

            return View(deduccion);
        }

        // POST: Deduccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deduccion = await _context.Deduccions.FindAsync(id);
            _context.Deduccions.Remove(deduccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeduccionExists(int id)
        {
            return _context.Deduccions.Any(e => e.Id == id);
        }
    }
}
