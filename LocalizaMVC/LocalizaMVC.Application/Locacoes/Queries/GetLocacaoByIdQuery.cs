using LocalizaMVC.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Locacoes.Queries
{
    public class GetLocacaoByIdQuery : IRequest<Locacao>
    {
        public int Id { get; set; }
        public GetLocacaoByIdQuery(int id)
        {
            Id = id;
        }
    }
}