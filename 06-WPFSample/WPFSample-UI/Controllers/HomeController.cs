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
        // GET: Home
        public ActionResult Index()
        {
            clsListadosBL milista;

            try
            {
                milista = new clsListadosBL();
            }
            catch (Exception)
            {
                return View("paginaError");
            }

            return View(milista.getListadoPersonaBL());
        }

        public ActionResult Create()
        {
            return View();
        }


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
                catch (Exception)
                {
                    return View("Error");
                }

            }

        }

        public ActionResult Edit(int id)
        {

            try
            {
                clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                clsPersona p = oManejadoraPersonaBL.getPersona(id);

                return View(p);
            }
            catch
            {
                return View("Error");
            }
            
        }

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


 
        public ActionResult Details(clsPersona persona)
        {
            clsPersona p;
            
                try
                {
                    clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                    p = oManejadoraPersonaBL.getPersona(persona.id);
                    return View(p);
                }
                catch (Exception)
                {
                    return View("Error");
                }            
        }

        public ActionResult Delete(clsPersona p)
        {
            int i;

            try
            {
                clsManejadoraPersonaBL oManejadoraPersonaBL = new clsManejadoraPersonaBL();
                i = oManejadoraPersonaBL.deletePersona(p.id);
                return View(p);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }


    }

   

}