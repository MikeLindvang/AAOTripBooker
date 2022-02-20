using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAOTripBooker.Data;
using AAOTripBooker.Models;

namespace AAOTripBooker.Controllers
{
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TripController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Trip> objList = _db.Trips;
            return View(objList);

        }

        //GET-Create
        public IActionResult Create()
        {
            
            return View();

        }
        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trip obj)
        {
            _db.Trips.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        //GET Delete
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Trips.Find(id);
            if (obj == null) { return NotFound(); }



            return View(obj);



        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Trips.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            _db.Trips.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");



        }

        //GET Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Trips.Find(id);
            if (obj == null) { return NotFound(); }



            return View(obj);



        }
        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Trip obj)
        {
            _db.Trips.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");



        }
    }
}
