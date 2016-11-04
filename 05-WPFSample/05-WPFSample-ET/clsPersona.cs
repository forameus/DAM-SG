using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _05_WPFSample_ET
{
    /// <summary>
    /// PERSONA
    /// </summary>

    public class clsPersona
    {
        //atributos
        [Required]
        public string nombre {get; set;}
        [Required]
        public string apellidos{get; set;}
        public int id { get; set; }
        public DateTime fechaNac { get; set;}
        public string direccion { get; set; }
        public string telefono { get; set; }

        //constructores
        public clsPersona()
        {
            id = 0;
            nombre = "";
            apellidos = "";
            fechaNac = new DateTime();
            direccion = "";
            telefono = "";
        }

        public clsPersona(string nombre, string apellidos, int id, DateTime fechaNac, string direccion, string telefono)
        {
            this.id = id;            
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }

    }
}
