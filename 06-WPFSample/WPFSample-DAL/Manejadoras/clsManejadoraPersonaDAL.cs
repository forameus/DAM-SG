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
        SqlDataReader miReader;

        public clsManejadoraPersonaDAL()
        {
            miConexion = new clsMyConnection();
            //miConexion = new clsMyConnection("107-08", "WPFSample", "prueba","123");
            //miConexion = new clsMyConnection("iesnervion.database.windows.net", "WPFSample", "prueba", "iesnervion123.");



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


        /// <summary>
        /// Edita una persona en la base de datos.
        /// </summary>
        /// <param name="persona">Persona a editar.</param>
        /// <returns>Numero de filas afectadas</returns>
        public int updatePersonaDAL(clsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();

            //Añadir datos al comando
            miComando.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = persona.id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.VarChar).Value = persona.fechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "UPDATE personas SET nombre=@nombre, apellidos=@apellidos, fechaNac=@fechaNac, direccion=@direccion, telefono=@telefono  WHERE IDPersona = @id";
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
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
                    string nombre = (string) miReader["nombre"];
                    string apellidos = (string)miReader["apellidos"];
                    DateTime fechaNac = (DateTime)miReader["fechaNac"];
                    string direccion = (string)miReader["direccion"];
                    string telefono = (string)miReader["telefono"];
                    res = new clsPersona(nombre, apellidos, id, fechaNac, direccion, telefono);
                }

                else
                {
                    res = new clsPersona();
                }

                

                

            }
            catch (Exception)
            {
                throw;
            }

            return res;
        }




        /// <summary>
        /// Borra una persona de la base de datos.
        /// </summary>
        /// <param name="id">Id de la persona.</param>
        /// <returns>Numero de filas afectadas</returns>
        public int deletePersonaDAL(int id)
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int res;

            //Añadir datos al comando
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                conexion = miConexion.getConnection();


                miComando.CommandText = "DELETE FROM personas WHERE IDPersona = @id";
                miComando.Connection = conexion;

                res = miComando.ExecuteNonQuery();
                

            }
            catch (Exception)
            {
                throw;
            }

            return res;
        }



    }
}
