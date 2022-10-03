using AutoMapper;
using LocalizaMVC.Application.DTOs;
using LocalizaMVC.Application.Interfaces;
using LocalizaMVC.Domain.Entidades;
using LocalizaMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Services
{
    public class OperadorService : IOperadorService
    {
        private readonly IOperadorRepository _operadorRepository;
        private readonly IMapper _mapper;

        public OperadorService(IOperadorRepository operadorRepository, IMapper mapper)
        {
            _operadorRepository = operadorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OperadorDTO>> GetOperadores()
        {
            var operadoresEntity = await _operadorRepository.GetOperadoresAsync();
            return _mapper.Map<IEnumerable<OperadorDTO>>(operadoresEntity);
        }

        public async Task<OperadorDTO> GetById(int? id)
        {
            var operadorEntity = await _operadorRepository.GetByIdAsync(id);
            return _mapper.Map<OperadorDTO>(operadorEntity);
        }

        public async Task Add(OperadorDTO operadorDto)
        {
            var operadorEntity = _mapper.Map<Operador>(operadorDto);
            await _operadorRepository.CreateAsync(operadorEntity);
        }

        public async Task Update(OperadorDTO operadorDto)
        {
            var operadorEntity = _mapper.Map<Operador>(operadorDto);
            await _operadorRepository.UpdateAsync(operadorEntity);
        }
    }
}
