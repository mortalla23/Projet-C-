using Microsoft.AspNetCore.Mvc;

namespace Web_ProjetOff.Controllers
{
    public class ISportiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AfficherTerrainsDisponibles()
        {
            return View();
        }
        public IActionResult ReserverTerrain()
        {
            return View();
        }


    }
}