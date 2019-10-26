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
    public class MedicineTypesController : Controller
    {
        private readonly AppDbContext _context;

        public MedicineTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MedicineTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicineType.ToListAsync());
        }

        // GET: MedicineTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = await _context.MedicineType
                .FirstOrDefaultAsync(m => m.medicineTypeId == id);
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        // GET: MedicineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicineTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("medicineTypeId,medicineTypeName")] MedicineType medicineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicineType);
        }

        // GET: MedicineTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = await _context.MedicineType.FindAsync(id);
            if (medicineType == null)
            {
                return NotFound();
            }
            return View(medicineType);
        }

        // POST: MedicineTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("medicineTypeId,medicineTypeName")] MedicineType medicineType)
        {
            if (id != medicineType.medicineTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineTypeExists(medicineType.medicineTypeId))
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
            return View(medicineType);
        }

        // GET: MedicineTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineType = await _context.MedicineType
                .FirstOrDefaultAsync(m => m.medicineTypeId == id);
            if (medicineType == null)
            {
                return NotFound();
            }

            return View(medicineType);
        }

        // POST: MedicineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medicineType = await _context.MedicineType.FindAsync(id);
            _context.MedicineType.Remove(medicineType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineTypeExists(string id)
        {
            return _context.MedicineType.Any(e => e.medicineTypeId == id);
        }
    }
}
