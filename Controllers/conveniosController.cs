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
   
  
    public class conveniosController : Controller
    {
        private readonly ConveniosContext _context;

        public conveniosController(ConveniosContext context)
        {
            _context = context;
        }

        // GET: convenios
        public async Task<IActionResult> Index(string searchString)
        {
            var nome = from m in _context.Convenios select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                nome = nome.Where(s => s.Empresa.Contains(searchString));
            }

            return View(await nome.ToListAsync());
        }

        // GET: convenios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenios = await _context.Convenios
                .FirstOrDefaultAsync(m => m.ConvID == id);
            if (convenios == null)
            {
                return NotFound();
            }

            return View(convenios);
        }

        // GET: convenios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: convenios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,Email,PhoneNumber,CNPJ,desconto")] convenios convenios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convenios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(convenios);
        }

        // GET: convenios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenios = await _context.Convenios.FindAsync(id);
            if (convenios == null)
            {
                return NotFound();
            }
            return View(convenios);
        }

        // POST: convenios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,Email,PhoneNumber,CNPJ,desconto")] convenios convenios)
        {
            if (id != convenios.ConvID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convenios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!conveniosExists(convenios.ConvID))
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
            return View(convenios);
        }

        // GET: convenios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convenios = await _context.Convenios
                .FirstOrDefaultAsync(m => m.ConvID == id);
            if (convenios == null)
            {
                return NotFound();
            }

            return View(convenios);
        }

        // POST: convenios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convenios = await _context.Convenios.FindAsync(id);
            _context.Convenios.Remove(convenios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool conveniosExists(int id)
        {
            return _context.Convenios.Any(e => e.ConvID == id);
        }
    }
}
