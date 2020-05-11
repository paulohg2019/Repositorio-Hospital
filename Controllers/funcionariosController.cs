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

    public class funcionariosController : Controller
    {
        private readonly FuncionariosContext _context;

        public funcionariosController(FuncionariosContext context)
        {
            _context = context;
        }

        // GET: funcionarios
        public async Task<IActionResult> Index(string searchString)
        {
            var nome = from m in _context.Funcionarios select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                nome = nome.Where(s => s.UserName.Contains(searchString));
            }

            return View(await nome.ToListAsync());
        }

        // GET: funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.FuncID == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // GET: funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,CPF,Entrada,Funcao,Turno,Salario")] funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionarios);
        }

        // GET: funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios.FindAsync(id);
            if (funcionarios == null)
            {
                return NotFound();
            }
            return View(funcionarios);
        }

        // POST: funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,CPF,Entrada,Funcao,Turno,Salario")] funcionarios funcionarios)
        {
            if (id != funcionarios.FuncID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!funcionariosExists(funcionarios.FuncID))
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
            return View(funcionarios);
        }

        // GET: funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.FuncID == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // POST: funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarios = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool funcionariosExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncID == id);
        }
    }
}
