using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFSample_BL.Listados;
using WPFSample_BL.Manejadoras;
using WPFSample_ET;

namespace WPFSample_UI.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Llama a la página principal (index)
        /// </summary>
        /// <returns>Devuelve la página "Index" con el listado de personas o la página "Error" en caso de error.</returns>
        public ActionResult Index()
        {
            clsListadosBL milista;
            List<clsPersona> laLista;
            try
            {
                milista = new clsListadosBL();
                laLista = milista.getListadoPersonaBL();
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(laLista);
        }
        
        /// <summary>
        /// Llama a la página de Creacion de persona
        /// </summary>
        /// <returns>Devuelve la vista Create</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Añade la persona de la vista Create a la base de datos
        /// </summary>
        /// <param name="persona">Persona a crear</param>
        /// <returns>Devuelve la vista "Index" con el listado de personas o "Error" en caso de error.</returns>
        [HttpPost]
        public ActionResult Create(clsPersona persona)
        {
            int i;
            if (!ModelState.IsValid)
            {
                return View(persona);
            }
            else
            {
                try
                {
                    clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                    i = oManejadoraPersonaBL.insertPersona(persona);

                    clsListadosBL oListadoBL = new clsListadosBL();
                    return View("Index", oListadoBL.getListadoPersonaBL());
                }
                catch (Exception e)
                {
                    return View("Error");
                    //throw e;
                }

            }

        }

        /// <summary>
        /// Retorna la vista "Edit" con la persona editar.
        /// </summary>
        /// <param name="id">Id de la persona a editar.</param>
        /// <returns>Devuelve la vista "Edit" con la persona a cuyo id corresponde o "Error" en caso de error.</returns>
        public ActionResult Edit(int id)
        {

            try
            {
                clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                clsPersona p = oManejadoraPersonaBL.getPersona(id);

                return View("Edit",p);
            }
            catch(Exception )
            {
                return View("Error");                
            }
            
        }

        /// <summary>
        /// Edita la persona en la base de datos.
        /// </summary>
        /// <param name="persona">Persona ya editada.</param>
        /// <returns>Devuelve la vista "Index" con el listado de personas o "Error" en caso de error.</returns>
        [HttpPost]
        public ActionResult Edit(clsPersona persona)
        {
            int i;

            try
            {
                clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                i = oManejadoraPersonaBL.updatePersona(persona);

                clsListadosBL oListadoBL = new clsListadosBL();
                return View("Index", oListadoBL.getListadoPersonaBL());
            }
            catch (Exception)
            {
                return View("Error");
            }


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


        /// <summary>
        /// Retorna la vista de confirmación de borrado de una persona.
        /// </summary>
        /// <param name="id">Id de la persona a borrar.</param>
        /// <returns>Devuelve la vista "Delete" con los datos de la persona a borrar y la pregunta de confirmación de su borrado o "Error" en caso de error.</returns>
        public ActionResult Delete(int id)
        {

            try
            {
                clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                clsPersona p = oManejadoraPersonaBL.getPersona(id);

                return View(p);
            }
            catch (Exception)
            {
                return View("Error");
            }

        }

        /// <summary>
        /// Borra la persona de la base de datos.
        /// </summary>
        /// <param name="id">Id de la persona a borrar.</param>
        /// <returns>Devuelve la vista "Index" con el listado de personas o "Error" en caso de error.</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            int i;

            try
            {
                clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                i = oManejadoraPersonaBL.deletePersona(id);

                clsListadosBL oListadoBL = new clsListadosBL();
                return View("Index", oListadoBL.getListadoPersonaBL()); ;
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


    }

   

}