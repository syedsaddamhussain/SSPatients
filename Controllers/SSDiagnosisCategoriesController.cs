﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSPatients.Models;

namespace SSPatients.Controllers
{
    public class SSDiagnosisCategoriesController : Controller
    {
        private readonly PatientsContext _context;

        public SSDiagnosisCategoriesController(PatientsContext context)
        {
            _context = context;
        }

        // GET: SSDiagnosisCategories
        public async Task<IActionResult> Index()
        {
              return View(await _context.DiagnosisCategories.ToListAsync());
        }

        // GET: SSDiagnosisCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DiagnosisCategories == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }

            return View(diagnosisCategory);
        }

        // GET: SSDiagnosisCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SSDiagnosisCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DiagnosisCategory diagnosisCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnosisCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diagnosisCategory);
        }

        // GET: SSDiagnosisCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DiagnosisCategories == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategories.FindAsync(id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }
            return View(diagnosisCategory);
        }

        // POST: SSDiagnosisCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DiagnosisCategory diagnosisCategory)
        {
            if (id != diagnosisCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnosisCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosisCategoryExists(diagnosisCategory.Id))
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
            return View(diagnosisCategory);
        }

        // GET: SSDiagnosisCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DiagnosisCategories == null)
            {
                return NotFound();
            }

            var diagnosisCategory = await _context.DiagnosisCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diagnosisCategory == null)
            {
                return NotFound();
            }

            return View(diagnosisCategory);
        }

        // POST: SSDiagnosisCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DiagnosisCategories == null)
            {
                return Problem("Entity set 'PatientsContext.DiagnosisCategories'  is null.");
            }
            var diagnosisCategory = await _context.DiagnosisCategories.FindAsync(id);
            if (diagnosisCategory != null)
            {
                _context.DiagnosisCategories.Remove(diagnosisCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiagnosisCategoryExists(int id)
        {
          return _context.DiagnosisCategories.Any(e => e.Id == id);
        }
    }
}
