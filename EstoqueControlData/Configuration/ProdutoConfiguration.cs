using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueControlData.Configuration
{
    public class ProdutoConfiguration : _BaseConfiguration<Produto>
    {
        public override void ConcreteConfigure(EntityTypeBuilder<Produto> builder)
        {
            
            builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);

            
            builder.Property(p => p.Descricao)
            .IsRequired()
            .HasColumnType("varchar(240)")
            .HasMaxLength(240);

            builder.Property(p => p.ValorUnitario)
            .IsRequired();

            builder.Property(p => p.QuantidadeEmEstoque)
            .IsRequired()
            .HasColumnType("int");

            builder.HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoriaId);


        }
    }
}