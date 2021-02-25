using DataPedidos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPedidos.IDao
{
    public interface IPedidoDao
    {
        IEnumerable<Pedido> getAll();

        Pedido create(Pedido pedido);

        Pedido getById(int id);

        bool update(Pedido pedido);

        bool delete(Pedido pedido);
    }
}
