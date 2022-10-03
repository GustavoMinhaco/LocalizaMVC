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
    public class OperadorRepository : IOperadorRepository
    {
        ApplicationDbContext _operadorContext;
        public OperadorRepository(ApplicationDbContext context)
        {
            _operadorContext = context;
        }

        public async Task<Operador> CreateAsync(Operador operador)
        {
            _operadorContext.Add(operador);
            await _operadorContext.SaveChangesAsync();
            return operador;
        }

        public async Task<Operador> GetByIdAsync(int? id)
        {
            return await _operadorContext.Operadores.FindAsync(id);
        }

        public async Task<IEnumerable<Operador>> GetOperadoresAsync()
        {
            return await _operadorContext.Operadores.ToListAsync();
        }


        public async Task<Operador> UpdateAsync(Operador operador)
        {
            _operadorContext.Update(operador);
            await _operadorContext.SaveChangesAsync();
            return operador;
        }
    }
}
