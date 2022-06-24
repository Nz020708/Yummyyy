using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy.DAL;
using Yummy.Models;

namespace Yummy.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class MenuController : Controller
    {
       
        private AppDbContext _db { get; }
        public IEnumerable<Menu> Menu { get; set; }
        public MenuController(AppDbContext db)
        {
            _db = db;
            Menu = _db.Menu.ToList();
        }
        // GET: PlaceController
        public ActionResult Index()
        {
            return View(Menu);
        }

        // GET: PlaceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlaceController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: PlaceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile image,Menu food)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Add(food);
                    Menu foodd = new Menu
                    {
                        Title = food.Title,
                        Description = food.Description,
                        Price = food.Price,
                        Url = food.Url
                    };
                    await _db.Menu.AddAsync(foodd);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(food);
        }

        // GET: PlaceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlaceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlaceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dish = await _db.Menu.FindAsync(id);
            if (dish == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _db.Menu.Remove(dish);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
