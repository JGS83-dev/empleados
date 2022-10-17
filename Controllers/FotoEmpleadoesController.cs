using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using empleados.Models;

namespace empleados.Controllers
{
    public class FotoEmpleadoesController : Controller
    {
        private readonly registro_empleadosContext _context;

        public FotoEmpleadoesController(registro_empleadosContext context)
        {
            _context = context;
        }

        // GET: FotoEmpleadoes
        public async Task<IActionResult> Index()
        {
            var registro_empleadosContext = _context.FotoEmpleados.Include(f => f.IdUsuarioNavigation);
            return View(await registro_empleadosContext.ToListAsync());
        }

        // GET: FotoEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FotoEmpleados == null)
            {
                return NotFound();
            }

            var fotoEmpleado = await _context.FotoEmpleados
                .Include(f => f.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdFoto == id);
            if (fotoEmpleado == null)
            {
                return NotFound();
            }

            return View(fotoEmpleado);
        }

        // GET: FotoEmpleadoes/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Empleados, "IdEmpleado", "Apellido");
            return View();
        }

        // POST: FotoEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFoto,IdUsuario,Foto")] FotoEmpleado fotoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fotoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Empleados, "IdEmpleado", "Apellido", fotoEmpleado.IdUsuario);
            return View(fotoEmpleado);
        }

        // GET: FotoEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FotoEmpleados == null)
            {
                return NotFound();
            }

            var fotoEmpleado = await _context.FotoEmpleados.FindAsync(id);
            if (fotoEmpleado == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Empleados, "IdEmpleado", "Apellido", fotoEmpleado.IdUsuario);
            return View(fotoEmpleado);
        }

        // POST: FotoEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFoto,IdUsuario,Foto")] FotoEmpleado fotoEmpleado)
        {
            if (id != fotoEmpleado.IdFoto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotoEmpleadoExists(fotoEmpleado.IdFoto))
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
            ViewData["IdUsuario"] = new SelectList(_context.Empleados, "IdEmpleado", "Apellido", fotoEmpleado.IdUsuario);
            return View(fotoEmpleado);
        }

        // GET: FotoEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FotoEmpleados == null)
            {
                return NotFound();
            }

            var fotoEmpleado = await _context.FotoEmpleados
                .Include(f => f.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdFoto == id);
            if (fotoEmpleado == null)
            {
                return NotFound();
            }

            return View(fotoEmpleado);
        }

        // POST: FotoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FotoEmpleados == null)
            {
                return Problem("Entity set 'registro_empleadosContext.FotoEmpleados'  is null.");
            }
            var fotoEmpleado = await _context.FotoEmpleados.FindAsync(id);
            if (fotoEmpleado != null)
            {
                _context.FotoEmpleados.Remove(fotoEmpleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotoEmpleadoExists(int id)
        {
          return _context.FotoEmpleados.Any(e => e.IdFoto == id);
        }
    }
}
