using LocalizaMVC.Domain.Enums;
using LocalizaMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Entidades
{
    public sealed class Veiculo : Entity
    {
        public string Placa { get; private set; }

        public int Ano { get; private set; }

        public decimal ValorHora { get; private set; }

        public Combustivel Combustivel { get; private set; }

        public Categoria Categoria { get; set; }

        public decimal LimitePortaMalas { get; private set; }


        public Veiculo(string placa, int ano, decimal valorHora, Combustivel combustivel, 
            Categoria categoria, decimal limitePortaMalas)
        {
            ValidationDomain(placa, ano, valorHora, combustivel, categoria, limitePortaMalas);
        }

        public Veiculo(int id, string placa, int ano, decimal valorHora, Combustivel combustivel,
            Categoria categoria, decimal limitePortaMalas)
        {
            DomainExceptionValidation.When(id < 0, "Campo obrigatório Id inválido!");
            Id = id;
            ValidationDomain(placa, ano, valorHora, combustivel, categoria, limitePortaMalas);
        }

        public void Update(string placa, int ano, decimal valorHora, Combustivel combustivel,
            Categoria categoria, decimal limitePortaMalas, int marcaId, int modeloId)
        {
            ValidationDomain(placa, ano, valorHora, combustivel, categoria, limitePortaMalas);
            MarcaId = marcaId;
            ModeloId = modeloId;
        }

        public void ValidationDomain(string placa, int ano, decimal valorHora, Combustivel combustivel,
            Categoria categoria, decimal limitePortaMalas)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(placa), "Campo obrigatório Placa inválido");
            DomainExceptionValidation.When(placa.Length != 7, "Campo obrigatório Placa inválido, tamanho deve ser de 7 caracteres.");

            DomainExceptionValidation.When(ano < 1700, "Campo obrigatório Ano inválido");

            DomainExceptionValidation.When(valorHora < 0, "Campo obrigatório ValorHora inválido!");
            DomainExceptionValidation.When(limitePortaMalas < 0, "Campo obrigatório LimitePortaMalas inválido!");

            Placa = placa;
            Ano = ano;
            ValorHora = valorHora;
            Combustivel = combustivel;
            Categoria = categoria;
            LimitePortaMalas = limitePortaMalas;
        }


        // chave extrangeira para relacionar Marca
        public int MarcaId { get; set; }
        // propriedade que relaciona Veiculo com o Marca
        public Marca Marca { get; set; }

        // chave extrangeira para relacionar Modelo
        public int ModeloId { get; set; }
        // propriedade que relaciona Veiculo com o Modelo
        public Modelo Modelo { get; set; }


        public ICollection<Locacao> Locacoes { get; set; }
    }

}
