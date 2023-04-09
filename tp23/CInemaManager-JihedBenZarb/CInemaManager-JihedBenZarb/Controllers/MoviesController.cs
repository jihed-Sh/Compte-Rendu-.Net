using CInemaManager_JihedBenZarb.Models.Cinema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CInemaManager_JihedBenZarb.Controllers;

public class MoviesController : Controller
{
    // GET
    private readonly MyDbContext _context;

        public MoviesController(MyDbContext context)
        {
            _context = context;
        }

        //requette LINQ Simple Search By 2 GENRE AND TITLE
        public IActionResult SearchBy2(String title ="",String genre="")
        {
            var liste_genre = from m in _context.Movies.Include(m => m.Producer)
                              select m.Genre;
            ViewBag.genre=new SelectList(liste_genre);
        
            var liste = from m in _context.Movies
        
                        where m.Title.Contains(title) && m.Genre.Contains(genre)
                        select m;
        
            return View(liste);
        }
        
        // //requette LINQ Simple Search By Genre
        public IActionResult SearchByGenre(String genre = "")
        {
            var liste = from m in _context.Movies.Include(m => m.Producer)
                        where m.Genre.Contains(genre)
                        select m;
            return View(liste);
        }
        
        // //requette LINQ Simple Search By Title
        public IActionResult SearchByTitle(String title="")
        {
            var liste = from m in _context.Movies.Include(m => m.Producer)
                        where m.Title.Contains(title)
                        select m;
            return View(liste);
        }

        //requette LINQ
        public async Task<IActionResult> MoviesAndTheirProds_usingModel()
        {
            var liste = from m in _context.Movies
                       join p in _context.Producers
                       on m.ProducerId equals p.Id
                       select new ProdMovie
                       {
                           MTitle = m.Title,
                           MGenre = m.Genre,
                           PName = p.Name,
                           PNat = p.Nationality,
        
                       };
            return View(await liste.ToListAsync());
        }

        //joiture avec .include() entre Movie et Producer
        public async Task<IActionResult> MoviesAndTheirProds()
        {
            var MyDbContext = _context.Movies.Include(m => m.Producer);
            return View(await MyDbContext.ToListAsync());
        }

       

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var MyDbContext = _context.Movies.Include(m => m.Producer);
            return View(await MyDbContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,ProducerId")] Movie movie)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", movie.ProducerId);
            //return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", movie.ProducerId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,ProducerId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
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
            ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", movie.ProducerId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'MyDbContext.Movies'  is null.");
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return _context.Movies.Any(e => e.Id == id);
        }
}