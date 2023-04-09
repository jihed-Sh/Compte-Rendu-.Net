using CInemaManager_JihedBenZarb.Models.Cinema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CInemaManager_JihedBenZarb.Controllers;

public class ProducersController : Controller
{
    MyDbContext _context;
         public ProducersController(MyDbContext context)
         {
             _context = context;
         }


         public ActionResult MyMovies(int id)
        {
            var liste = from p in _context.Producers
                        join m in _context.Movies
                        on p.Id equals m.ProducerId
                        where p.Id == id
                        select new ProdMovie
                        {
                            MTitle = m.Title,
                            MGenre = m.Genre,
                            PName = p.Name,
                            PNat = p.Nationality,
                        };
            return View(liste);
        }

        public ActionResult ProdsAndTheirMovies_usingModel()
        {
            var liste = from p in _context.Producers
                        join m in _context.Movies
                        on p.Id equals m.ProducerId
                        select new ProdMovie {
                            MTitle = m.Title,
                            MGenre = m.Genre,
                            PName = p.Name,
                            PNat = p.Nationality,
                        };
            return View( liste);
        }

        //prodsandtheirmovies
        public ActionResult ProdsAndTheirMovies()
        {
            return View(_context.Producers.Include(p => p.Movies));
        }
        // GET: ProducersController
        public ActionResult Index()
        {
            return View(_context.Producers);
        }

        // GET: ProducersController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Producers.Find(id));
        }

        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producer p)
        {
            try
            {
                _context.Producers.Add(p);
                _context.SaveChanges();             
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProducersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Producers.Find(id));
        }

        // POST: ProducersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producer p)
        {
            try
            {    
                _context.Producers.Update(p);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProducersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Producers.Find(id));
        }

        // POST: ProducersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Producer p)
        {
            try
            {
                _context.Producers.Remove(p);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
}