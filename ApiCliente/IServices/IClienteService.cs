using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPedidosLibros.IServices
{
    public interface IClienteService
    {
        public IEnumerable<Cliente> getAll();
        public Cliente create(Cliente cliente);
        public Cliente getById(int id);
        public bool update(Cliente cliente);
        public  bool delete(Cliente cliente);
    }
}
