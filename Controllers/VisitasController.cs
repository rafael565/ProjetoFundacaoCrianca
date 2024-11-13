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
    public class VisitasController : Controller
    {
        private readonly Contexto _context;

        public VisitasController(Contexto context)
        {
            _context = context;
        }

        // GET: Visitas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Visitas.Include(v => v.assistenteSocial).Include(v => v.dadofamilia);
            return View(await contexto.ToListAsync());
        }

        // GET: Visitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas
                .Include(v => v.assistenteSocial)
                .Include(v => v.dadofamilia)
                .FirstOrDefaultAsync(m => m.id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // GET: Visitas/Create
        public IActionResult Create()
        {
            ViewData["assistenteSocialID"] = new SelectList(_context.AssistentesSociais, "id", "cpf");
            ViewData["dadofamiliaID"] = new SelectList(_context.DadosFamilias, "id", "HistoricoFamiliar");
            return View();
        }

        // POST: Visitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,assistenteSocialID,dadofamiliaID,DataAtendimento,observacao")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["assistenteSocialID"] = new SelectList(_context.AssistentesSociais, "id", "cpf", visita.assistenteSocialID);
            ViewData["dadofamiliaID"] = new SelectList(_context.DadosFamilias, "id", "HistoricoFamiliar", visita.dadofamiliaID);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            ViewData["assistenteSocialID"] = new SelectList(_context.AssistentesSociais, "id", "cpf", visita.assistenteSocialID);
            ViewData["dadofamiliaID"] = new SelectList(_context.DadosFamilias, "id", "HistoricoFamiliar", visita.dadofamiliaID);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,assistenteSocialID,dadofamiliaID,DataAtendimento,observacao")] Visita visita)
        {
            if (id != visita.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.id))
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
            ViewData["assistenteSocialID"] = new SelectList(_context.AssistentesSociais, "id", "cpf", visita.assistenteSocialID);
            ViewData["dadofamiliaID"] = new SelectList(_context.DadosFamilias, "id", "HistoricoFamiliar", visita.dadofamiliaID);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas
                .Include(v => v.assistenteSocial)
                .Include(v => v.dadofamilia)
                .FirstOrDefaultAsync(m => m.id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visitas.FindAsync(id);
            if (visita != null)
            {
                _context.Visitas.Remove(visita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaExists(int id)
        {
            return _context.Visitas.Any(e => e.id == id);
        }
    }
}
