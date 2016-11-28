using Ejercicio2_DAL.Conexiones;
using Ejercicio2_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_DAL.Listados
{
    public class clsListadoDAL
    {
        /// <summary>
        /// Devuelve un listado con las categorías de la base de datos
        /// </summary>
        /// <returns>Devuelve un listado con las categorías</returns>
        public List<clsCategoria> getListadoCategoriasDAL()
        {
            List<clsCategoria> listadoCat;
            clsMyConnection miConexion;

            listadoCat = new List<clsCategoria>();

            miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;

            clsCategoria cat;

            try
            {
                conexion = miConexion.getConnection();
                command.CommandText = "SELECT * FROM categorias";
                command.Connection = conexion;
                lector = command.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        cat = new clsCategoria();
                        cat.id = (int)lector["idCategoria"];
                        cat.nombreCategoria = (string)lector["nombreCategoria"];
                        listadoCat.Add(cat);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return listadoCat;
        }
    }
}
