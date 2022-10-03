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
    public class ModeloRepository : IModeloRepository
    {
        ApplicationDbContext _modeloContext;

        public ModeloRepository(ApplicationDbContext context)
        {
            _modeloContext = context;
        }

        public async Task<Modelo> CreateAsync(Modelo modelo)
        {
            _modeloContext.Add(modelo);
            await _modeloContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<Modelo> GetByIdAsync(int? id)
        {
            return await _modeloContext.Modelos.FindAsync(id);
        }

        public async Task<IEnumerable<Modelo>> GetModelosAsync()
        {
            return await _modeloContext.Modelos.ToListAsync();
        }

        public async Task<Modelo> UpdateAsync(Modelo modelo)
        {
            _modeloContext.Update(modelo);
            await _modeloContext.SaveChangesAsync();
            return modelo;
        }
    }
}
