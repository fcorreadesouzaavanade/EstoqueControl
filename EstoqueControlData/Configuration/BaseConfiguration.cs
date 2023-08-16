using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueControlBusiness.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueControlData.Configuration
{
    public abstract class BaseConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataRegistro)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("DATETIME");
            
            builder.Property(e => e.DataAtualizacao)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("DATETIME");
            
            ConcreteConfigure(builder);
        }

        public abstract void ConcreteConfigure(EntityTypeBuilder<T> builder);
    }
}