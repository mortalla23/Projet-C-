using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Web_ProjetOff.ControllersAPI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_ProjetOff.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using ProjetOfficiel.Models;
namespace Web_ProjetOff.Controllers
{
    public class ReservationController : Controller
    {

       
        public IActionResult Index()
            {
            IEnumerable<Reservation> reservations = API.Instance.GetReservationsAsync().Result;
                return View(reservations);
            }

            // GET: Ecuries/Details/5
            public IActionResult Details(int? id)
            {
                if (id == null)
                {
                    return null;
                }
                return View(API.Instance.GetReservationsAsync(id).Result);
            }

            // GET: Ecuries/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Ecuries/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create([Bind("Id,Nom")] Reservation reservation)
            {
                if (ModelState.IsValid)
                {
                    var URI = API.Instance.AjoutReservationAsync(reservation);
                    return RedirectToAction(nameof(Index));
                }
                return View(reservation);
            }
            // GET: Ecuries/Edit/5
            public IActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return null;
                }
                return View(API.Instance.GetReservationsAsync(id).Result);
            }

            // POST: Ecuries/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int id, [Bind("Id,Nom")] Reservation reservation)
            {
                if (id != reservation.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var URI = API.Instance.ModifReservationAsync(reservation);
                    return RedirectToAction(nameof(Index));
                }
                return View(reservation);
            }

            // GET: Ecuries/Delete/5
            public IActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return null;
                }
                return View(API.Instance.GetReservationsAsync(id).Result);
            }
            [HttpPost, ActionName("Delete")]
            // POST: Ecuries/Delete/5
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                var URI = API.Instance.SupprReservationAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }



