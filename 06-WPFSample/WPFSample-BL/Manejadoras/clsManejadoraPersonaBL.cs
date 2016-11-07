using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_BL.Manejadoras;
using WPFSample_DAL.Manejadoras;
using WPFSample_ET;

namespace WPFSample_BL.Manejadoras
{
    public class clsManejadoraPersonaBL
    {
        private clsManejadoraPersonaDAL oManejadoraPersonaDAL;

        public clsManejadoraPersonaBL()
        {
            oManejadoraPersonaDAL = new clsManejadoraPersonaDAL();
        }

        /// <summary>
        /// Inserta una persona
        /// </summary>
        /// <param name="p">Persona a insertar</param>
        /// <returns>Numero de filas afectadas</returns>
        public int insertPersona(clsPersona p)
        {
            int i = oManejadoraPersonaDAL.insertPersonaDAL(p);
            return i;
        }

    }
}
