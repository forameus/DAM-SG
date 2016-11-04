using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_Formulario.Models
{
    public class clsListado
    {
        public List<clsPersona> lista { get; set; }


        public clsListado()
        {
            lista = new List<clsPersona>();
            lista.Add(new clsPersona("Juanito", "Pérez", 1));
            lista.Add(new clsPersona("Pepe", "Perea", 2));
            lista.Add(new clsPersona("Francisco", "Franco", 3));
            lista.Add(new clsPersona("Adolfo", "Hitler", 4));
            lista.Add(new clsPersona("Carrero", "Blanco", 5));
            lista.Add(new clsPersona("Manuel", "Pérez", 6));
            lista.Add(new clsPersona("Eustaquio", "Gómez", 7));
            lista.Add(new clsPersona("Juan", "Pérez", 8));
        }
    }
}