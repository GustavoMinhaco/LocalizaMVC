using LocalizaMVC.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Locacoes.Queries
{
    public class GetLocacoesQuery : IRequest<IEnumerable<Locacao>>
    {
    }
}
