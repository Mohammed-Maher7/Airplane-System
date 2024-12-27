using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirplaneMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneMVC.Controllers
{
    public class CrewsController : Controller
    {
        private readonly AirplaneContext _context;

        public CrewsController(AirplaneContext context)
        {
            _context = context;
        }

        // GET: Crews
        public async Task<IActionResult> Index()
        {
            var crews = _context.Crew.Include(c => c.Aircraft);
            return View(await crews.ToListAsync());
        }

        // GET: Crews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew
                .Include(c => c.Aircraft)
                .FirstOrDefaultAsync(m => m.CrewID == id);

            if (crew == null)
            {
                return NotFound();
            }

            return View(crew);
        }

        // GET: Crews/Create
        public IActionResult Create()
        {
            ViewData["AircraftID"] = new SelectList(_context.Aircraft, "AircraftID", "Model");
            return View();
        }

        // POST: Crews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Crew crew)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crew);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AircraftID"] = new SelectList(_context.Aircraft, "AircraftID", "Model", crew.AircraftID);
            return View(crew);
        }

        // GET: Crews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew.FindAsync(id);
            if (crew == null)
            {
                return NotFound();
            }
            ViewData["AircraftID"] = new SelectList(_context.Aircraft, "AircraftID", "Model", crew.AircraftID);
            return View(crew);
        }

        // POST: Crews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Crew crew)
        {
            if (id != crew.CrewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crew);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrewExists(crew.CrewID))
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
            ViewData["AircraftID"] = new SelectList(_context.Aircraft, "AircraftID", "Model", crew.AircraftID);
            return View(crew);
        }

        // GET: Crews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crew = await _context.Crew
                .Include(c => c.Aircraft)
                .FirstOrDefaultAsync(m => m.CrewID == id);
            if (crew == null)
            {
                return NotFound();
            }

            return View(crew);
        }

        // POST: Crews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crew = await _context.Crew.FindAsync(id);
            if (crew != null)
            {
                _context.Crew.Remove(crew);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CrewExists(int id)
        {
            return _context.Crew.Any(e => e.CrewID == id);
        }
    }
}