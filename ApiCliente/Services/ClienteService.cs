using ApiPedidosLibros.IServices;
using Data.Idao;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPedidosLibros.Services
{
    public class ClienteService : IClienteService
    {

        IClienteDao _dao;

        public ClienteService(IClienteDao dao) {
            _dao = dao;
        }

        public Cliente create(Cliente cliente)
        {
          return  _dao.create(cliente);
        }

        public bool delete(Cliente cliente)
        {
           return _dao.delete(cliente);
        }

        public IEnumerable<Cliente> getAll()
        {
            return _dao.getAll();
        }

        public Cliente getById(int id)
        {
            return _dao.getById(id);
        }

        public bool update(Cliente cliente)
        {
            return _dao.update(cliente);
        }
    }
}
