using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_ET;

namespace WPFSample_DAL.Manejadoras
{
    public class clsManejadoraPersonaDAL
    {

        clsMyConnection miConexion;

        public clsManejadoraPersonaDAL()
        {
            miConexion = new clsMyConnection();
        }


        /// <summary>
        /// Inserta una persona en la base de datos.
        /// </summary>
        /// <param name="persona">Persona a insertar.</param>
        /// <returns>Numero de filas afectadas</returns>
        public int insertPersonaDAL(clsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            //Añadir datos al comando
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.VarChar).Value = persona.fechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "INSERT INTO personas (nombre, apellidos, fechaNac, direccion, telefono) VALUES(@nombre,@apellidos,@fechaNac,@direccion,@telefono)";
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }

            return resultado;
        }
    }
}
