using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebPersonal.Data;
using AppWebPersonal.Models;

namespace AppWebPersonal.Controllers
{
    public class TipoEmpaquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoEmpaquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoEmpaques
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEmpaques.ToListAsync());
        }

        // GET: TipoEmpaques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpaque = await _context.TipoEmpaques
                .FirstOrDefaultAsync(m => m.CodigoEmpaque == id);
            if (tipoEmpaque == null)
            {
                return NotFound();
            }

            return View(tipoEmpaque);
        }

        // GET: TipoEmpaques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEmpaques/Create      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEmpaque,Descripcion")] TipoEmpaque tipoEmpaque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEmpaque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEmpaque);
        }

        // GET: TipoEmpaques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpaque = await _context.TipoEmpaques.FindAsync(id);
            if (tipoEmpaque == null)
            {
                return NotFound();
            }
            return View(tipoEmpaque);
        }

        // POST: TipoEmpaques/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEmpaque,Descripcion")] TipoEmpaque tipoEmpaque)
        {
            if (id != tipoEmpaque.CodigoEmpaque)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEmpaque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEmpaqueExists(tipoEmpaque.CodigoEmpaque))
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
            return View(tipoEmpaque);
        }

        // GET: TipoEmpaques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpaque = await _context.TipoEmpaques
                .FirstOrDefaultAsync(m => m.CodigoEmpaque == id);
            if (tipoEmpaque == null)
            {
                return NotFound();
            }

            return View(tipoEmpaque);
        }

        // POST: TipoEmpaques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEmpaque = await _context.TipoEmpaques.FindAsync(id);
            _context.TipoEmpaques.Remove(tipoEmpaque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEmpaqueExists(int id)
        {
            return _context.TipoEmpaques.Any(e => e.CodigoEmpaque == id);
        }
    }
}
