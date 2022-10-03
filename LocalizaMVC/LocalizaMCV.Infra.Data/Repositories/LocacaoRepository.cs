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
    public class LocacaoRepository : ILocacaoRepository
    {
        ApplicationDbContext _locacaoContext;
        public LocacaoRepository(ApplicationDbContext context)
        {
            _locacaoContext = context;
        }

        public async Task<Locacao> CreateAsync(Locacao locacao)
        {
            _locacaoContext.Add(locacao);
            await _locacaoContext.SaveChangesAsync();
            return locacao;
        }

        public async Task<Locacao> GetByIdAsync(int? id)
        {
            //return await _locacaoContext.Locacoes.FindAsync(id);
            return await _locacaoContext.Locacoes
                .Include(v => v.Veiculo)
                    .ThenInclude(c => c.Marca)
                .Include(v => v.Veiculo)
                    .ThenInclude(c => c.Modelo)
                .Include(c => c.Cliente)
                .Include(c => c.Operador)
            .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Locacao>> GetLocacoesAsync()
        {
            return await _locacaoContext.Locacoes.ToListAsync();
        }

        //public async Task<Locacao> GetAllAsync(int? id)
        //{
        //    // eager loading (carregamento adiantado)
        //    return await _locacaoContext.Locacoes
        //        .Include(v => v.Veiculo)
        //            .ThenInclude(c=> c.Marca)
        //        .Include(v => v.Veiculo)
        //            .ThenInclude(c => c.Modelo)
        //        .Include(c => c.Cliente)
        //        .Include(c => c.Operador)
        //    .SingleOrDefaultAsync(p => p.Id == id);
        //}

        public async Task<Locacao> UpdateAsync(Locacao locacao)
        {
            _locacaoContext.Update(locacao);
            await _locacaoContext.SaveChangesAsync();
            return locacao;
        }
    }
}
