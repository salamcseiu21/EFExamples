using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMvcCore.DatabaseContext;
using WebAppMvcCore.Models;


namespace WebAppMvcCore.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db;

        public CourseController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

          IEnumerable<SelectListItem> departmentListItems = db.Departments.Select(c =>
                new SelectListItem() { Value = c.Id.ToString(), Text = c.DeptName });

            ViewData["DepartmentId"] = departmentListItems;
           

          
            return View();
           

          
        }

        [HttpPost]
        public IActionResult Create(Course model)
        {

           
            
            



            db.Courses.Add(model);
            IEnumerable<SelectListItem> departmentListItems = db.Departments.Select(c =>
                new SelectListItem() { Value = c.Id.ToString(), Text = c.DeptName });

            ViewData["DepartmentId"] = departmentListItems;
            bool isSaved = db.SaveChanges() > 0;
            if (isSaved)
            {
                ViewBag.Message = "Saved Succesful!";
            }
            ModelState.Clear();
            return View();
        }

        public IActionResult Search()
        {
            var Courses = db.Courses.ToList();
            return View(Courses);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await db.Courses.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, [Bind("Id,CourseName,CourseCode,Trainer,Time")] Course course)
        {
            if (ModelState.IsValid)
            {
                if (id != course.Id)
                {
                    return NotFound();
                }
                try
                {
                    db.Update(course);
                    db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExist(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Search");
            }
            return View();
        }

        private bool CourseExist(int id)
        {
            return db.Courses.Any(e => e.Id == id);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await db.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await db.Courses.FindAsync(id);
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Search));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await db.Courses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
        
    }
}