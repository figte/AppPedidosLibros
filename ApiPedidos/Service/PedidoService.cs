using ApiPedidos.IService;
using DataPedidos.IDao;
using DataPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPedidos.Service
{
    public class PedidoService : IPedidoService
    {
        IPedidoDao _dao;

        public PedidoService(IPedidoDao dao) {
            _dao = dao;
        }

        public Pedido create(Pedido pedido)
        {
            return _dao.create(pedido);
        }

        public bool delete(Pedido pedido)
        {
            return _dao.delete(pedido);
        }

        public IEnumerable<Pedido> getAll()
        {
            return _dao.getAll();
        }

        public Pedido getById(int id)
        {
            return _dao.getById(id);
        }

        public bool update(Pedido pedido)
        {
            return _dao.update(pedido);
        }
    }
}
