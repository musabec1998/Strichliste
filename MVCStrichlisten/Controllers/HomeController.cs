using Microsoft.AspNetCore.Mvc;
using Strichliste.Models;
using System.Diagnostics;

namespace Strichliste.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Benutzer> benutzerListe = new List<Benutzer> { new Benutzer() { Id = 1, Name = "Osman" }, new Benutzer() { Id = 2, Name = "Lina" } };

        public IActionResult Index()
        {
            return View(benutzerListe);
        }

       

        public IActionResult BenutzerHinzufügen(string neuerBenutzer)
        {
            benutzerListe.Add(new Benutzer() { Id = benutzerListe.Count + 1, Name = neuerBenutzer });

            return PartialView("_NutzerAnzeigen", benutzerListe);
        }

        public PartialViewResult ZeigeBenutzer()
        {
            return PartialView("_NutzerAnzeigen", benutzerListe);
        }

        public IActionResult NutzerLöschen(int id)
        {
            Benutzer benutzer = benutzerListe.Find(b => b.Id == id);

            if (benutzer != null)
            {
                benutzerListe.Remove(benutzer);
            }

            return PartialView("_NutzerAnzeigen", benutzerListe);
        }

        public IActionResult Hoch(string benutzerName)
        {
            Benutzer benutzer = benutzerListe.Find(b => b.Name == benutzerName);

            if (benutzer != null)
            {
                benutzer.Anzahl++;
            }

            return PartialView("_NutzerAnzeigen", benutzerListe);
        }

        public IActionResult Runter(string benutzerName)
        {
            Benutzer benutzer = benutzerListe.Find(b => b.Name == benutzerName);

            if (benutzer?.Anzahl > 0)
            {
                benutzer.Anzahl--;
            }

            return PartialView("_NutzerAnzeigen", benutzerListe);
        }

        public IActionResult BenutzerNameAndern(int nutzerID, string benutzerName)
        {
            Benutzer benutzer = benutzerListe.Find(b => b.Id == nutzerID);

            if (benutzer != null)
            {
                benutzer.Name = benutzerName;
            }

            return PartialView("_NutzerAnzeigen", benutzerListe);
        }

        

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}