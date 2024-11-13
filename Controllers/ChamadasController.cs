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
    public class ChamadasController : Controller
    {
        private readonly Contexto _context;

        public ChamadasController(Contexto context)
        {
            _context = context;
        }

        // GET: Chamadas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Chamadas.Include(c => c.matricula);
            return View(await contexto.ToListAsync());
        }

        // GET: Chamadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamada = await _context.Chamadas
                .Include(c => c.matricula)
                .FirstOrDefaultAsync(m => m.id == id);
            if (chamada == null)
            {
                return NotFound();
            }

            return View(chamada);
        }

        // GET: Chamadas/Create
        public IActionResult Create()
        {
            ViewData["matriculaID"] = new SelectList(_context.Matriculas, "id", "id");
            return View();
        }

        // POST: Chamadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,matriculaID,DatadeChamada,Presenca")] Chamada chamada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["matriculaID"] = new SelectList(_context.Matriculas, "id", "id", chamada.matriculaID);
            return View(chamada);
        }

        // GET: Chamadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamada = await _context.Chamadas.FindAsync(id);
            if (chamada == null)
            {
                return NotFound();
            }
            ViewData["matriculaID"] = new SelectList(_context.Matriculas, "id", "id", chamada.matriculaID);
            return View(chamada);
        }

        // POST: Chamadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,matriculaID,DatadeChamada,Presenca")] Chamada chamada)
        {
            if (id != chamada.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadaExists(chamada.id))
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
            ViewData["matriculaID"] = new SelectList(_context.Matriculas, "id", "id", chamada.matriculaID);
            return View(chamada);
        }

        // GET: Chamadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamada = await _context.Chamadas
                .Include(c => c.matricula)
                .FirstOrDefaultAsync(m => m.id == id);
            if (chamada == null)
            {
                return NotFound();
            }

            return View(chamada);
        }

        // POST: Chamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamada = await _context.Chamadas.FindAsync(id);
            if (chamada != null)
            {
                _context.Chamadas.Remove(chamada);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadaExists(int id)
        {
            return _context.Chamadas.Any(e => e.id == id);
        }
    }
}
