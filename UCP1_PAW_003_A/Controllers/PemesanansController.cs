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
    public class PemesanansController : Controller
    {
        private readonly Travel1Context _context;

        public PemesanansController(Travel1Context context)
        {
            _context = context;
        }

        // GET: Pemesanans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pemesanans.ToListAsync());
        }

        // GET: Pemesanans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanans
                .FirstOrDefaultAsync(m => m.IdPesan == id);
            if (pemesanan == null)
            {
                return NotFound();
            }

            return View(pemesanan);
        }

        // GET: Pemesanans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pemesanans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPesan,TanggalPesan,IdJadwal,JumlahPesan")] Pemesanan pemesanan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pemesanan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pemesanan);
        }

        // GET: Pemesanans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanans.FindAsync(id);
            if (pemesanan == null)
            {
                return NotFound();
            }
            return View(pemesanan);
        }

        // POST: Pemesanans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPesan,TanggalPesan,IdJadwal,JumlahPesan")] Pemesanan pemesanan)
        {
            if (id != pemesanan.IdPesan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pemesanan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PemesananExists(pemesanan.IdPesan))
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
            return View(pemesanan);
        }

        // GET: Pemesanans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemesanan = await _context.Pemesanans
                .FirstOrDefaultAsync(m => m.IdPesan == id);
            if (pemesanan == null)
            {
                return NotFound();
            }

            return View(pemesanan);
        }

        // POST: Pemesanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pemesanan = await _context.Pemesanans.FindAsync(id);
            _context.Pemesanans.Remove(pemesanan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PemesananExists(int id)
        {
            return _context.Pemesanans.Any(e => e.IdPesan == id);
        }
    }
}
