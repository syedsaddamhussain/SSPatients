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
    public class SSConcentrationUnitsController : Controller
    {
        private readonly PatientsContext _context;

        public SSConcentrationUnitsController(PatientsContext context)
        {
            _context = context;
        }

        // GET: SSConcentrationUnits
        //This function gives the list of countries
        public async Task<IActionResult> Index()
        {
              return View(await _context.ConcentrationUnits.ToListAsync());
        }

        // GET: SSConcentrationUnits/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ConcentrationUnits == null)
            {
                return NotFound();
            }

            var concentrationUnit = await _context.ConcentrationUnits
                .FirstOrDefaultAsync(m => m.ConcentrationCode == id);
            if (concentrationUnit == null)
            {
                return NotFound();
            }

            return View(concentrationUnit);
        }

        // GET: SSConcentrationUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SSConcentrationUnits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcentrationCode")] ConcentrationUnit concentrationUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concentrationUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concentrationUnit);
        }

        // GET: SSConcentrationUnits/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ConcentrationUnits == null)
            {
                return NotFound();
            }

            var concentrationUnit = await _context.ConcentrationUnits.FindAsync(id);
            if (concentrationUnit == null)
            {
                return NotFound();
            }
            return View(concentrationUnit);
        }

        // POST: SSConcentrationUnits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ConcentrationCode")] ConcentrationUnit concentrationUnit)
        {
            if (id != concentrationUnit.ConcentrationCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concentrationUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcentrationUnitExists(concentrationUnit.ConcentrationCode))
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
            return View(concentrationUnit);
        }

        // GET: SSConcentrationUnits/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ConcentrationUnits == null)
            {
                return NotFound();
            }

            var concentrationUnit = await _context.ConcentrationUnits
                .FirstOrDefaultAsync(m => m.ConcentrationCode == id);
            if (concentrationUnit == null)
            {
                return NotFound();
            }

            return View(concentrationUnit);
        }

        // POST: SSConcentrationUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ConcentrationUnits == null)
            {
                return Problem("Entity set 'PatientsContext.ConcentrationUnits'  is null.");
            }
            var concentrationUnit = await _context.ConcentrationUnits.FindAsync(id);
            if (concentrationUnit != null)
            {
                _context.ConcentrationUnits.Remove(concentrationUnit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcentrationUnitExists(string id)
        {
          return _context.ConcentrationUnits.Any(e => e.ConcentrationCode == id);
        }
    }
}
