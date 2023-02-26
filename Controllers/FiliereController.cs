using GestionEtudiants.Application;
using GestionEtudiants.Interfaces;
using GestionEtudiants.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiants.Controllers
{
   // [Route("filiere")]
    public class FiliereController : Controller
    {
        private IFiliereRepository filiereRepository;

        public FiliereController(IFiliereRepository f)
        {
            filiereRepository = f;
        }

        //******************************GET ALL************************************************
        [HttpGet]
        [Route("Filieres")]
        public IActionResult GetAll()
        {
            var filieres = filiereRepository.GetAll();
            return View(filieres);
        }

        //*********************************GET BY ID********************************************
        [HttpGet]
        [Route("Filiere/Detail/{id}")]
        public JsonResult Details(int id)
        {
            var filiere = filiereRepository.GetFiliereById(id);
            return Json(filiere);
        }

        //**************************************FORMULAIRE MODIFICATION*******************************************
        [HttpGet]
        [Route("EditFiliere/{id}")]
        public IActionResult EditFiliere(int id)
        {

            Filiere filiere = filiereRepository.GetFiliereById(id);
            ViewData["filiere"] = filiere;
            return View(filiere);
        }
        //*******************************************DELETE************************************
        [Route("Filiere/Delete/{filiereId}")]
        public IActionResult DeleteFiliere(int filiereId)
        {
            var filiere = filiereRepository.GetFiliereById(filiereId);
            if (filiere == null)
            {
                return NotFound();
            }
            var deletedFiliereId = filiereRepository.Delete(filiereId);

            if (deletedFiliereId == 0)
            {
                return StatusCode(500, "Une erreur s'est produite lors de la suppression de l'étudiant.");
            }

            return RedirectToAction("GetAll");
        }
        //***************************FORMULAIRE AJOUT FILIERE************************************
        [HttpGet]
        [Route("FormulaireAjoutFiliere")]
        public IActionResult CreateFiliere()
        {
            return View();
        }
        //********************************AJOUT D'UNR FILIERE*************************************
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Filiere filiere)
        {
            filiereRepository.Add(filiere);
            return RedirectToAction(nameof(GetAll));
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult Update(Filiere filiere)
        {
            filiereRepository.Update(filiere);
            return RedirectToAction(nameof(GetAll));
        }

    }
}
