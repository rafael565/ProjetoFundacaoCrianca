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
    public class PerfisSociosEconomicosController : Controller
    {
        private readonly Contexto _context;

        public PerfisSociosEconomicosController(Contexto context)
        {
            _context = context;
        }

        // GET: PerfisSociosEconomicos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.PerfisSociosEconomicos.Include(p => p.dadofamilia);
            return View(await contexto.ToListAsync());
        }

        // GET: PerfisSociosEconomicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfilSocioEconomico = await _context.PerfisSociosEconomicos
                .Include(p => p.dadofamilia)
                .FirstOrDefaultAsync(m => m.id == id);
            if (perfilSocioEconomico == null)
            {
                return NotFound();
            }

            return View(perfilSocioEconomico);
        }

        // GET: PerfisSociosEconomicos/Create
        public IActionResult Create()
        {
            ViewData["dadofamiliaID"] = new SelectList(_context.DadosFamilias, "id", "HistoricoFamiliar");
            return View();
        }

        // POST: PerfisSociosEconomicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,dadofamiliaID,rendafamilia,situacaofamilia,profissaoPai,profissaoMae")] PerfilSocioEconomico perfilSocioEconomico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfilSocioEconomico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["dadofamiliaID"] = new SelectList(_context.DadosFamilias, "id", "HistoricoFamiliar", perfilSocioEconomico.dadofamiliaID);
            return View(perfilSocioEconomico);
        }

        // GET: PerfisSociosEconomicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfilSocioEconomico = await _context.PerfisSociosEconomicos.FindAsync(id);
            if (perfilSocioEconomico == null)
            {
                return NotFound();
            }
            ViewData["dadofamiliaID"] = new SelectList(_context.DadosFamilias, "id", "HistoricoFamiliar", perfilSocioEconomico.dadofamiliaID);
            return View(perfilSocioEconomico);
        }

        // POST: PerfisSociosEconomicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,dadofamiliaID,rendafamilia,situacaofamilia,profissaoPai,profissaoMae")] PerfilSocioEconomico perfilSocioEconomico)
        {
            if (id != perfilSocioEconomico.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfilSocioEconomico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilSocioEconomicoExists(perfilSocioEconomico.id))
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
            ViewData["dadofamiliaID"] = new SelectList(_context.DadosFamilias, "id", "HistoricoFamiliar", perfilSocioEconomico.dadofamiliaID);
            return View(perfilSocioEconomico);
        }

        // GET: PerfisSociosEconomicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfilSocioEconomico = await _context.PerfisSociosEconomicos
                .Include(p => p.dadofamilia)
                .FirstOrDefaultAsync(m => m.id == id);
            if (perfilSocioEconomico == null)
            {
                return NotFound();
            }

            return View(perfilSocioEconomico);
        }

        // POST: PerfisSociosEconomicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfilSocioEconomico = await _context.PerfisSociosEconomicos.FindAsync(id);
            if (perfilSocioEconomico != null)
            {
                _context.PerfisSociosEconomicos.Remove(perfilSocioEconomico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilSocioEconomicoExists(int id)
        {
            return _context.PerfisSociosEconomicos.Any(e => e.id == id);
        }
    }
}
