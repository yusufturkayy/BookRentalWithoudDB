using BookRentalWithoudDB.Data;
using BookRentalWithoudDB.Models;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalWithoudDB.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            StudentRespository repository = new StudentRespository();

            var students=repository.GetAllStudents();
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            StudentRespository repository = new StudentRespository();
            var student = repository.GetStudent(id);
            if(student==null)
            {
                return NotFound();
            } else
            {
                return View(student);
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentRespository respository = new StudentRespository();
            respository.Insert(student);
            return RedirectToAction("Index");
        }
    }
}
