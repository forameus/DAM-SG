using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_ET;


namespace WPFSample_DAL
{
    public class clsListadosDAL
    {
        public List<clsPersona> getListadoPersonasDAL()
        {
            List<clsPersona> listadoPersonas;
            clsMyConnection miConexion;

            listadoPersonas = new List<clsPersona>();

            miConexion = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader lector;

            clsPersona oPersona;

            try
            {
                conexion = miConexion.getConnection();
                command.CommandText = "SELECT * FROM personas";
                command.Connection = conexion;
                lector = command.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.id = (int)lector["IDPersona"];
                        oPersona.nombre = (string)lector["nombre"];
                        oPersona.apellidos = (string)lector["apellidos"];
                        oPersona.fechaNac = (DateTime)lector["fechaNac"];
                        oPersona.direccion = (string)lector["direccion"];
                        oPersona.telefono = (string)lector["telefono"];
                        listadoPersonas.Add(oPersona);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return listadoPersonas;
        }



    }
}
