using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL.Listados;
using ET;
using BL.Manejadoras;

namespace _09_ApiRest.Controllers
{
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        // GET api/persona
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            try
            {
                clsListadosBL lBL = new clsListadosBL();
                return lBL.getListadoPersonaBL();

            }
            catch(Exception)
            {
                Response.StatusCode = 500;
            }

            return null; 
        }

        // GET api/persona/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            clsManejadoraPersonaBL cMP = new clsManejadoraPersonaBL();
            clsPersona p = cMP.getPersona(id);
            if (p == null)            
                Response.StatusCode = 404;            
            return p;
        }

        // POST api/persona
        [HttpPost]
        public void Post([FromBody]clsPersona value)

        {
            clsManejadoraPersonaBL cMP = new clsManejadoraPersonaBL();
            cMP.insertPersona(value);
        }

        // PUT api/persona/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]clsPersona value)
        {
            clsManejadoraPersonaBL cMP = new clsManejadoraPersonaBL();
            value.id = id;
            cMP.updatePersona(value);
        }

        // DELETE api/persona/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            clsManejadoraPersonaBL cMP = new clsManejadoraPersonaBL();
            cMP.deletePersona(id);
        }
    }
}
