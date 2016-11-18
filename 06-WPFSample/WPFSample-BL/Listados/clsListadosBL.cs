using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_BL.Listados;
using WPFSample_ET;
using WPFSample_DAL;

namespace WPFSample_BL.Listados
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
