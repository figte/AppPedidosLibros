using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Cliente
    {
        //modelo para tabla cliente

        public int Id { set; get; }
        public String Nombre{ set; get; }
        public String Apellidos { set; get; }
        public DateTime FechaNacimiento { set; get; }
        public String Direccion { set; get; }
        public String Telefono { set; get; }
        public String Email { set; get; }

        

    }
}
