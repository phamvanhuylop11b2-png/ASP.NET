using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day6_Pham_Van_Huy.Models;

public class GenreController : Controller
{
    private readonly Day6_Pham_Van_HuyContext _context;

    public GenreController(Day6_Pham_Van_HuyContext context)
    {
        _context = context;
    }

    // GET: Genre
    public async Task<IActionResult> Index()
    {
        return View(await _context.Genre.ToListAsync());
    }

    // GET: Genre/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Genre/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] Genre genre)
    {
        if (ModelState.IsValid)
        {
            _context.Add(genre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(genre);
    }

    // GET: Genre/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var genre = await _context.Genre.FirstOrDefaultAsync(m => m.Id == id);
        if (genre == null) return NotFound();

        return View(genre);
    }

    // POST: Genre/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var genre = await _context.Genre.FindAsync(id);
        if (genre != null)
        {
            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}

