using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirplaneMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneMVC.Controllers
{
    public class Employee_QualificationsController : Controller
    {
        private readonly AirplaneContext _context;

        public Employee_QualificationsController(AirplaneContext context)
        {
            _context = context;
        }

        // GET: Employee_Qualifications
        public async Task<IActionResult> Index()
        {
            var qualifications = _context.Employee_Qualifications
                .Include(eq => eq.Employee);
            return View(await qualifications.ToListAsync());
        }

        // GET: Employee_Qualifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Employee_Qualifications
                .Include(eq => eq.Employee)
                .FirstOrDefaultAsync(m => m.QualificationID == id);

            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // GET: Employee_Qualifications/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Name");
            return View();
        }

        // POST: Employee_Qualifications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee_Qualifications qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Name", qualification.EmployeeID);
            return View(qualification);
        }

        // GET: Employee_Qualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Employee_Qualifications.FindAsync(id);
            if (qualification == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Name", qualification.EmployeeID);
            return View(qualification);
        }

        // POST: Employee_Qualifications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee_Qualifications qualification)
        {
            if (id != qualification.QualificationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee_QualificationsExists(qualification.QualificationID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Name", qualification.EmployeeID);
            return View(qualification);
        }

        // GET: Employee_Qualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualification = await _context.Employee_Qualifications
                .Include(eq => eq.Employee)
                .FirstOrDefaultAsync(m => m.QualificationID == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // POST: Employee_Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qualification = await _context.Employee_Qualifications.FindAsync(id);
            if (qualification != null)
            {
                _context.Employee_Qualifications.Remove(qualification);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool Employee_QualificationsExists(int id)
        {
            return _context.Employee_Qualifications.Any(e => e.QualificationID == id);
        }
    }
}