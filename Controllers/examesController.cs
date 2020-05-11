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
    [Authorize(Roles = "User,Admin")]


    public class examesController : Controller
    {
        private readonly ExamesContext _context;

        public examesController(ExamesContext context)
        {
            _context = context;
        }

        // GET: exames
        public async Task<IActionResult> Index(string searchString)
        {
            var nome = from m in _context.Exames select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                nome = nome.Where(s => s.NomePaciente.Contains(searchString));
            }

            return View(await nome.ToListAsync());
        }

        // GET: exames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exames = await _context.Exames
                .FirstOrDefaultAsync(m => m.ExameID == id);
            if (exames == null)
            {
                return NotFound();
            }

            return View(exames);
        }

        // GET: exames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: exames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExameName,NomeMedico,NomePaciente,ReleaseDate,Hora")] exames exames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exames);
        }

        // GET: exames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exames = await _context.Exames.FindAsync(id);
            if (exames == null)
            {
                return NotFound();
            }
            return View(exames);
        }

        // POST: exames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExameName,NomeMedico,NomePaciente,ReleaseDate,Hora")] exames exames)
        {
            if (id != exames.ExameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!examesExists(exames.ExameID))
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
            return View(exames);
        }

        // GET: exames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exames = await _context.Exames
                .FirstOrDefaultAsync(m => m.ExameID == id);
            if (exames == null)
            {
                return NotFound();
            }

            return View(exames);
        }

        // POST: exames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exames = await _context.Exames.FindAsync(id);
            _context.Exames.Remove(exames);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool examesExists(int id)
        {
            return _context.Exames.Any(e => e.ExameID == id);
        }
    }
}
