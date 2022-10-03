using LocalizaMVC.Application.Locacoes.Commands;
using LocalizaMVC.Domain.Entidades;
using LocalizaMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalizaMVC.Application.Locacoes.Handlers
{
    public class LocacaoCreateCommandHandler : IRequestHandler<LocacaoCreateCommand, Locacao>
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoCreateCommandHandler(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }

        public async Task<Locacao> Handle(LocacaoCreateCommand request, CancellationToken cancellationToken)
        {
            var locacao = new Locacao(request.TotalHoras);

            if (locacao == null)
            {
                throw new ApplicationException("Erro ao criar entidade");
            }
            else
            {
                locacao.ClienteId = request.ClienteId;
                locacao.OperadorId = request.OperadorId;
                locacao.VeiculoId = request.VeiculoId;
                return await _locacaoRepository.CreateAsync(locacao);
            }
        }
    }
}
