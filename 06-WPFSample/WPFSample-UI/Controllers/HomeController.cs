using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WPFSample_BL.Listados;
using WPFSample_ET;

namespace WPFSample_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            clsListadosBL milista = new clsListadosBL();

            return View(milista.getListadoPersonaBL());
        }
    }
}