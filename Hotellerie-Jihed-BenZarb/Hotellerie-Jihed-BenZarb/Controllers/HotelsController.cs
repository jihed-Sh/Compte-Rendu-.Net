using Hotellerie_Jihed_BenZarb.Models.HotellerieModel;
using Microsoft.AspNetCore.Mvc;

namespace Hotellerie_Jihed_BenZarb.Controllers;

public class HotelsController : Controller
{
    // GET
    HotellerieDbContext _context;
         public HotelsController(HotellerieDbContext context)
         {
             _context = context;
         }


                // GET: HotelsController
        public ActionResult Index()
        {
            return View(_context.Hotels);
        }

        // GET: HotelsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.Hotels.Find(id));
        }

        // GET: HotelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            try
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();             
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.Hotels.Find(id));
        }

        // POST: HotelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel hotel)
        {
            try
            {    
                _context.Hotels.Update(hotel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.Hotels.Find(id));
        }

        // POST: HotelsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hotel hotel)
        {
            try
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
}