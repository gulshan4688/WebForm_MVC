using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplicationMVCCrudwithAjax.Data;
using WebApplicationMVCCrudwithAjax.Models;
using static System.Net.Mime.MediaTypeNames;


namespace WebApplicationMVCCrudwithAjax.Controllers {
    public class EmployeeController : Controller
    {
        // same with the help of that we can here create  a ctor that can read the database
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db) {
            _db = db ;
        }

        public IActionResult Index()  
        {
            List<Employee> employees = _db.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create() {
            ViewBag.Cities = new SelectList(new[] { "Ahmedabad", "Benguluru", "Pune", "Ratlam", "Indore", "Jabalpur", "Other" });
            return View();
        }
        [HttpPost]
        //this is a post action and here we will post the Employee class EmpObj
        public IActionResult Create(Employee EmpObj, IFormFile Image) {
            // Ignore ModelState validation

            if (Image != null && Image.Length > 0) {
                // Generate unique filename
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);

                // Save file physically to wwwroot/images
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create)) {
                    Image.CopyTo(stream);
                }

                // Save ONLY the filename in DB
                EmpObj.Image = fileName;
            }

            // EF will generate Id automatically (IDENTITY column in SQL)
            _db.Employees.Add(EmpObj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? Id) {
            ViewBag.Cities = new SelectList(new[] { "Ahmedabad", "Benguluru", "Pune", "Ratlam", "Indore", "Jabalpur", "Other" });
            if (Id == null || Id == 0) {
                return NotFound();
            }
            Employee? EmpObj = _db.Employees.Find(Id);

            if (EmpObj == null) {
                return NotFound();
            }

            return View(EmpObj);
        }
        
        [HttpPost]
        public IActionResult Edit(Employee EmpObj) {
            ViewBag.Cities = new SelectList(new[] { "Ahmedabad", "Benguluru", "Pune", "Ratlam", "Indore", "Jabalpur", "Other" });

            if (ModelState.IsValid) {
                _db.Employees.Update(EmpObj);
                _db.SaveChanges();

                // ✅ after saving, go back to Index page
                return RedirectToAction("Index");
            }

            // If model validation fails, show same form again with data
            return View(EmpObj);
        }
        [HttpGet]
        public IActionResult Delete(int? Id) {
            ViewBag.Cities = new SelectList(new[] { "Ahmedabad", "Benguluru", "Pune", "Ratlam", "Indore", "Jabalpur", "Other" });
            if (Id == null || Id == 0) {
                return NotFound();
            }
            Employee? EmpObj = _db.Employees.Find(Id);

            if (EmpObj == null) {
                return NotFound();
            }

            return View(EmpObj);
        }
        [HttpPost]
        public IActionResult Delete(Employee Empobj) {
            //var emp = _db.Employees.Find();
            //if (emp == null) {
            //    return NotFound();
            //}

            _db.Employees.Remove(Empobj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

