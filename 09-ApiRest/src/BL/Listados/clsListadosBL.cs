using DAL.Listados;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.Listados
{
    public class clsListadosBL
    {
        public List<clsPersona> getListadoPersonaBL()
        {
            try
            {
                List<clsPersona> lista = new List<clsPersona>();
                clsListadosDAL milista = new clsListadosDAL();

                lista = milista.getListadoPersonasDAL();

                return lista;
            }
            catch(Exception e)
            {
                throw e;
            }  
                      
        }
    }
}
