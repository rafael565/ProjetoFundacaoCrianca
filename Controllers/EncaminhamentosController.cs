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
    public class EncaminhamentosController : Controller
    {
        private readonly Contexto _context;

        public EncaminhamentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Encaminhamentos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Encaminhamentos.Include(e => e.aluno).Include(e => e.assistentesocial).Include(e => e.entidade);
            return View(await contexto.ToListAsync());
        }

        // GET: Encaminhamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encaminhamento = await _context.Encaminhamentos
                .Include(e => e.aluno)
                .Include(e => e.assistentesocial)
                .Include(e => e.entidade)
                .FirstOrDefaultAsync(m => m.id == id);
            if (encaminhamento == null)
            {
                return NotFound();
            }

            return View(encaminhamento);
        }

        // GET: Encaminhamentos/Create
        public IActionResult Create()
        {
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "cpf");
            ViewData["assistentesocialID"] = new SelectList(_context.AssistentesSociais, "id", "cpf");
            ViewData["entidadeID"] = new SelectList(_context.Entidades, "id", "endereco");
            return View();
        }

        // POST: Encaminhamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,entidadeID,assistentesocialID,alunoID,motivo,DatadeEncaminhamento")] Encaminhamento encaminhamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encaminhamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "cpf", encaminhamento.alunoID);
            ViewData["assistentesocialID"] = new SelectList(_context.AssistentesSociais, "id", "cpf", encaminhamento.assistentesocialID);
            ViewData["entidadeID"] = new SelectList(_context.Entidades, "id", "endereco", encaminhamento.entidadeID);
            return View(encaminhamento);
        }

        // GET: Encaminhamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encaminhamento = await _context.Encaminhamentos.FindAsync(id);
            if (encaminhamento == null)
            {
                return NotFound();
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "cpf", encaminhamento.alunoID);
            ViewData["assistentesocialID"] = new SelectList(_context.AssistentesSociais, "id", "cpf", encaminhamento.assistentesocialID);
            ViewData["entidadeID"] = new SelectList(_context.Entidades, "id", "endereco", encaminhamento.entidadeID);
            return View(encaminhamento);
        }

        // POST: Encaminhamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,entidadeID,assistentesocialID,alunoID,motivo,DatadeEncaminhamento")] Encaminhamento encaminhamento)
        {
            if (id != encaminhamento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encaminhamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncaminhamentoExists(encaminhamento.id))
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
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "cpf", encaminhamento.alunoID);
            ViewData["assistentesocialID"] = new SelectList(_context.AssistentesSociais, "id", "cpf", encaminhamento.assistentesocialID);
            ViewData["entidadeID"] = new SelectList(_context.Entidades, "id", "endereco", encaminhamento.entidadeID);
            return View(encaminhamento);
        }

        // GET: Encaminhamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encaminhamento = await _context.Encaminhamentos
                .Include(e => e.aluno)
                .Include(e => e.assistentesocial)
                .Include(e => e.entidade)
                .FirstOrDefaultAsync(m => m.id == id);
            if (encaminhamento == null)
            {
                return NotFound();
            }

            return View(encaminhamento);
        }

        // POST: Encaminhamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encaminhamento = await _context.Encaminhamentos.FindAsync(id);
            if (encaminhamento != null)
            {
                _context.Encaminhamentos.Remove(encaminhamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncaminhamentoExists(int id)
        {
            return _context.Encaminhamentos.Any(e => e.id == id);
        }
    }
}
