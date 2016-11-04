using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _03_ViewDataYViewBag.Models
{
    public class clsPersona
    {
        //atributos
        public string nombre {get; set;}
        public string apellidos{get; set;}
        public int edad {get; set;}

        //constructores
        public clsPersona()
        {
            this.nombre = "";
            this.apellidos = "";
            this.edad = 0;
        }

        public clsPersona(string nombre, string apellidos, int edad)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }

    }
}
