using Ejercicio1_BL.Manejadoras;
using Ejercicio1_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicio1_UI.Controllers
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
        /// Llama a la vista Details o a la Index dependiendo de la opción.
        /// </summary>
        /// <param name="boton">Valor del boton del submit</param>
        /// <param name="txtID">Valor del input tipo texto del ID</param>
        /// <param name="txtNick">Valor del input tipo texto del Nick</param>
        /// <returns>Devuelve la vista Index si el valor de boton es "Cerrar sesión" o la vista Details en caso de que el valor sea "Buscar"</returns>
        [HttpPost]
        public ActionResult Index(string boton, string txtID, string txtNick)
        {
            bool buscar = true;
            switch (boton)
            {
                case "Buscar":
                    if(Session["nick"]==null)
                        Session["nick"] = txtNick;
                    buscar = true;
                    break;                    
                    

                case "Cerrar sesión":
                    Session.Clear();
                    Session.Abandon();
                    buscar = false;
                    break;               
            }

            if (buscar)
            {
                try
                {
                    int id = Convert.ToInt32(txtID);
                    clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                    clsPersona p = oManejadoraPersonaBL.getPersona(id);
                    if (p != null)
                        return View("Details", p);
                    else
                        return View("ErrorID", id);
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }

                
            else
                return View();

        }


        /// <summary>
        /// Retorna la vista de detalles de una persona según su id.
        /// </summary>
        /// <param name="id">Id de la persona.</param>
        /// <returns>Devuelve la vista "Details" con los datos de la persona o "Error" en caso de error.</returns>
        public ActionResult Details(int id)
        {
            clsPersona p;

            try
            {
                clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                p = oManejadoraPersonaBL.getPersona(id);
                return View(p);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


    }
}