using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiants.Controllers
{
   [Route("/")]
    public class HelloController : Controller
    {
        public IActionResult Index() {
            return View();
        }

        [Route("bonjour")]
        public string Bonjour()
        {
            return "Bonjour le monde";
        }
    }
}
