using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetOfficiel.Models;
using System.Diagnostics;
using Web_ProjetOff.ControllersAPI;
using Web_ProjetOff.Models;

namespace Web_ProjetOff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
       

        public IActionResult Reservation()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Equipe()
        {
            return View();
        }
        public IActionResult addTerrain()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // POST: Equipe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AjouterEquipe([Bind("Name")] Equipe equipe)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.AjouterEquipeAsync(equipe);
                return RedirectToAction("Index", "Home");
            }
            return View(equipe);
        }

        // POST: Reservation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AjoutReservation([Bind("DateDebut","DateFin","EquipeId","TerrainId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.AjoutReservationAsync(reservation);
                return RedirectToAction("Index", "Home");
            }
            return View(reservation);
        }
        // Dans votre HomeController


        // POST: admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Connex([Bind("Name", "Pwd")] ServiceAdmin s)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.AjoutJoueurAsync(s);
                return RedirectToAction("Index", "Home");
            }
            return View(s);
        }


        // POST: Terrain
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AjouterTerrain([Bind("Name", "Disponible")] TerrainFoot terrainfoot)
        {
            if (ModelState.IsValid)
            {
                var URI = API.Instance.AjouterTerrainAsync(terrainfoot);
                TempData["SuccessMessage"] = "Le terrain a été ajouté avec succès.";
                return RedirectToAction("Index", "Home");
            }
            return View(terrainfoot);
        }
        public IActionResult ListeTerrain()
        {
            return View(API.Instance.GetTerrainAsync());
        }
    }
}
