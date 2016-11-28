using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_ET
{
    public  class clsProducto
    {

        //atributos
        public int id { get; set; }
        public string nombreProducto { get; set; }
        public int idCategoria { get; set; }
        

        //constructores
        public clsProducto()
        {
            id = 0;
            nombreProducto = "";
            idCategoria = 0;
        }

        public clsProducto(int id, string nombreProducto, int idCategoria)
        {
            this.id = id;
            this.nombreProducto = nombreProducto;
            this.idCategoria = idCategoria;  
        }
    }
}
