using LocalizaMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Domain.Entidades
{
    public sealed class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Aniversario { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Cliente(string nome, string cpf, string aniversario, string cep, string logradouro, int numero,
            string complemento, string cidade, string estado)
        {
            ValidationDomain(nome, cpf, aniversario, cep, logradouro, numero, complemento, cidade, estado);
        }

        public Cliente(int id, string nome, string cpf, string aniversario, string cep, string logradouro, int numero,
            string complemento, string cidade, string estado)
        {
            DomainExceptionValidation.When(id < 0, "Campo obrigatório Id inválido!");
            Id = id;
            ValidationDomain(nome, cpf, aniversario, cep, logradouro, numero, complemento, cidade, estado);
        }

        public void Update(string nome, string cpf, string aniversario, string cep, string logradouro, int numero,
            string complemento, string cidade, string estado)
        {
            ValidationDomain(nome, cpf, aniversario, cep, logradouro, numero, complemento, cidade, estado);
        }

        private void ValidationDomain(string nome, string cpf, string aniversario, string cep, string logradouro, int numero,
            string complemento, string cidade, string estado)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Campo obrigatório Nome inválido");
            DomainExceptionValidation.When(nome.Length < 3, "Campo obrigatório Nome inválido, muito curto, minimo 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "Campo obrigatório CPF inválido");
            DomainExceptionValidation.When(!Validacao.IsCpf(cpf), "Campo obrigatório CPF inválido!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(aniversario), "Campo obrigatório aniversario inválido");
            DomainExceptionValidation.When(aniversario.Length < 5, "Campo obrigatório aniversario inválido, muito curto, minimo 5 characters");

            // ENDERECO
            DomainExceptionValidation.When(string.IsNullOrEmpty(cep), "Campo obrigatório CEP inválido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(logradouro), "Campo obrigatório Logradouro inválido!");
            DomainExceptionValidation.When(logradouro.Length < 3, "Campo obrigatório Logradouro inválido, muito curto, mínimo 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cidade), "Campo obrigatório Cidade inválido!");
            DomainExceptionValidation.When(cidade.Length < 3, "Campo obrigatório Cidade inválido, muito curto, mínimo 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(estado), "Campo obrigatório Estado inválido!");
            DomainExceptionValidation.When(estado.Length != 2, "Campo obrigatório Estado inválido, tamanho de 2 characters");

            DomainExceptionValidation.When(numero < 1, "Campo obrigatório Numero inválido!");

            if (!string.IsNullOrEmpty(complemento))
                DomainExceptionValidation.When(complemento.Length < 3,
                    "Campo Complemento inválido, muito curto, mínimo 3 characters");

            Nome = nome;
            Cpf = cpf.Replace(".", "").Replace("-", "");
            Aniversario = aniversario;

            //ENDERECO
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Numero = numero;
        }

        public ICollection<Locacao> Locacoes { get; set; }
    }
}
