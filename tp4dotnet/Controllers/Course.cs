using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tp4dotnet.Data;
using tp4dotnet.Models;

namespace tp4dotnet.Controllers
{
    public class Course : Controller
    {
        public ActionResult Index()
        {

            StudentRepository studentRepository = new StudentRepository();
            foreach (String s in studentRepository.GetCourses())
                Debug.WriteLine(s);

            return View(studentRepository.GetCourses());
        }

        public IActionResult GetCourse(string id)
        {
            StudentRepository studentRepository = new StudentRepository();
            IEnumerable<Student> res = (IEnumerable<Student>)studentRepository.Find(v => v.course.ToLower() == id.ToLower());
           
            if (res.Count() != 0) ViewBag.Id = res.First().course;
            return View(res);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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


        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
