using MediatR;
using LocalizaMVC.Domain.Entidades;

namespace LocalizaMVC.Application.Locacoes.Commands
{
    public abstract class LocacaoCommand : IRequest<Locacao>
    {
        public int TotalHoras { get; private set; }
        public decimal ValorTotal { get; private set; }

        public int VeiculoId { get; set; }
        public int ClienteId { get; set; }
        public int OperadorId { get; set; }
    }
}
