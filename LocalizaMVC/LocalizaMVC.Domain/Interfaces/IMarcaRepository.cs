using LocalizaMVC.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Interfaces
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetMarcasAsync();
        Task<Marca> GetByIdAsync(int? id);

        Task<Marca> CreateAsync(Marca marca);
        Task<Marca> UpdateAsync(Marca marca);
    }
}
