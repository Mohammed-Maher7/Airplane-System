using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirplaneMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneMVC.Controllers
{
    public class AirlinesController : Controller
    {
        private readonly AirplaneContext _context;

        public AirlinesController(AirplaneContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
            var airlines = await _context.Airline.ToListAsync();
            return View(airlines);
        }

        // GET: Airlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .Include(a => a.PhoneNumbers)
                .Include(a => a.Employees)
                .Include(a => a.Aircrafts)
                .FirstOrDefaultAsync(m => m.AirlineID == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // GET: Airlines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirlineID,Name,Address,ContactName")] Airline airline)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airline);
        }

        // GET: Airlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AirlineID,Name,Address,ContactName")] Airline airline)
        {
            if (id != airline.AirlineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineExists(airline.AirlineID))
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
            return View(airline);
        }

        // GET: Airlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airline
                .FirstOrDefaultAsync(m => m.AirlineID == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airline = await _context.Airline.FindAsync(id);
            if (airline != null)
            {
                _context.Airline.Remove(airline);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(int id)
        {
            return _context.Airline.Any(e => e.AirlineID == id);
        }
    }
}