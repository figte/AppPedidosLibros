using ApiPedidosLibros.IServices;
using Data.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPedidosLibros.Controllers
{
    [Route("api/clientes")]
    [EnableCors("Todo")]
    [ApiController]
    public class ClienteApiController : ControllerBase
    {
        IClienteService _service;

       
        public ClienteApiController(IClienteService service) {
            _service = service;
        }

        // GET: api/<ClienteApiController>
        [HttpGet]
      
        public IEnumerable<Cliente> Get()
        {
            return  _service.getAll();
        }


        // GET api/<ClienteApiController>/5
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return _service.getById(id);
        }

        // POST api/<ClienteApiController>
        [HttpPost]
        public void Post([FromBody] Cliente value)
        {
            _service.create(value);
        }

        // PUT api/<ClienteApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente value)
        {
            _service.update(value);
        }

        // DELETE api/<ClienteApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Cliente c=_service.getById(id);
            _service.delete(c);
        }
    }
}
