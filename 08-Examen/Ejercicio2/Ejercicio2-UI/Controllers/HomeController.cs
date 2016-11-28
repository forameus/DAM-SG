using Ejercicio2_BL.Listados;
using Ejercicio2_BL.Manejadoras;
using Ejercicio2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio2_UI.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Devuelve la vista Index
        /// </summary>
        /// <returns>Devuelve la vista Index</returns>
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Devuelve la vista Create
        /// </summary>
        /// <returns>Devuelve la vista Create</returns>
        public ActionResult Create()
        {
            List<clsCategoria> laLista;
            try
            {               
                laLista = new clsListadosBL().getListadoCategoriasBL();
                ViewBag.Lista = laLista;
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View();            
        }
        
        /// <summary>
        /// Inserta un producto en la base de datos
        /// </summary>
        /// <param name="p">Producto a insertar</param>
        /// <returns>Devuelve la vista index</returns>
        [HttpPost]
        public ActionResult Create(clsProducto p)
        {
            int i;
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                try
                {
                    clsManejadoraProductoBL oManejadoraProductoBL = new clsManejadoraProductoBL();
                    i = oManejadoraProductoBL.insertProducto(p);
                    
                    return View("Index");
                }
                catch (Exception e)
                {
                    return View("Error");
                }

            }
        }


    }
}