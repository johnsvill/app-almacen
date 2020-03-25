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
    public class EmailProveedoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmailProveedores
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmailProveedores.ToListAsync());
        }

        // GET: EmailProveedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailProveedor = await _context.EmailProveedores
                .FirstOrDefaultAsync(m => m.CodigoEmail == id);
            if (emailProveedor == null)
            {
                return NotFound();
            }

            return View(emailProveedor);
        }

        // GET: EmailProveedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailProveedores/Create      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEmail,Email,CodigoProveedor")] EmailProveedor emailProveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailProveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailProveedor);
        }

        // GET: EmailProveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailProveedor = await _context.EmailProveedores.FindAsync(id);
            if (emailProveedor == null)
            {
                return NotFound();
            }
            return View(emailProveedor);
        }

        // POST: EmailProveedores/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEmail,Email,CodigoProveedor")] EmailProveedor emailProveedor)
        {
            if (id != emailProveedor.CodigoEmail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailProveedorExists(emailProveedor.CodigoEmail))
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
            return View(emailProveedor);
        }

        // GET: EmailProveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailProveedor = await _context.EmailProveedores
                .FirstOrDefaultAsync(m => m.CodigoEmail == id);
            if (emailProveedor == null)
            {
                return NotFound();
            }

            return View(emailProveedor);
        }

        // POST: EmailProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emailProveedor = await _context.EmailProveedores.FindAsync(id);
            _context.EmailProveedores.Remove(emailProveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailProveedorExists(int id)
        {
            return _context.EmailProveedores.Any(e => e.CodigoEmail == id);
        }
    }
}
