using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Idao
{
    public interface IClienteDao
    {
        IEnumerable<Cliente> getAll();
        Cliente create(Cliente cliente);
        Cliente getById(int id);
        bool update(Cliente cliente);
        bool delete(Cliente cliente);
    }



}
