using ApiPedidos.IService;
using DataPedidos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPedidos.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoApiController : ControllerBase
    {
        IPedidoService _service;

        public PedidoApiController(IPedidoService service) {
            _service = service;
        }

        // GET: api/<PedidoApiController>
        [HttpGet]
        public IEnumerable<Pedido> Get()
        {
            return _service.getAll();
        }

        // GET api/<PedidoApiController>/5
        [HttpGet("{id}")]
        public Pedido Get(int id)
        {
            return _service.getById(id);
        }

        // POST api/<PedidoApiController>
        [HttpPost]
        public Pedido Post([FromBody] Pedido value)
        {
            return _service.create(value);
        }

        // PUT api/<PedidoApiController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Pedido value)
        {
            return _service.update(value);
        }

        // DELETE api/<PedidoApiController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Pedido p = _service.getById(id);
            return _service.delete(p);
        }
    }
}
