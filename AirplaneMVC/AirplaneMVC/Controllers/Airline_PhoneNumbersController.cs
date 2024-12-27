using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirplaneMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneMVC.Controllers
{
    public class Airline_PhoneNumbersController : Controller
    {
        private readonly AirplaneContext _context;

        public Airline_PhoneNumbersController(AirplaneContext context)
        {
            _context = context;
        }

        // GET: Airline_PhoneNumbers
        public async Task<IActionResult> Index()
        {
            var phoneNumbers = _context.Airline_PhoneNumbers
                .Include(p => p.Airline)
                .ToListAsync();
            return View(await phoneNumbers);
        }

        // GET: Airline_PhoneNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumber = await _context.Airline_PhoneNumbers
                .Include(p => p.Airline)
                .FirstOrDefaultAsync(m => m.PhoneNumberID == id);

            if (phoneNumber == null)
            {
                return NotFound();
            }

            return View(phoneNumber);
        }

        // GET: Airline_PhoneNumbers/Create
        public IActionResult Create()
        {
            ViewBag.AirlineID = new SelectList(_context.Airline, "AirlineID", "Name");
            return View();
        }

        // POST: Airline_PhoneNumbers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Airline_PhoneNumbers phoneNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AirlineID = new SelectList(_context.Airline, "AirlineID", "Name", phoneNumber.AirlineID);
            return View(phoneNumber);
        }

        // GET: Airline_PhoneNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumber = await _context.Airline_PhoneNumbers.FindAsync(id);
            if (phoneNumber == null)
            {
                return NotFound();
            }
            ViewBag.AirlineID = new SelectList(_context.Airline, "AirlineID", "Name", phoneNumber.AirlineID);
            return View(phoneNumber);
        }

        // POST: Airline_PhoneNumbers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Airline_PhoneNumbers phoneNumber)
        {
            if (id != phoneNumber.PhoneNumberID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneNumberExists(phoneNumber.PhoneNumberID))
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
            ViewBag.AirlineID = new SelectList(_context.Airline, "AirlineID", "Name", phoneNumber.AirlineID);
            return View(phoneNumber);
        }

        // GET: Airline_PhoneNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumber = await _context.Airline_PhoneNumbers
                .Include(p => p.Airline)
                .FirstOrDefaultAsync(m => m.PhoneNumberID == id);
            if (phoneNumber == null)
            {
                return NotFound();
            }

            return View(phoneNumber);
        }

        // POST: Airline_PhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneNumber = await _context.Airline_PhoneNumbers.FindAsync(id);
            if (phoneNumber != null)
            {
                _context.Airline_PhoneNumbers.Remove(phoneNumber);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneNumberExists(int id)
        {
            return _context.Airline_PhoneNumbers.Any(e => e.PhoneNumberID == id);
        }
    }
}