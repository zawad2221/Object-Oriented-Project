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
    public class MedicineFormsController : Controller
    {
        private readonly AppDbContext _context;

        public MedicineFormsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MedicineForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicineForm.ToListAsync());
        }

        // GET: MedicineForms/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineForm = await _context.MedicineForm
                .FirstOrDefaultAsync(m => m.medicineFormId == id);
            if (medicineForm == null)
            {
                return NotFound();
            }

            return View(medicineForm);
        }

        // GET: MedicineForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicineForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("medicineFormId,medicineFormName")] MedicineForm medicineForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicineForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicineForm);
        }

        // GET: MedicineForms/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineForm = await _context.MedicineForm.FindAsync(id);
            if (medicineForm == null)
            {
                return NotFound();
            }
            return View(medicineForm);
        }

        // POST: MedicineForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("medicineFormId,medicineFormName")] MedicineForm medicineForm)
        {
            if (id != medicineForm.medicineFormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicineForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicineFormExists(medicineForm.medicineFormId))
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
            return View(medicineForm);
        }

        // GET: MedicineForms/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicineForm = await _context.MedicineForm
                .FirstOrDefaultAsync(m => m.medicineFormId == id);
            if (medicineForm == null)
            {
                return NotFound();
            }

            return View(medicineForm);
        }

        // POST: MedicineForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var medicineForm = await _context.MedicineForm.FindAsync(id);
            _context.MedicineForm.Remove(medicineForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicineFormExists(string id)
        {
            return _context.MedicineForm.Any(e => e.medicineFormId == id);
        }
    }
}
