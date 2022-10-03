using LocalizaMVC.Application.DTOs;
using LocalizaMVC.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizaMVC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await _clienteService.GetClientes();
            if (clientes == null)
                return NotFound("Clientes não encontrados!");

            return Ok(clientes);
        }

        [HttpGet("{id:int}", Name = "GetCliente")]
        public async Task<ActionResult<ClienteDTO>> GetById(int id)
        {
            var cliente = await _clienteService.GetById(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado!");

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDto)
        {
            if (clienteDto == null)
                return BadRequest("Dados inválidos");

            await _clienteService.Add(clienteDto);
            return new CreatedAtRouteResult("GetCliente", new { id = clienteDto.Id}, 
                clienteDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteDTO clienteDto)
        {
            if (id != clienteDto.Id)
                return BadRequest();

            if (clienteDto == null)
                return BadRequest();

            await _clienteService.Update(clienteDto);

            return Ok(clienteDto);
        }
    }
}
