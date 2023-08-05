using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRecord.Contexts;
using StudentRecord.Entities;

namespace StudentRecord.Controllers
{
    public class StudentTablesController : Controller
    {
        private readonly StudentListDbContext _context;

        public StudentTablesController(StudentListDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.StudentTables != null ? 
                          View(await _context.StudentTables.ToListAsync()) :
                          Problem("Entity set 'StudentListDbContext.StudentTables'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentTable == null)
            {
                return NotFound();
            }

            return View(studentTable);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentSurname,StudentMail,StudentImage,StudentAddress")] StudentTable studentTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTable);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables.FindAsync(id);
            if (studentTable == null)
            {
                return NotFound();
            }
            return View(studentTable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentSurname,StudentMail,StudentImage,StudentAddress")] StudentTable studentTable)
        {
            if (id != studentTable.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTableExists(studentTable.StudentId))
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
            return View(studentTable);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentTables == null)
            {
                return NotFound();
            }

            var studentTable = await _context.StudentTables
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentTable == null)
            {
                return NotFound();
            }

            return View(studentTable);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentTables == null)
            {
                return Problem("Entity set 'StudentListDbContext.StudentTables'  is null.");
            }
            var studentTable = await _context.StudentTables.FindAsync(id);
            if (studentTable != null)
            {
                _context.StudentTables.Remove(studentTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTableExists(int id)
        {
          return (_context.StudentTables?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
