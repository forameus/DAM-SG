using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_Sessions.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Llama a la página principal (index)
        /// </summary>
        /// <returns>Devuelve la vista "Index"</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boton"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string boton, string txtNombre)
        {
            switch (boton)
            {
                case "+1":
                    Session["contador"] = Convert.ToInt32(Session["contador"]) + 1;                    
                    break;
                case "Cerrar sesión":
                    Session.Clear();
                    Session.Abandon();
                    break;
                case "Log In":
                    Session["nombreUsuario"] = txtNombre;
                    break;              
            }

            return View();
        }
    }
}