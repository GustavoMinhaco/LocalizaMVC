using LocalizaMVC.Domain.Entidades;
using LocalizaMVC.Domain.Interfaces;
using LocalizaMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        ApplicationDbContext _clienteContext;

        public ClienteRepository(ApplicationDbContext context)
        {
            _clienteContext = context;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _clienteContext.Add(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> GetByIdAsync(int? id)
        {
            return await _clienteContext.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {
            return await _clienteContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            _clienteContext.Update(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }
    }
}
