using Ejercicio2_DAL.Conexiones;
using Ejercicio2_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_DAL.Manejadoras
{
    public class clsManejadoraProductoDAL
    {
        clsMyConnection miConexion;

        public clsManejadoraProductoDAL()
        {
            miConexion = new clsMyConnection();
        }

        /// <summary>
        /// Inserta un producto en la base de datos.
        /// </summary>
        /// <param name="p">Producto a insertar.</param>
        /// <returns>Numero de filas afectadas</returns>
        public int insertProductoDAL(clsProducto p)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            //Añadir datos al comando
            miComando.Parameters.Add("@nombreProducto", System.Data.SqlDbType.VarChar).Value = p.nombreProducto;
            miComando.Parameters.Add("@idCategoria", System.Data.SqlDbType.VarChar).Value = p.idCategoria;
            

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "INSERT INTO productos (idCategoria, nombreProducto) VALUES(@idCategoria,@nombreProducto)";
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }



    }
}
