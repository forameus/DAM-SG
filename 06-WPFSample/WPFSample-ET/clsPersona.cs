using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPFSample_ET
{
    /// <summary>
    /// PERSONA
    /// </summary>

    public class clsPersona
    {
        //atributos
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime fechaNac { get; set; }
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        [Display(Name = "Teléfono")]
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
