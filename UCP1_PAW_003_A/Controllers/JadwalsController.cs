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
    public class JadwalsController : Controller
    {
        private readonly Travel1Context _context;

        public JadwalsController(Travel1Context context)
        {
            _context = context;
        }

        // GET: Jadwals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jadwals.ToListAsync());
            
        }

        // GET: Jadwals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jadwal = await _context.Jadwals
                .FirstOrDefaultAsync(m => m.IdKotaAsal == id);
            if (jadwal == null)
            {
                return NotFound();
            }

            return View(jadwal);
        }

        // GET: Jadwals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jadwals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKotaAsal,IdKotaTujuan,Biaya,JamBerangkat")] Jadwal jadwal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jadwal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jadwal);
        }

        // GET: Jadwals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jadwal = await _context.Jadwals.FindAsync(id);
            if (jadwal == null)
            {
                return NotFound();
            }
            return View(jadwal);
        }

        // POST: Jadwals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKotaAsal,IdKotaTujuan,Biaya,JamBerangkat")] Jadwal jadwal)
        {
            if (id != jadwal.IdKotaAsal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jadwal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JadwalExists(jadwal.IdKotaAsal))
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
            return View(jadwal);
        }

        // GET: Jadwals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jadwal = await _context.Jadwals
                .FirstOrDefaultAsync(m => m.IdKotaAsal == id);
            if (jadwal == null)
            {
                return NotFound();
            }

            return View(jadwal);
        }

        // POST: Jadwals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jadwal = await _context.Jadwals.FindAsync(id);
            _context.Jadwals.Remove(jadwal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JadwalExists(int id)
        {
            return _context.Jadwals.Any(e => e.IdKotaAsal == id);
        }
    }
}
