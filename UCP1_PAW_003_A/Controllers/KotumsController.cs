using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_003_A.Models;

namespace UCP1_PAW_003_A.Controllers
{
    public class KotumsController : Controller
    {
        private readonly Travel1Context _context;

        public KotumsController(Travel1Context context)
        {
            _context = context;
        }

        // GET: Kotums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kota.ToListAsync());
        }

        // GET: Kotums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotum = await _context.Kota
                .FirstOrDefaultAsync(m => m.IdKotaAsal == id);
            if (kotum == null)
            {
                return NotFound();
            }

            return View(kotum);
        }

        // GET: Kotums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kotums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKotaAsal,IdKotaTujuan,Kota")] Kotum kotum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kotum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kotum);
        }

        // GET: Kotums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotum = await _context.Kota.FindAsync(id);
            if (kotum == null)
            {
                return NotFound();
            }
            return View(kotum);
        }

        // POST: Kotums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKotaAsal,IdKotaTujuan,Kota")] Kotum kotum)
        {
            if (id != kotum.IdKotaAsal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kotum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KotumExists(kotum.IdKotaAsal))
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
            return View(kotum);
        }

        // GET: Kotums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kotum = await _context.Kota
                .FirstOrDefaultAsync(m => m.IdKotaAsal == id);
            if (kotum == null)
            {
                return NotFound();
            }

            return View(kotum);
        }

        // POST: Kotums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kotum = await _context.Kota.FindAsync(id);
            _context.Kota.Remove(kotum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KotumExists(int id)
        {
            return _context.Kota.Any(e => e.IdKotaAsal == id);
        }
    }
}
