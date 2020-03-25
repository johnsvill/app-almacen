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
    public class EmailClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmailClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmailClientes.ToListAsync());
        }

        // GET: EmailClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailCliente = await _context.EmailClientes
                .FirstOrDefaultAsync(m => m.CodigoEmail == id);
            if (emailCliente == null)
            {
                return NotFound();
            }

            return View(emailCliente);
        }

        // GET: EmailClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailClientes/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEmail,Email,Nit")] EmailCliente emailCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailCliente);
        }

        // GET: EmailClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailCliente = await _context.EmailClientes.FindAsync(id);
            if (emailCliente == null)
            {
                return NotFound();
            }
            return View(emailCliente);
        }

        // POST: EmailClientes/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEmail,Email,Nit")] EmailCliente emailCliente)
        {
            if (id != emailCliente.CodigoEmail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailClienteExists(emailCliente.CodigoEmail))
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
            return View(emailCliente);
        }

        // GET: EmailClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailCliente = await _context.EmailClientes
                .FirstOrDefaultAsync(m => m.CodigoEmail == id);
            if (emailCliente == null)
            {
                return NotFound();
            }

            return View(emailCliente);
        }

        // POST: EmailClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emailCliente = await _context.EmailClientes.FindAsync(id);
            _context.EmailClientes.Remove(emailCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailClienteExists(int id)
        {
            return _context.EmailClientes.Any(e => e.CodigoEmail == id);
        }
    }
}
