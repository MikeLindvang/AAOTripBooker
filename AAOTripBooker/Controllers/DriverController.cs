using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAOTripBooker.Data;
using AAOTripBooker.Models;
using AAOTripBooker.Models.ViewModels;

namespace AAOTripBooker.Controllers
{
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DriverController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Driver> objList = _db.Drivers;

            foreach(var obj in objList)
            {
                obj.DriverPeriods =  _db.DriverPeriods.Where(i => i.DriverId == obj.Id).ToList();
            }

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
        public IActionResult Create(Driver obj)
        {
            if (ModelState.IsValid)
            {
                _db.Drivers.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            return View(obj);
        }

        //GET Delete
        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Drivers.Find(id);
            if(obj == null) { return NotFound(); }



            return View(obj);



        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Drivers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            _db.Drivers.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");


           
        }

    }
}
