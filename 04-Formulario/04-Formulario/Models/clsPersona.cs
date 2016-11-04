using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _04_Formulario.Models
{
    public class clsPersona
    {
        //atributos
        [Required]
        public string nombre {get; set;}
        [Required]
        public string apellidos{get; set;}
        public int id { get; set; }

        //constructores
        public clsPersona()
        {
            this.id = 1;
            this.nombre = "";
            this.apellidos = "";
        }

        public clsPersona(string nombre, string apellidos, int id)
        {
            this.id = id;
            
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

    }
}
