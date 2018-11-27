using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppMvcCore.DatabaseContext;
using WebAppMvcCore.Models;

namespace WebAppMvcCore.Controllers
{
    public class DepartmentController : Controller
    {
        private ApplicationDbContext db;

        public DepartmentController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department model)
        {
            db.Departments.Add(model);
            bool isSaved = db.SaveChanges() > 0;
            if (isSaved)
            {
                ViewBag.Message = "Saved Succesful!";
            }
            ModelState.Clear();
            return View();
        }

    }
}