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
    public class DriverTripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DriverTripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DriverTrips
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DriverTrips.Include(d => d.Driver).Include(d => d.Trip);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DriverTrips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverTrip = await _context.DriverTrips
                .Include(d => d.Driver)
                .Include(d => d.Trip)
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driverTrip == null)
            {
                return NotFound();
            }

            return View(driverTrip);
        }

        // GET: DriverTrips/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "DriversLicense");
            ViewData["TripId"] = new SelectList(_context.Trips, "Id", "Id");
            return View();
        }

        // POST: DriverTrips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,TripId")] DriverTrip driverTrip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "DriversLicense", driverTrip.DriverId);
            ViewData["TripId"] = new SelectList(_context.Trips, "Id", "Id", driverTrip.TripId);
            return View(driverTrip);
        }

        // GET: DriverTrips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driverTrip = await _context.DriverTrips.FindAsync(id);
            if (driverTrip == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "DriversLicense", driverTrip.DriverId);
            ViewData["TripId"] = new SelectList(_context.Trips, "Id", "Id", driverTrip.TripId);
            return View(driverTrip);
        }

        // POST: DriverTrips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverId,TripId")] DriverTrip driverTrip)
        {
            if (id != driverTrip.DriverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverTrip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverTripExists(driverTrip.DriverId))
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
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "DriversLicense", driverTrip.DriverId);
            ViewData["TripId"] = new SelectList(_context.Trips, "Id", "Id", driverTrip.TripId);
            return View(driverTrip);
        }

        // GET: DriverTrips/Delete/5
        public async Task<IActionResult> Delete(int? driverid, int? tripid)
        {
            if (driverid == null)
            {
                return NotFound();
            }

            if (tripid == null)
            {
                return NotFound();
            }

            var driverTrip = await _context.DriverTrips.Where(x => x.DriverId == driverid).Where(x => x.TripId == tripid).FirstOrDefaultAsync();
            if (driverTrip == null)
            {
                return NotFound();
            }

            return View(driverTrip);
        }

        // POST: DriverTrips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int DriverId, int TripId)
        {
            var driverTrip = await _context.DriverTrips.Where(x => x.DriverId == DriverId).Where(x => x.TripId == TripId).FirstOrDefaultAsync();
            _context.DriverTrips.Remove(driverTrip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverTripExists(int id)
        {
            return _context.DriverTrips.Any(e => e.DriverId == id);
        }
    }
}
