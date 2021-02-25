using DataPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPedidos.IService
{
    public interface IPedidoService
    {
        IEnumerable<Pedido> getAll();

        Pedido create(Pedido pedido);

        Pedido getById(int id);

        bool update(Pedido pedido);

        bool delete(Pedido pedido);
    }
}
