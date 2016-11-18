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
        /// Inserta una persona
        /// </summary>
        /// <param name="p">Persona a insertar</param>
        /// <returns>Numero de filas afectadas</returns>
        public int insertPersona(clsPersona p)
        {
            int i = oManejadoraPersonaDAL.insertPersonaDAL(p);
            return i;
        }


        /// <summary>
        /// Actualiza una persona
        /// </summary>
        /// <param name="p">Persona a actualizar</param>
        /// <returns>Numero de filas afectadas</returns>
        public int updatePersona(clsPersona p)
        {
            int i = oManejadoraPersonaDAL.updatePersonaDAL(p);
            return i;
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

        /// <summary>
        /// Borra una persona
        /// </summary>
        /// <param name="p">Persona a borrar</param>
        /// <returns>Numero de filas afectadas</returns>
        public int deletePersona(int id)
        {
            int p = oManejadoraPersonaDAL.deletePersonaDAL(id);
            return p;
        }

    }
}
