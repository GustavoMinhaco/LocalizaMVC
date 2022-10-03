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
    public class VeiculoRepository : IVeiculoRepository
    {
        ApplicationDbContext _veiculoContext;
        public VeiculoRepository(ApplicationDbContext context)
        {
            _veiculoContext = context;
        }

        public async Task<Veiculo> CreateAsync(Veiculo veiculo)
        {
            _veiculoContext.Add(veiculo);
            await _veiculoContext.SaveChangesAsync();
            return veiculo;
        }

        public async Task<Veiculo> GetByIdAsync(int? id)
        {
            //return await _veiculoContext.Veiculos.FindAsync(id);

            return await _veiculoContext.Veiculos
                    .Include(c => c.Marca)
                    .Include(d => d.Modelo)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculosAsync()
        {
            return await _veiculoContext.Veiculos.ToListAsync();
        }

        //public async Task<Veiculo> GetVeiculoModeloMarcaAsync(int? id)
        //{
        //    return await _veiculoContext.Veiculos
        //            .Include(c => c.Marca)
        //            .Include(d => d.Modelo)
        //        .SingleOrDefaultAsync(p => p.Id == id);
        //}


        public async Task<Veiculo> UpdateAsync(Veiculo veiculo)
        {
            _veiculoContext.Update(veiculo);
            await _veiculoContext.SaveChangesAsync();
            return veiculo;
        }
    }
}
