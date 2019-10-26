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
    public class MedicinesController : Controller
    {
        private readonly AppDbContext _context;

        public MedicinesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Medicines
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Medicine.Include(m => m.Company).Include(m => m.MedicineForm).Include(m => m.MedicineType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Medicines/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicine
                .Include(m => m.Company)
                .Include(m => m.MedicineForm)
                .Include(m => m.MedicineType)
                .FirstOrDefaultAsync(m => m.medicineId == id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            ViewData["companyId"] = new SelectList(_context.Companies, "companyId", "companyId");
            ViewData["medicineFormId"] = new SelectList(_context.MedicineForm, "medicineFormId", "medicineFormId");
            ViewData["medicineTypeId"] = new SelectList(_context.MedicineType, "medicineTypeId", "medicineTypeId");
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("medicineId,medicineName,medicineSingleUniteQuantity,medicineFormId,medicineTypeId,companyId")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["companyId"] = new SelectList(_context.Companies, "companyId", "companyId", medicine.companyId);
            ViewData["medicineFormId"] = new SelectList(_context.MedicineForm, "medicineFormId", "medicineFormId", medicine.medicineFormId);
            ViewData["medicineTypeId"] = new SelectList(_context.MedicineType, "medicineTypeId", "medicineTypeId", medicine.medicineTypeId);
            return View(medicine);
        }

        // GET: Medicines/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicine.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            ViewData["companyId"] = new SelectList(_context.Companies, "companyId", "companyId", medicine.companyId);
            ViewData["medicineFormId"] = new SelectList(_context.MedicineForm, "medicineFormId", "medicineFormId", medicine.medicineFormId);
            ViewData["medicineTypeId"] = new SelectList(_context.MedicineType, "medicineTypeId", "medicineTypeId", medicine.medicineTypeId);
            return View(medicine);
        }

        // POST: Medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("medicineId,medicineName,medicineSingleUniteQuantity,medicineFormId,medicineTypeId,companyId")] Medicine medicine)
        {
            if (id != medicine.medicineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineExists(medicine.medicineId))
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
            ViewData["companyId"] = new SelectList(_context.Companies, "companyId", "companyId", medicine.companyId);
            ViewData["medicineFormId"] = new SelectList(_context.MedicineForm, "medicineFormId", "medicineFormId", medicine.medicineFormId);
            ViewData["medicineTypeId"] = new SelectList(_context.MedicineType, "medicineTypeId", "medicineTypeId", medicine.medicineTypeId);
            return View(medicine);
        }

        // GET: Medicines/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicine = await _context.Medicine
                .Include(m => m.Company)
                .Include(m => m.MedicineForm)
                .Include(m => m.MedicineType)
                .FirstOrDefaultAsync(m => m.medicineId == id);
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // POST: Medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medicine = await _context.Medicine.FindAsync(id);
            _context.Medicine.Remove(medicine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineExists(string id)
        {
            return _context.Medicine.Any(e => e.medicineId == id);
        }
    }
}
