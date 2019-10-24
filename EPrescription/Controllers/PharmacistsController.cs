using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPrescription.Models;

namespace EPrescription.Controllers
{
    public class PharmacistsController : Controller
    {
        private readonly AppDbContext _context;

        public PharmacistsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pharmacists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pharmacists.ToListAsync());
        }

        // GET: Pharmacists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacist = await _context.Pharmacists
                .FirstOrDefaultAsync(m => m.pharmacistId == id);
            if (pharmacist == null)
            {
                return NotFound();
            }

            return View(pharmacist);
        }

        // GET: Pharmacists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pharmacists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pharmacistId,storeName,drugeLicence,pharmacistPhoneNumber,storeAddress,pharmacistPassword")] Pharmacist pharmacist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmacist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacist);
        }

        // GET: Pharmacists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacist = await _context.Pharmacists.FindAsync(id);
            if (pharmacist == null)
            {
                return NotFound();
            }
            return View(pharmacist);
        }

        // POST: Pharmacists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("pharmacistId,storeName,drugeLicence,pharmacistPhoneNumber,storeAddress,pharmacistPassword")] Pharmacist pharmacist)
        {
            if (id != pharmacist.pharmacistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmacist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmacistExists(pharmacist.pharmacistId))
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
            return View(pharmacist);
        }

        // GET: Pharmacists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacist = await _context.Pharmacists
                .FirstOrDefaultAsync(m => m.pharmacistId == id);
            if (pharmacist == null)
            {
                return NotFound();
            }

            return View(pharmacist);
        }

        // POST: Pharmacists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);
            _context.Pharmacists.Remove(pharmacist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmacistExists(string id)
        {
            return _context.Pharmacists.Any(e => e.pharmacistId == id);
        }
    }
}
