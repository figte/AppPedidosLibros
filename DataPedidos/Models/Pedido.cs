using System;
using System.Collections.Generic;
using System.Text;

namespace DataPedidos.Models
{
   public class Pedido
    {
        public int Id { set; get; }
        public int IdCliente { set; get; }
        public int IdBook { set; get; }
        public string BookTitle { set; get; }
        public string BookAuthor { set; get; }
        public string Publisher { set; get; }



    }
}
