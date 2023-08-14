using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueControlData.Configuration
{
    public class CategoriaConfiguration : _BaseConfiguration<Categoria>
    {
        public override void ConcreteConfigure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);
        }
    }
}