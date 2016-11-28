using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1_ET;
using Ejercicio1_DAL.Conexion;

namespace Ejercicio1_DAL.Manejadoras
{
    public class clsManejadoraPersonaDAL
    {

        clsMyConnection miConexion;
        SqlDataReader miReader;

        public clsManejadoraPersonaDAL()
        {
            miConexion = new clsMyConnection();
        }

        
        /// <summary>
        /// Obtiene una persona de la base de datos.
        /// </summary>
        /// <param name="id">Id de la persona.</param>
        /// <returns>Numero de filas afectadas</returns>
        public clsPersona getPersonaDAL(int id)
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            clsPersona res;

            //Añadir datos al comando
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = miConexion.getConnection();


                miComando.CommandText = "SELECT * FROM personas WHERE IDPersona = @id";
                miComando.Connection = conexion;

                miReader = miComando.ExecuteReader();
                if (miReader.Read())
                {
                    string nombre = (string)miReader["nombre"];
                    string apellidos = (string)miReader["apellidos"];
                    DateTime fechaNac = (DateTime)miReader["fechaNac"];
                    string direccion = (string)miReader["direccion"];
                    string telefono = (string)miReader["telefono"];
                    res = new clsPersona(nombre, apellidos, id, fechaNac, direccion, telefono);
                }

                else
                {
                    res = null;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return res;
        }

    }
}
