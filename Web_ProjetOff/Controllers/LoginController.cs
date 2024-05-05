using Microsoft.AspNetCore.Mvc;
using ProjetOfficiel.Models;
using Web_ProjetOff.ViewModels;

namespace Web_ProjetOff.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult addJoueur()
        {
            return View();
        }

        public ActionResult Index(UserViewModel viewModel)
        {
            //if (ModelState.IsValid)
            {
                ServiceAdmin user = ControllersAPI.API.Instance.GetUser(viewModel.ServiceAdmin.Login, viewModel.ServiceAdmin.Pwd).Result;
                if (user != null)
                {
                    return Redirect("/ServiceAdmins/Index");
                }
                ModelState.AddModelError("User.Login", "Login et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

    }
}
