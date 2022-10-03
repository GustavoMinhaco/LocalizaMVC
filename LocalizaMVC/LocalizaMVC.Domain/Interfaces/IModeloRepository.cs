using LocalizaMVC.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Interfaces
{
    public interface IModeloRepository
    {
        Task<IEnumerable<Modelo>> GetModelosAsync();
        Task<Modelo> GetByIdAsync(int? id);

        Task<Modelo> CreateAsync(Modelo modelo);
        Task<Modelo> UpdateAsync(Modelo modelo);
    }
}
