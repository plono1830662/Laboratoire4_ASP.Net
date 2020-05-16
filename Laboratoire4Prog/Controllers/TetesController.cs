using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laboratoire4Prog.Models;

namespace Laboratoire4Prog.Controllers
{
    public class TetesController : Controller
    {
        private readonly Laboratoire4ProgContext _context;

        public TetesController(Laboratoire4ProgContext context)
        {
            _context = context;
        }

        // GET: Tetes
       

        // GET: Tetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetes = await _context.Tetes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tetes == null)
            {
                return NotFound();
            }

            return View(tetes);
        }

        // GET: Tetes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tetes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descript,HeureTete,Type,Comment")] Tetes tetes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tetes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tetes);
        }

        // GET: Tetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetes = await _context.Tetes.SingleOrDefaultAsync(m => m.Id == id);
            if (tetes == null)
            {
                return NotFound();
            }
            return View(tetes);
        }

        // POST: Tetes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descript,HeureTete,Type,Comment")] Tetes tetes)
        {
            if (id != tetes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tetes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TetesExists(tetes.Id))
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
            return View(tetes);
        }

        // GET: Tetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetes = await _context.Tetes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tetes == null)
            {
                return NotFound();
            }

            return View(tetes);
        }

        // POST: Tetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tetes = await _context.Tetes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Tetes.Remove(tetes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index(string typeTete, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from t in _context.Tetes
                                            orderby t.Type
                                            select t.Type;

            var tetes = from t in _context.Tetes
                         select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                tetes = tetes.Where(s => s.Descript.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(typeTete))
            {
                tetes = tetes.Where(x => x.Type == typeTete);
            }

            var typeTeteVM = new TeteTypeViewModel
            {
                Types = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Tetes = await tetes.ToListAsync()
            };

            return View(typeTeteVM);
        }
        private bool TetesExists(int id)
        {
            return _context.Tetes.Any(e => e.Id == id);
        }
    }
}
