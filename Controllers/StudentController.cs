using GestionEtudiants.Application;
using GestionEtudiants.Interfaces;
using GestionEtudiants.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiants.Controllers
{

    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository { get; set; }
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        [Route("EditStudent/{id}")]
        public IActionResult Edit(int id)
        {

           Student student = _studentRepository.GetStudentById(id);
            ViewData["student"]=student;
            return View(student);
        }

        [HttpPost]
        [Route("EditStudent/Update")]
        public ActionResult Update(Student student) 
        {
                _studentRepository.Update(student);
            return RedirectToAction(nameof(GetAll));
        }


        [Route("Student/Detail/{id?}")]
        public JsonResult GetStudentById(int? id)
        {
            if (id == null)
            {
                return Json("Erreur, merci de fournir la valeur de l'Id");
            }
            else
            {
                var student = _studentRepository.GetStudentById(id.Value);

                return Json(student);
            }
        }

        [Route("students")]
        public IActionResult GetAll([FromServices] IStudentRepository studentRepository)
        {
            var students = studentRepository.GetAll();
            return View(students);
        }

        [Route("Student/Delete/{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            var student = _studentRepository.GetStudentById(studentId);

            if (student == null)
            {
                return NotFound();
            }

            var deletedStudentId = _studentRepository.Delete(studentId);

            if (deletedStudentId == 0)
            {
                return StatusCode(500, "Une erreur s'est produite lors de la suppression de l'étudiant.");
            }

            return RedirectToAction("GetAll");
        }
        
        [Route("CreateStudent")]
        public ActionResult CreateStudent(Student student)
        {
                _studentRepository.Add(student);
                return RedirectToAction(nameof(GetAll));
        }

        [HttpGet]
        [Route("FormulaireAjout")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
