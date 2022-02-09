using LAB_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_1.Help
{
    public class Data
    {
        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }

        public List<Personas> personaslist = new List<Personas>
        {
            new Personas
            {
               Nombre = "Nombre",
               Apellido = "Apellido",
               Telefono = "Numero",
               Descripcion = "Descripcion"
            }
        };

    }
}
