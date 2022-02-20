#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AAOTripBooker.Data;
using AAOTripBooker.Models;

namespace AAOTripBooker.Controllers
{
    public class DriverPeriodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriverPeriodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DriverPeriods
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DriverPeriods.Include(d => d.Driver);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DriverPeriods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverPeriod = await _context.DriverPeriods
                .Include(d => d.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverPeriod == null)
            {
                return NotFound();
            }

            return View(driverPeriod);
        }

        // GET: DriverPeriods/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "DriversLicense");
            return View();
        }

        // POST: DriverPeriods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DriverStartDate,DriverEndDate,DriverStartTime,DriverId")] DriverPeriod driverPeriod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverPeriod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "DriversLicense", driverPeriod.DriverId);
            return View(driverPeriod);
        }

        // GET: DriverPeriods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverPeriod = await _context.DriverPeriods.FindAsync(id);
            if (driverPeriod == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "DriversLicense", driverPeriod.DriverId);
            return View(driverPeriod);
        }

        // POST: DriverPeriods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DriverStartDate,DriverEndDate,DriverStartTime,DriverId")] DriverPeriod driverPeriod)
        {
            if (id != driverPeriod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverPeriod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverPeriodExists(driverPeriod.Id))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "DriversLicense", driverPeriod.DriverId);
            return View(driverPeriod);
        }

        // GET: DriverPeriods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverPeriod = await _context.DriverPeriods
                .Include(d => d.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverPeriod == null)
            {
                return NotFound();
            }

            return View(driverPeriod);
        }

        // POST: DriverPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driverPeriod = await _context.DriverPeriods.FindAsync(id);
            _context.DriverPeriods.Remove(driverPeriod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverPeriodExists(int id)
        {
            return _context.DriverPeriods.Any(e => e.Id == id);
        }
    }
}
