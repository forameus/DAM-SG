using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_ViewDataYViewBag.Models
{
    public class clsListado
    {
        public List<clsPersona> lista { get; set; }


        public clsListado()
        {
            lista = new List<clsPersona>();
            lista.Add(new clsPersona("Juanito", "Pérez", 20));
            lista.Add(new clsPersona("Pepe", "Perea", 20));
            lista.Add(new clsPersona("Francisco", "Franco", 20));
            lista.Add(new clsPersona("Adolfo", "Hitler", 20));
            lista.Add(new clsPersona("Carrero", "Blanco", 20));
            lista.Add(new clsPersona("Manuel", "Pérez", 20));
            lista.Add(new clsPersona("Eustaquio", "Gómez", 20));
            lista.Add(new clsPersona("Juan", "Pérez", 20));
        }
    }
}