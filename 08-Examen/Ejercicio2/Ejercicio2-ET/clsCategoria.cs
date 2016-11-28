using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_ET
{
    public class clsCategoria { 

        //atributos
        public int id { get; set; }
        public string nombreCategoria { get; set; }
    


        //constructores
           public clsCategoria()
        {
            id = 0;
            nombreCategoria = ""; 
        }

        public clsCategoria(int id, string nombreCategoria)
        {
            this.id = id;
            this.nombreCategoria = nombreCategoria;            
        }
    }
}
