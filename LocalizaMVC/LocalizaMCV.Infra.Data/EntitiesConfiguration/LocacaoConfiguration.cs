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
    public class LocacaoConfiguration : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.TotalHoras).IsRequired();
            builder.Property(p => p.ValorTotal).HasPrecision(10, 2).IsRequired();

            builder.HasOne(e => e.Veiculo).WithMany(e => e.Locacoes)
                .HasForeignKey(e => e.VeiculoId).IsRequired();

            builder.HasOne(e => e.Cliente).WithMany(e => e.Locacoes)
                .HasForeignKey(e => e.ClienteId).IsRequired();

            builder.HasOne(e => e.Operador).WithMany(e => e.Locacoes)
                .HasForeignKey(e => e.OperadorId);
        }
    }
}
