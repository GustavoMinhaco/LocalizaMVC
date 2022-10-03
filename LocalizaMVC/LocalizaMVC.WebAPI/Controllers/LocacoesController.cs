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
    public class LocacoesController : ControllerBase
    {
        private readonly ILocacaoService _locacaoService;
        public LocacoesController(ILocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocacaoDTO>>> Get()
        {
            var locacoes = await _locacaoService.GetLocacoes();
            if (locacoes == null)
                return NotFound("Locacoes não encontrados!");

            return Ok(locacoes);
        }

        [HttpGet("{id:int}", Name = "GetLocacao")]

        public async Task<ActionResult<LocacaoDTO>> GetById(int id)
        {
            var locacao = await _locacaoService.GetById(id);
            if (locacao == null)
                return NotFound("Locacao não encontrado!");

            return Ok(locacao);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LocacaoDTO locacaoDto)
        {
            if (locacaoDto == null)
                return BadRequest("Dados inválidos");

            await _locacaoService.Add(locacaoDto);
            return new CreatedAtRouteResult("GetLocacao", new { id = locacaoDto.Id}, 
                locacaoDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] LocacaoDTO locacaoDto)
        {
            if (id != locacaoDto.Id)
                return BadRequest();

            if (locacaoDto == null)
                return BadRequest();

            await _locacaoService.Update(locacaoDto);

            return Ok(locacaoDto);
        }
    }
}
