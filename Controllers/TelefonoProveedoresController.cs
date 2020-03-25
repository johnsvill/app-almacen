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
    public class TelefonoProveedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TelefonoProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TelefonoProveedores
        public async Task<IActionResult> Index()
        {
            return View(await _context.TelefonoProveedores.ToListAsync());
        }

        // GET: TelefonoProveedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoProveedor = await _context.TelefonoProveedores
                .FirstOrDefaultAsync(m => m.CodigoTelefono == id);
            if (telefonoProveedor == null)
            {
                return NotFound();
            }

            return View(telefonoProveedor);
        }

        // GET: TelefonoProveedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TelefonoProveedores/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTelefono,NumeroTelefono,Descripcion,CodigoProveedor")] TelefonoProveedor telefonoProveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonoProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telefonoProveedor);
        }

        // GET: TelefonoProveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoProveedor = await _context.TelefonoProveedores.FindAsync(id);
            if (telefonoProveedor == null)
            {
                return NotFound();
            }
            return View(telefonoProveedor);
        }

        // POST: TelefonoProveedores/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTelefono,NumeroTelefono,Descripcion,CodigoProveedor")] TelefonoProveedor telefonoProveedor)
        {
            if (id != telefonoProveedor.CodigoTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonoProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoProveedorExists(telefonoProveedor.CodigoTelefono))
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
            return View(telefonoProveedor);
        }

        // GET: TelefonoProveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoProveedor = await _context.TelefonoProveedores
                .FirstOrDefaultAsync(m => m.CodigoTelefono == id);
            if (telefonoProveedor == null)
            {
                return NotFound();
            }

            return View(telefonoProveedor);
        }

        // POST: TelefonoProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonoProveedor = await _context.TelefonoProveedores.FindAsync(id);
            _context.TelefonoProveedores.Remove(telefonoProveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoProveedorExists(int id)
        {
            return _context.TelefonoProveedores.Any(e => e.CodigoTelefono == id);
        }
    }
}
