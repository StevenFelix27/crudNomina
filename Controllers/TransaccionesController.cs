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
    public class TransaccionesController : Controller
    {
        private readonly NominaContext _context;

        public TransaccionesController(NominaContext context)
        {
            _context = context;
        }

        // GET: Transacciones
        public async Task<IActionResult> Index()
        {
            var nominaContext = _context.Transaccions.Include(t => t.IdDeduccionNavigation).Include(t => t.IdEmpleadoNavigation).Include(t => t.IdIngresoNavigation);
            return View(await nominaContext.ToListAsync());
        }

        // GET: Transacciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }   

            var transaccion = await _context.Transaccions
                .Include(t => t.IdDeduccionNavigation)
                .Include(t => t.IdEmpleadoNavigation)
                .Include(t => t.IdIngresoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // GET: Transacciones/Create
        public IActionResult Create()
        {
            ViewData["IdDeduccion"] = new SelectList(_context.Deduccions, "Id", "Nombre");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Nombre");
            ViewData["IdIngreso"] = new SelectList(_context.Ingresos, "Id", "Nombre");
            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEmpleado,IdDeduccion,IdIngreso,TipoTransaccion,Fecha,Monto,Estado")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDeduccion"] = new SelectList(_context.Deduccions, "Id", "Nombre", transaccion.IdDeduccion);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Nombre", transaccion.IdEmpleado);
            ViewData["IdIngreso"] = new SelectList(_context.Ingresos, "Id", "Nombre", transaccion.IdIngreso);
            return View(transaccion);
        }

        // GET: Transacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transaccions.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }
            ViewData["IdDeduccion"] = new SelectList(_context.Deduccions, "Id", "Nombre", transaccion.IdDeduccion);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Nombre", transaccion.IdEmpleado);
            ViewData["IdIngreso"] = new SelectList(_context.Ingresos, "Id", "Nombre", transaccion.IdIngreso);
            return View(transaccion);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEmpleado,IdDeduccion,IdIngreso,TipoTransaccion,Fecha,Monto,Estado")] Transaccion transaccion)
        {
            if (id != transaccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccionExists(transaccion.Id))
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
            ViewData["IdDeduccion"] = new SelectList(_context.Deduccions, "Id", "Nombre", transaccion.IdDeduccion);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Nombre", transaccion.IdEmpleado);
            ViewData["IdIngreso"] = new SelectList(_context.Ingresos, "Id", "Nombre", transaccion.IdIngreso);
            return View(transaccion);
        }

        // GET: Transacciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.Transaccions
                .Include(t => t.IdDeduccionNavigation)
                .Include(t => t.IdEmpleadoNavigation)
                .Include(t => t.IdIngresoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaccion = await _context.Transaccions.FindAsync(id);
            _context.Transaccions.Remove(transaccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccionExists(int id)
        {
            return _context.Transaccions.Any(e => e.Id == id);
        }
    }
}
