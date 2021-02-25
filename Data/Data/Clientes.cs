using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data
{
    public static class Clientes
    {
        public static List<Cliente>  obtener()
        {
            Cliente c1 = new Cliente();
            c1.Id = 1;
            c1.Nombre = "Juan Perez";

            clientes.Add(c1);

            return clientes;
        }

        public static List<Cliente> clientes = new List<Cliente>
        {
            
        };
    }
}
