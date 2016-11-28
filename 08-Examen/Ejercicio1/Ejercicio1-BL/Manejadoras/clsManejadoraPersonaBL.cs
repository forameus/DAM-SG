using Ejercicio1_BL.Manejadoras;
using Ejercicio1_DAL.Manejadoras;
using Ejercicio1_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_BL.Manejadoras
{
    public class clsManejadoraPersonaBL
    {
        private clsManejadoraPersonaDAL oManejadoraPersonaDAL;

        public clsManejadoraPersonaBL()
        {
            try
            {
                oManejadoraPersonaDAL = new clsManejadoraPersonaDAL();
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /// <summary>
        /// Obtiene una persona
        /// </summary>
        /// <param name="p">Persona a obtener</param>
        /// <returns>Numero de filas afectadas</returns>
        public clsPersona getPersona(int id)
        {
            clsPersona p = oManejadoraPersonaDAL.getPersonaDAL(id);
            return p;
        }

    }
}
