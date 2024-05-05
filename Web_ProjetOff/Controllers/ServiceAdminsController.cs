using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetOfficiel.Data;
using ProjetOfficiel.Models;

namespace Web_ProjetOff.Controllers
{
    public class ServiceAdminsController : Controller
    {
        private readonly ProjetOfficielContext _context;

        public ServiceAdminsController(ProjetOfficielContext context)
        {
            _context = context;
        }

        // Autres actions CRUD ici...

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Connex(ServiceAdmin serviceAdmin)
        {
            // Assurez-vous d'implémenter une vérification sécurisée des identifiants ici
            var admin = await _context.ServiceAdmin
                .FirstOrDefaultAsync(a => a.Login == serviceAdmin.Login && a.Pwd == serviceAdmin.Pwd);

            if (admin != null)
            {
                // Logique de gestion de session ou de cookies ici
                // par exemple, en utilisant l'authentification par cookies de ASP.NET Core Identity

                return RedirectToAction("Index", "Home"); // Assurez-vous que cette redirection est correcte
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login ou mot de passe incorrect.");
                return View(serviceAdmin); // Assurez-vous que la vue `Connex` existe et est correctement configurée
            }
        }

        // Autres actions du contrôleur...
    }
}
