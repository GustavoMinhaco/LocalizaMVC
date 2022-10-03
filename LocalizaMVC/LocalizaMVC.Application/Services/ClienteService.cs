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
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            var clientesEntity = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientesEntity);
        }

        public async Task<ClienteDTO> GetById(int? id)
        {
            var clienteEntity = await _clienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task Add(ClienteDTO clienteDto)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDto);
            await _clienteRepository.CreateAsync(clienteEntity);
        }

        public async Task Update(ClienteDTO clienteDto)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDto);
            await _clienteRepository.UpdateAsync(clienteEntity);
        }
    }
}
