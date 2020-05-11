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

    [Authorize(Roles = "User,Admin,Operator")]


    public class financeiroesController : Controller
    {
        private readonly FinanceiroContext _context;

        public financeiroesController(FinanceiroContext context)
        {
            _context = context;
        }

        // GET: financeiroes
        public async Task<IActionResult> Index(string searchString)
        {
            var nome = from m in _context.Financeiro select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                nome = nome.Where(s => s.UserName.Contains(searchString));
            }

            return View(await nome.ToListAsync());
        }

        // GET: financeiroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .FirstOrDefaultAsync(m => m.FinancID == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // GET: financeiroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: financeiroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Medico,valor,ReleaseDate,Convenio,Desconto")] financeiro financeiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financeiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financeiro);
        }

        // GET: financeiroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro.FindAsync(id);
            if (financeiro == null)
            {
                return NotFound();
            }
            return View(financeiro);
        }

        // POST: financeiroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Medico,valor,ReleaseDate,Convenio,Desconto")] financeiro financeiro)
        {
            if (id != financeiro.FinancID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!financeiroExists(financeiro.FinancID))
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
            return View(financeiro);
        }

        // GET: financeiroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financeiro = await _context.Financeiro
                .FirstOrDefaultAsync(m => m.FinancID == id);
            if (financeiro == null)
            {
                return NotFound();
            }

            return View(financeiro);
        }

        // POST: financeiroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financeiro = await _context.Financeiro.FindAsync(id);
            _context.Financeiro.Remove(financeiro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool financeiroExists(int id)
        {
            return _context.Financeiro.Any(e => e.FinancID == id);
        }
    }
}
