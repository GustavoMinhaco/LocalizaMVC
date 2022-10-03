using LocalizaMVC.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Locacoes.Commands
{
    public class LocacaoRemoveCommand : IRequest<Locacao>
    {
        public int Id { get; set; }
        public LocacaoRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
