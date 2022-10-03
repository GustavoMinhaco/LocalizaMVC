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
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.LimitePortaMalas).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Placa).HasMaxLength(7).IsRequired();

            builder.Property(p => p.Ano).IsRequired();
            builder.Property(p => p.ValorHora).HasPrecision(10,2).IsRequired();
            
            builder.Property(p => p.Combustivel).HasConversion<int>().IsRequired();
            builder.Property(p => p.Categoria).HasConversion<int>().IsRequired();

            builder.HasOne(e => e.Marca).WithMany(e => e.Veiculos)
                .HasForeignKey(e => e.MarcaId).IsRequired();

            builder.HasOne(e => e.Modelo).WithMany(e => e.Veiculos)
                .HasForeignKey(e => e.ModeloId).IsRequired();
        }
    }
}
