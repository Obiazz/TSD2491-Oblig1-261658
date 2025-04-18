using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oblig1_261658.Data;
using Oblig1_261658.Models;

namespace Oblig1_261658.Controllers
{
    public class BrukerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrukerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bruker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bruker.ToListAsync());
        }

        // GET: Bruker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruker = await _context.Bruker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bruker == null)
            {
                return NotFound();
            }

            return View(bruker);
        }

        // GET: Bruker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bruker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Navn,KontaktInfo,AntallSpill")] Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bruker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bruker);
        }

        // GET: Bruker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruker = await _context.Bruker.FindAsync(id);
            if (bruker == null)
            {
                return NotFound();
            }
            return View(bruker);
        }

        // POST: Bruker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Navn,KontaktInfo,AntallSpill")] Bruker bruker)
        {
            if (id != bruker.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bruker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrukerExists(bruker.ID))
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
            return View(bruker);
        }

        // GET: Bruker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruker = await _context.Bruker
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bruker == null)
            {
                return NotFound();
            }

            return View(bruker);
        }

        // POST: Bruker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bruker = await _context.Bruker.FindAsync(id);
            if (bruker != null)
            {
                _context.Bruker.Remove(bruker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        [Route("Bruker/FullforSpillMedId")]
        public async Task<IActionResult> FullforSpillMedId(int id)
        {
            var bruker = await _context.Bruker.FirstOrDefaultAsync(b => b.ID == id);
            if (bruker == null)
            {
                return NotFound();
            }

        bruker.AntallSpill += 1;
        await _context.SaveChangesAsync();

        return Ok(); // Returner HTTP 200 OK
}
    

        private bool BrukerExists(int id)
        {
            return _context.Bruker.Any(e => e.ID == id);
        }
    }
}
