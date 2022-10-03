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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> Get()
        {
            var usuarios = await _usuarioService.GetUsuarios();
            if (usuarios == null)
                return NotFound("Usuarios não encontrados!");

            return Ok(usuarios);
        }


        [HttpGet("{id:int}", Name = "GetUsuario")]

        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null)
                return NotFound("Usuario não encontrado!");

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest("Dados inválidos");

            await _usuarioService.Add(usuarioDto);
            return new CreatedAtRouteResult("GetUsuario", new { id = usuarioDto.Id },
                usuarioDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
                return BadRequest();

            if (usuarioDto == null)
                return BadRequest();

            await _usuarioService.Update(usuarioDto);

            return Ok(usuarioDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UsuarioDTO>> Delete(int id)
        {
            var usuario = _usuarioService.GetById(id);
            if (usuario == null)
                return NotFound("Usuario não encontrado!");

            await _usuarioService.Remove(id);
            return Ok(usuario);
        }
    }
}
