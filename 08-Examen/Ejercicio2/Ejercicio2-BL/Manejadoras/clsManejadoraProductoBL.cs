using Ejercicio2_DAL.Manejadoras;
using Ejercicio2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_BL.Manejadoras
{
    public class clsManejadoraProductoBL
    {

        private clsManejadoraProductoDAL oManejadoraProductoDAL;

        public clsManejadoraProductoBL()
        {
            try
            {
                oManejadoraProductoDAL = new clsManejadoraProductoDAL();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Inserta un producto
        /// </summary>
        /// <param name="p">Producto a insertar</param>
        /// <returns>Numero de filas afectadas</returns>
        public int insertProducto(clsProducto p)
        {
            int i = oManejadoraProductoDAL.insertProductoDAL(p);
            return i;
        }

    }
}
