using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirplaneMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneMVC.Controllers
{
    public class AircraftsController : Controller
    {
        private readonly AirplaneContext _context;

        public AircraftsController(AirplaneContext context)
        {
            _context = context;
        }

        // GET: Aircrafts
        public async Task<IActionResult> Index()
        {
            var aircrafts = _context.Aircraft
                .Include(a => a.Airline)
                .ToListAsync();
            return View(await aircrafts);
        }

        // GET: Aircrafts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft
                .Include(a => a.Airline)
                .FirstOrDefaultAsync(m => m.AircraftID == id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // GET: Aircrafts/Create
        public IActionResult Create()
        {
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "Name");
            return View();
        }

        // POST: Aircrafts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aircraft aircraft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aircraft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "Name", aircraft.AirlineID);
            return View(aircraft);
        }

        // GET: Aircrafts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "Name", aircraft.AirlineID);
            return View(aircraft);
        }

        // POST: Aircrafts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aircraft aircraft)
        {
            if (id != aircraft.AircraftID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftExists(aircraft.AircraftID))
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
            ViewData["AirlineID"] = new SelectList(_context.Airline, "AirlineID", "Name", aircraft.AirlineID);
            return View(aircraft);
        }

        // GET: Aircrafts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircraft
                .Include(a => a.Airline)
                .FirstOrDefaultAsync(m => m.AircraftID == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // POST: Aircrafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aircraft = await _context.Aircraft.FindAsync(id);
            if (aircraft != null)
            {
                _context.Aircraft.Remove(aircraft);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftExists(int id)
        {
            return _context.Aircraft.Any(e => e.AircraftID == id);
        }
    }
}