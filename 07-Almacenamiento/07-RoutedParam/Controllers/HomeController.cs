using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_RoutedParam.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Devuelve el la vista index
        /// </summary>
        /// <param name="id">Contador</param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            if (id == null)
                id = 0;

            ViewBag.contador = id;
            return View();
        }
        /// <summary>
        /// Devuelve la vista index una vez se ha ejecutado la acción
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost(int? id)
        {
            int contador = 1;
            if (id != null)
                contador = (int) id+1;
            return RedirectToAction("Index", new { id = contador });
        }
    }
}