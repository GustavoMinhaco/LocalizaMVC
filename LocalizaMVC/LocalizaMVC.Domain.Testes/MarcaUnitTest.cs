using FluentAssertions;
using LocalizaMVC.Domain.Entidades;
using System;
using Xunit;

namespace LocalizaMVC.Domain.Testes
{
    public class MarcaUnitTest
    {
        [Fact(DisplayName = "Create Marca With Valid State")]
        public void CreateMarca_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => 
            {
                Marca marca = new("Nome da marca");
            };
            action.Should()
                .NotThrow<LocalizaMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => 
            {
                Marca marca = new(-1, "Category Name ");
            };
            action.Should()
                .Throw<LocalizaMVC.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Campo obrigatório Id inválido!");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => 
            { 
                Marca marca = new(1, "C"); 
            }; 
            action.Should()
                .Throw<LocalizaMVC.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Campo obrigatório descricao inválido, muito curto, mínimo 2 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () =>
            {
                Marca marca = new(1, "");
            };
            action.Should()
                .Throw<LocalizaMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Campo obrigatório descricao inválido!");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () =>
            {
                Marca marca = new(1, null);
            };
            action.Should()
                .Throw<LocalizaMVC.Domain.Validation.DomainExceptionValidation>();
        }


    }
}
