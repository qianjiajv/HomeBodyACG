using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeBodyACG.Data;
using HomeBodyACG.Models;

namespace HomeBodyACG.Controllers
{
    public class AnimationsController : Controller
    {
        private readonly HomeBodyACGContext _context;

        public AnimationsController(HomeBodyACGContext context)
        {
            _context = context;
        }

        // GET: Animations
        public async Task<IActionResult> Index(string searchString)
        {
            var animations = from m in _context.Animations
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                animations = animations.Where(s => s.Title.Contains(searchString));
            }

            return View(await animations.ToListAsync());
        }

        // GET: Animations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animations = await _context.Animations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animations == null)
            {
                return NotFound();
            }

            return View(animations);
        }

        // GET: Animations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Magnet")] Animations animations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animations);
        }

        // GET: Animations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animations = await _context.Animations.FindAsync(id);
            if (animations == null)
            {
                return NotFound();
            }
            return View(animations);
        }

        // POST: Animations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Magnet")] Animations animations)
        {
            if (id != animations.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimationsExists(animations.ID))
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
            return View(animations);
        }

        // GET: Animations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animations = await _context.Animations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (animations == null)
            {
                return NotFound();
            }

            return View(animations);
        }

        // POST: Animations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animations = await _context.Animations.FindAsync(id);
            _context.Animations.Remove(animations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimationsExists(int id)
        {
            return _context.Animations.Any(e => e.ID == id);
        }
    }
}
