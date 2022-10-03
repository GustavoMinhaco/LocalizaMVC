using LocalizaMVC.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Infra.Data.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Aniversario).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Cep).HasMaxLength(9).IsRequired();
            builder.Property(p => p.Logradouro).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Numero).IsRequired();
            builder.Property(p => p.Complemento).HasMaxLength(50);
            builder.Property(p => p.Cidade).HasMaxLength(120).IsRequired();
            builder.Property(p => p.Estado).HasMaxLength(2).IsRequired();
        }
    }
}
