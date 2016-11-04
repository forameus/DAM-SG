using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _03_ViewDataYViewBag.Models;

namespace _03_ViewDataYViewBag.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Nombre"] = "Alberto";
            ViewData["Apellidos"] = "Navarro";

            ViewBag.Nombre = "Alberto";
            ViewBag.Apellidos = "Navarro";

            clsPersona persona = new clsPersona("Alberto", "Navarro", 20);

            return View(persona);
        }

        public ActionResult Listado() {
            clsListado lista = new clsListado();
            
            return View(lista.lista);
        }
    }
}