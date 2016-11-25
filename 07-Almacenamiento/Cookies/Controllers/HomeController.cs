using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            if (!Request.Cookies.AllKeys.Contains("contador"))
            {
                HttpCookie miCookie = new HttpCookie("contador", "0");
                miCookie.Expires = DateTime.Now.AddDays(7);

                Response.Cookies.Add(miCookie);
                ViewBag.contador = 0;
            }
            else {
                HttpCookie miCookie = Request.Cookies["contador"];

                ViewBag.contador = Convert.ToInt32(miCookie.Value);
                //Response.SetCookie(miCookie);

            }
            return View();
        }



        [HttpPost, ActionName("Index")]
        public ViewResult IndexPost()
        {
            HttpCookie miCookie = Request.Cookies["contador"];
            int contador = Convert.ToInt32(miCookie.Value);
            contador++;
            ViewBag.contador = contador;

            miCookie.Value = Convert.ToString(contador);
            miCookie.Expires.AddDays(7);
            Response.SetCookie(miCookie);

            return View();

        }

    }
}