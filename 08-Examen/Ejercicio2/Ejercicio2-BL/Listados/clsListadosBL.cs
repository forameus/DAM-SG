using Ejercicio2_BL.Listados;
using Ejercicio2_DAL.Listados;
using Ejercicio2_ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_BL.Listados
{
    public class clsListadosBL
    {
        /// <summary>
        /// Devuelve un listado de las categorias
        /// </summary>
        /// <returns>Devuelve el listado de las categorias</returns>
        public List<clsCategoria> getListadoCategoriasBL()
        {
            try
            {
                List<clsCategoria> lista = new List<clsCategoria>();
                clsListadoDAL milista = new clsListadoDAL();

                lista = milista.getListadoCategoriasDAL();

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
