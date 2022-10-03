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
    public class OperadorConfiguration : IEntityTypeConfiguration<Operador>
    {
        public void Configure(EntityTypeBuilder<Operador> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Matricula).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();
        }
    }
}
