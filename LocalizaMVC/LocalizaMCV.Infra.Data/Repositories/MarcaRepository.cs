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
    public class MarcaRepository : IMarcaRepository
    {
        ApplicationDbContext _marcaContext;
        public MarcaRepository(ApplicationDbContext context)
        {
            _marcaContext = context;
        }

        public async Task<Marca> CreateAsync(Marca marca)
        {
            _marcaContext.Add(marca);
            await _marcaContext.SaveChangesAsync();
            return marca;
        }

        public async Task<Marca> GetByIdAsync(int? id)
        {
            return await _marcaContext.Marcas.FindAsync(id);
        }

        public async Task<IEnumerable<Marca>> GetMarcasAsync()
        {
            return await _marcaContext.Marcas.ToListAsync();
        }

        public async Task<Marca> RemoveAsync(Marca marca)
        {
            _marcaContext.Remove(marca);
            await _marcaContext.SaveChangesAsync();
            return marca;
        }

        public async Task<Marca> UpdateAsync(Marca marca)
        {
            _marcaContext.Update(marca);
            await _marcaContext.SaveChangesAsync();
            return marca;
        }
    }
}
