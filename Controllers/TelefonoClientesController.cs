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
    public class TelefonoClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TelefonoClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TelefonoClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TelefonoClientes.ToListAsync());
        }

        // GET: TelefonoClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoCliente = await _context.TelefonoClientes
                .FirstOrDefaultAsync(m => m.CodigoTelefono == id);
            if (telefonoCliente == null)
            {
                return NotFound();
            }

            return View(telefonoCliente);
        }

        // GET: TelefonoClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TelefonoClientes/Create      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoTelefono,NumeroTelefono,Descripcion,Nit")] TelefonoCliente telefonoCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefonoCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telefonoCliente);
        }

        // GET: TelefonoClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoCliente = await _context.TelefonoClientes.FindAsync(id);
            if (telefonoCliente == null)
            {
                return NotFound();
            }
            return View(telefonoCliente);
        }

        // POST: TelefonoClientes/Edit/5     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoTelefono,NumeroTelefono,Descripcion,Nit")] TelefonoCliente telefonoCliente)
        {
            if (id != telefonoCliente.CodigoTelefono)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefonoCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoClienteExists(telefonoCliente.CodigoTelefono))
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
            return View(telefonoCliente);
        }

        // GET: TelefonoClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefonoCliente = await _context.TelefonoClientes
                .FirstOrDefaultAsync(m => m.CodigoTelefono == id);
            if (telefonoCliente == null)
            {
                return NotFound();
            }

            return View(telefonoCliente);
        }

        // POST: TelefonoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telefonoCliente = await _context.TelefonoClientes.FindAsync(id);
            _context.TelefonoClientes.Remove(telefonoCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoClienteExists(int id)
        {
            return _context.TelefonoClientes.Any(e => e.CodigoTelefono == id);
        }
    }
}
