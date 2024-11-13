using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFundacaoCrianca.Models;

namespace ProjetoFundacaoCrianca.Controllers
{
    public class AssistentesSociaisController : Controller
    {
        private readonly Contexto _context;

        public AssistentesSociaisController(Contexto context)
        {
            _context = context;
        }

        // GET: AssistentesSociais
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssistentesSociais.ToListAsync());
        }

        // GET: AssistentesSociais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteSocial = await _context.AssistentesSociais
                .FirstOrDefaultAsync(m => m.id == id);
            if (assistenteSocial == null)
            {
                return NotFound();
            }

            return View(assistenteSocial);
        }

        // GET: AssistentesSociais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssistentesSociais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,cpf,email,telefone")] AssistenteSocial assistenteSocial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assistenteSocial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assistenteSocial);
        }

        // GET: AssistentesSociais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteSocial = await _context.AssistentesSociais.FindAsync(id);
            if (assistenteSocial == null)
            {
                return NotFound();
            }
            return View(assistenteSocial);
        }

        // POST: AssistentesSociais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,cpf,email,telefone")] AssistenteSocial assistenteSocial)
        {
            if (id != assistenteSocial.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assistenteSocial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssistenteSocialExists(assistenteSocial.id))
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
            return View(assistenteSocial);
        }

        // GET: AssistentesSociais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteSocial = await _context.AssistentesSociais
                .FirstOrDefaultAsync(m => m.id == id);
            if (assistenteSocial == null)
            {
                return NotFound();
            }

            return View(assistenteSocial);
        }

        // POST: AssistentesSociais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assistenteSocial = await _context.AssistentesSociais.FindAsync(id);
            if (assistenteSocial != null)
            {
                _context.AssistentesSociais.Remove(assistenteSocial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssistenteSocialExists(int id)
        {
            return _context.AssistentesSociais.Any(e => e.id == id);
        }
    }
}
