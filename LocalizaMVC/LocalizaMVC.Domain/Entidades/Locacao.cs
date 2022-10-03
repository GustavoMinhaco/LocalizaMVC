using LocalizaMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Entidades
{
    public sealed class Locacao : Entity
    {
        public int TotalHoras { get; private set; }
        public decimal ValorTotal { get; private set; }

        public Locacao(int totalHoras)
        {
            ValidationDomain(totalHoras);
        }

        public Locacao(int id, int totalHoras)
        {
            DomainExceptionValidation.When(id < 0, "Campo obrigatório Id inválido!");
            Id = id;
            ValidationDomain(totalHoras);
        }

        public void Update(int totalHoras, int veiculoId, int clienteId, int? operadorId)
        {
            ValidationDomain(totalHoras);
            VeiculoId = veiculoId;
            ClienteId = clienteId;
            OperadorId = operadorId;
        }

        public void ValidationDomain(int totalHoras)
        {
            DomainExceptionValidation.When(totalHoras < 0, "Campo obrigatório TotalHoras inválido!");

            TotalHoras = totalHoras;
            CalcularValorTotal();
        }

        public void CalcularValorTotal()
        {
            if (Veiculo != null)
            {
                ValorTotal = TotalHoras * Veiculo.ValorHora;
            }
        }

        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int? OperadorId { get; set; }
        public Operador Operador { get; set; }
    }
}
