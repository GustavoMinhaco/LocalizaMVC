using AutoMapper;
using LocalizaMVC.Application.DTOs;
using LocalizaMVC.Application.Interfaces;
using LocalizaMVC.Application.Locacoes.Commands;
using LocalizaMVC.Application.Locacoes.Queries;
using LocalizaMVC.Domain.Entidades;
using LocalizaMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Services
{
    public class LocacaoService : ILocacaoService
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LocacaoService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocacaoDTO>> GetLocacoes()
        {
            var locacoesQuery = new GetLocacoesQuery();

            if (locacoesQuery == null)
                throw new Exception("Entidade não pode ser carregada.");

            var result = await _mediator.Send(locacoesQuery);

            return _mapper.Map<IEnumerable<LocacaoDTO>>(result);
        }

        public async Task<LocacaoDTO> GetById(int? id)
        {
            var locacaoByIdQuery = new GetLocacaoByIdQuery(id.Value);

            if (locacaoByIdQuery == null)
                throw new Exception("Entidade não pode ser carregada.");

            var result = await _mediator.Send(locacaoByIdQuery);

            return _mapper.Map<LocacaoDTO>(result);
        }

        //public async Task<LocacaoDTO> GetAll(int? id)
        //{
        //    var locacaoByIdQuery = new GetLocacaoByIdQuery(id.Value);

        //    if (locacaoByIdQuery == null)
        //        throw new Exception("Entidade não pode ser carregada.");

        //    var result = await _mediator.Send(locacaoByIdQuery);

        //    return _mapper.Map<LocacaoDTO>(result);
        //}

        public async Task Add(LocacaoDTO locacaoDto)
        {
            var locacaoCreateCommand = _mapper.Map<LocacaoCreateCommand>(locacaoDto);
            await _mediator.Send(locacaoCreateCommand);
        }

        public async Task Update(LocacaoDTO locacaoDto)
        {
            var locacaoUpdateCommand = _mapper.Map<LocacaoUpdateCommand>(locacaoDto);
            await _mediator.Send(locacaoUpdateCommand);
        }

        //public async Task Remove(int id)
        //{
        //    var locacaoRemoveCommand = new LocacaoRemoveCommand(id);
        //    if(locacaoRemoveCommand == null)
        //        throw new Exception("Entidade não pode ser carregada.");

        //    await _mediator.Send(locacaoRemoveCommand);
        //}
    }
}
