using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  
    [Authorize(Roles = "Admin")]
   
    public class despesasController : Controller
    {
        private readonly DespesasContext _context;

        public despesasController(DespesasContext context)
        {
            _context = context;
        }

        // GET: despesas
        public async Task<IActionResult> Index(string searchString)
        {
            var nome = from m in _context.Despesas select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                nome = nome.Where(s => s.UserName.Contains(searchString));
            }

            return View(await nome.ToListAsync());
        }

        // GET: despesas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas
                .FirstOrDefaultAsync(m => m.DespID == id);
            if (despesas == null)
            {
                return NotFound();
            }

            return View(despesas);
        }

        // GET: despesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: despesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Aluguel,Agua,Luz,Telefone,Internet,Pagamentos,Materiais,ReleaseDate")] despesas despesas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(despesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(despesas);
        }

        // GET: despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas.FindAsync(id);
            if (despesas == null)
            {
                return NotFound();
            }
            return View(despesas);
        }

        // POST: despesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Aluguel,Agua,Luz,Telefone,Internet,Pagamentos,Materiais,ReleaseDate")] despesas despesas)
        {
            if (id != despesas.DespID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(despesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!despesasExists(despesas.DespID))
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
            return View(despesas);
        }

        // GET: despesas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesas = await _context.Despesas
                .FirstOrDefaultAsync(m => m.DespID == id);
            if (despesas == null)
            {
                return NotFound();
            }

            return View(despesas);
        }

        // POST: despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var despesas = await _context.Despesas.FindAsync(id);
            _context.Despesas.Remove(despesas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool despesasExists(int id)
        {
            return _context.Despesas.Any(e => e.DespID == id);
        }
    }
}
