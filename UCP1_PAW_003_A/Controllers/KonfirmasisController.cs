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
    public class KonfirmasisController : Controller
    {
        private readonly Travel1Context _context;

        public KonfirmasisController(Travel1Context context)
        {
            _context = context;
        }

        // GET: Konfirmasis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Konfirmasis.ToListAsync());
        }

        // GET: Konfirmasis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konfirmasi = await _context.Konfirmasis
                .FirstOrDefaultAsync(m => m.IdPesan == id);
            if (konfirmasi == null)
            {
                return NotFound();
            }

            return View(konfirmasi);
        }

        // GET: Konfirmasis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konfirmasis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPesan,Nama,Jumlah")] Konfirmasi konfirmasi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konfirmasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konfirmasi);
        }

        // GET: Konfirmasis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konfirmasi = await _context.Konfirmasis.FindAsync(id);
            if (konfirmasi == null)
            {
                return NotFound();
            }
            return View(konfirmasi);
        }

        // POST: Konfirmasis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPesan,Nama,Jumlah")] Konfirmasi konfirmasi)
        {
            if (id != konfirmasi.IdPesan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konfirmasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonfirmasiExists(konfirmasi.IdPesan))
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
            return View(konfirmasi);
        }

        // GET: Konfirmasis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konfirmasi = await _context.Konfirmasis
                .FirstOrDefaultAsync(m => m.IdPesan == id);
            if (konfirmasi == null)
            {
                return NotFound();
            }

            return View(konfirmasi);
        }

        // POST: Konfirmasis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var konfirmasi = await _context.Konfirmasis.FindAsync(id);
            _context.Konfirmasis.Remove(konfirmasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonfirmasiExists(int id)
        {
            return _context.Konfirmasis.Any(e => e.IdPesan == id);
        }
    }
}
