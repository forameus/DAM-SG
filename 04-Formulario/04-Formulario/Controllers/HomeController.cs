using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04_Formulario.Models;

namespace _04_Formulario.Controllers
{
    public class HomeController : Controller
    {
        clsListado listado = new clsListado();

        // GET: Home
        public ActionResult Index()
        {
            //clsListado listado = new clsListado();
            return View(listado.lista);
        }

       public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(clsPersona p)
        {


            if (ModelState.IsValid){
                listado.lista.Add(p);
                return View("Index", listado.lista);
            }
            else
                return View();
        }


    }
}