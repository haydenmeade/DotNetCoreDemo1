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
    public class ModelController : Controller
    {

        private readonly VroomDbContext _db;

        [BindProperty]
        public ModelViewModel ModelViewModel { get; set; }

        public ModelController(VroomDbContext db)
        {
            _db = db;
            ModelViewModel = new ModelViewModel()
            {
                Makes = _db.Makes.ToList(),
                Model = new Models.Model()
            };

        }
        public IActionResult Index()
        {
            var model = _db.Models.Include(m => m.Make);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(ModelViewModel);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost(Model model)
        {
            if (ModelState.IsValid)
            {
                _db.Models.Add(ModelViewModel.Model);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ModelViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
            ModelViewModel.Model = model;
            if (model is null)
            {
                return NotFound();
            }
            return View(ModelViewModel);
        }

        [HttpPost]
        public IActionResult Edit()
        {
            if (ModelState.IsValid)
            {
                _db.Update(ModelViewModel.Model);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ModelViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _db.Models.Find(id);
            if (model is null)
            {
                return NotFound();
            }
            _db.Models.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}