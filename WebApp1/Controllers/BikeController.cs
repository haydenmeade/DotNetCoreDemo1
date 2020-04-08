using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vroom.AppDbContext;
using vroom.Models;
using vroom.Models.ViewModels;

namespace vroom.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class BikeController : Controller
    {

        private readonly VroomDbContext _db;

        [BindProperty]
        public BikeViewModel BikeViewModel { get; set; }

        public BikeController(VroomDbContext db)
        {
            _db = db;
            BikeViewModel = new BikeViewModel()
            {
                Makes = _db.Makes.ToList(),
                Models = _db.Models.ToList(),
                Bike = new Models.Bike()
            };

        }
        public IActionResult Index()
        {
            var bikes = _db.Bikes.Include(m => m.Make).Include(m => m.Model);
            return View(bikes.ToList());
        }

        public IActionResult Create()
        {
            return View(BikeViewModel);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost()
        {
            if (ModelState.IsValid)
            {
                _db.Bikes.Add(BikeViewModel.Bike);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(BikeViewModel);
        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var model = _db.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
        //    ModelViewModel.Model = model;
        //    if (model is null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ModelViewModel);
        //}

        //[HttpPost]
        //public IActionResult Edit()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Update(ModelViewModel.Model);
        //        _db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ModelViewModel);
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var model = _db.Models.Find(id);
        //    if (model is null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Models.Remove(model);
        //    _db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}


    }
}