using Lab_1.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB_01.Models
{
    public class Personas
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido{ get; set; }

        public string Telefono { get; set; }

        public string Descripcion { get; set; }

        public static bool Save(Personas model)
        {
            Data.Instance.personaslist.Add(model);
            return true;
        }

        public static bool Edit(Personas model)
        {
            throw new NotImplementedException();
        }


    }
}
