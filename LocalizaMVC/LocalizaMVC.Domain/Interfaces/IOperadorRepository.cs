using LocalizaMVC.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Interfaces
{
    public interface IOperadorRepository
    {
        Task<IEnumerable<Operador>> GetOperadoresAsync();
        Task<Operador> GetByIdAsync(int? id);

        Task<Operador> CreateAsync(Operador operador);
        Task<Operador> UpdateAsync(Operador operador);
    }
}
