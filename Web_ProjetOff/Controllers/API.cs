using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProjetOfficiel.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Web_ProjetOff.ControllersAPI
{
    public sealed class API
    {
        private static readonly HttpClient client = new HttpClient();

        private API()
        {
            client.BaseAddress = new Uri("http://localhost:5290/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private static readonly object padlock = new object();
        private static API instance = null;
        
        public static API Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new API();
                    }
                    return instance;
                }
            }
        }

        public object ModelState { get; private set; }

        public async Task<ServiceAdmin> GetUser(int id)
        {
            ServiceAdmin
                user = null;
            HttpResponseMessage response = client.GetAsync("api/serviceAdmin/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<ServiceAdmin>(resp);
            }
            return user; 
        }
        

        private IActionResult RedirectToAction(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceAdmin> GetUser(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return await GetUser(id);
            return null;
        }

        public async Task<ServiceAdmin> GetUser(string login, string pwd)
        {
            ServiceAdmin user = null;
            HttpResponseMessage response = client.GetAsync("api/serviceAdmin/" + login + "/" + pwd).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<ServiceAdmin>(resp);
            }
            return user;
        }

        public async Task<ICollection<Reservation
            >> GetReservationsAsync()
        {
            ICollection<Reservation> Reservations = new List<Reservation
                >();
            HttpResponseMessage response = client.GetAsync("api/reservations").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Reservations = JsonConvert.DeserializeObject<List<Reservation>>(resp);
            }
            return Reservations;
        }

        public async Task<Reservation> GetReservationsAsync(int? id)
        {
            Reservation Reservation = null;
            HttpResponseMessage response = client.GetAsync("api/reservations/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Reservation = JsonConvert.DeserializeObject<Reservation>(resp);
            }
            return Reservation;
        }
        public async Task<Uri?> AjoutJoueurAsync(ServiceAdmin sa)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/serviceAdmins", sa);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri?> AjoutReservationAsync(Reservation reservation)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/reservations", reservation);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        public async Task<Uri?> AjouterEquipeAsync(Equipe e)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/equipes", e);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri?> AjouterTerrainAsync(TerrainFoot t)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/terrainFoot", t);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri?> ModifReservationAsync(Reservation reservation)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("api/reservations/" + reservation.Id, reservation);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Uri> SupprReservationAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("api/reservations/" + id);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<ICollection<TerrainFoot>> GetTerrainAsync() {
            ICollection<TerrainFoot> Salles = new List<TerrainFoot>();
            HttpResponseMessage response = client.GetAsync("api/terrainfoot/" ).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Salles = JsonConvert.DeserializeObject<List<TerrainFoot>>(resp);
            }

#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return Salles;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }
        // In your API project, under Controllers/TerrainsController.cs



    }
}
