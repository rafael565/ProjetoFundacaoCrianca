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
    public class DadosFamiliasController : Controller
    {
        private readonly Contexto _context;

        public DadosFamiliasController(Contexto context)
        {
            _context = context;
        }

        // GET: DadosFamilias
        public async Task<IActionResult> Index()
        {
            return View(await _context.DadosFamilias.ToListAsync());
        }

        // GET: DadosFamilias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoFamilia = await _context.DadosFamilias
                .FirstOrDefaultAsync(m => m.id == id);
            if (dadoFamilia == null)
            {
                return NotFound();
            }

            return View(dadoFamilia);
        }

        // GET: DadosFamilias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DadosFamilias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomeMae,DatadeNascimentoMae,telefoneMae,nomePai,DatadeNascimentoPai,telefonePai,HistoricoFamiliar,endereco,cidade,email")] DadoFamilia dadoFamilia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadoFamilia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dadoFamilia);
        }

        // GET: DadosFamilias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoFamilia = await _context.DadosFamilias.FindAsync(id);
            if (dadoFamilia == null)
            {
                return NotFound();
            }
            return View(dadoFamilia);
        }

        // POST: DadosFamilias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomeMae,DatadeNascimentoMae,telefoneMae,nomePai,DatadeNascimentoPai,telefonePai,HistoricoFamiliar,endereco,cidade,email")] DadoFamilia dadoFamilia)
        {
            if (id != dadoFamilia.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadoFamilia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadoFamiliaExists(dadoFamilia.id))
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
            return View(dadoFamilia);
        }

        // GET: DadosFamilias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoFamilia = await _context.DadosFamilias
                .FirstOrDefaultAsync(m => m.id == id);
            if (dadoFamilia == null)
            {
                return NotFound();
            }

            return View(dadoFamilia);
        }

        // POST: DadosFamilias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadoFamilia = await _context.DadosFamilias.FindAsync(id);
            if (dadoFamilia != null)
            {
                _context.DadosFamilias.Remove(dadoFamilia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadoFamiliaExists(int id)
        {
            return _context.DadosFamilias.Any(e => e.id == id);
        }
    }
}
