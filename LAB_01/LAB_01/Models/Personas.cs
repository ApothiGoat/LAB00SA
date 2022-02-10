using Lab_1.Help;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LAB_01.Models
{
    public class Personas
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellido{ get; set; }
        [MaxLength(11)]
        public string Telefono { get; set; }
        [MaxLength(50)]
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
