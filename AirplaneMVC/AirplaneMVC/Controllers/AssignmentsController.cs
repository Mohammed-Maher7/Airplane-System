using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirplaneMVC.Models;
using System.Linq;
using System.Threading.Tasks;

// Namespace alias to resolve ambiguity
using RouteModel = AirplaneMVC.Models.Route;

namespace AirplaneMVC.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AirplaneContext _context;

        public AssignmentsController(AirplaneContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            var assignments = _context.Assignment
                .Include(a => a.Aircraft)
                .Include(a => a.Route)
                .ToListAsync();
            return View(await assignments);
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .Include(a => a.Aircraft)
                .Include(a => a.Route)
                .FirstOrDefaultAsync(m => m.AssignmentID == id);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public IActionResult Create()
        {
            ViewData["AircraftID"] = new SelectList(_context.Aircraft, "AircraftID", "Model");
            ViewData["RouteID"] = new SelectList(
                _context.Route.Select(r => new
                {
                    RouteID = r.RouteID,
                    OriginDestination = r.Origin + " - " + r.Destination
                }), "RouteID", "OriginDestination");

            return View();
        }

        // POST: Assignments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AircraftID"] = new SelectList(_context.Aircraft, "AircraftID", "Model", assignment.AircraftID);
            ViewData["RouteID"] = new SelectList(
                _context.Route.Select(r => new
                {
                    RouteID = r.RouteID,
                    OriginDestination = r.Origin + " - " + r.Destination
                }), "RouteID", "OriginDestination", assignment.RouteID);

            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["AircraftID"] = new SelectList(_context.Aircraft, "AircraftID", "Model", assignment.AircraftID);
            ViewData["RouteID"] = new SelectList(
                _context.Route.Select(r => new
                {
                    RouteID = r.RouteID,
                    OriginDestination = r.Origin + " - " + r.Destination
                }), "RouteID", "OriginDestination", assignment.RouteID);

            return View(assignment);
        }

        // POST: Assignments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Assignment assignment)
        {
            if (id != assignment.AssignmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentID))
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
            ViewData["AircraftID"] = new SelectList(_context.Aircraft, "AircraftID", "Model", assignment.AircraftID);
            ViewData["RouteID"] = new SelectList(
                _context.Route.Select(r => new
                {
                    RouteID = r.RouteID,
                    OriginDestination = r.Origin + " - " + r.Destination
                }), "RouteID", "OriginDestination", assignment.RouteID);

            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignment
                .Include(a => a.Aircraft)
                .Include(a => a.Route)
                .FirstOrDefaultAsync(m => m.AssignmentID == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignment.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignment.Remove(assignment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignment.Any(e => e.AssignmentID == id);
        }
    }
}