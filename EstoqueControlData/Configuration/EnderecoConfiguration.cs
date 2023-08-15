
using EstoqueControlBusiness.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueControlData.Configuration
{
    public class EnderecoConfiguration : BaseConfiguration<Endereco>
    {
        public override void ConcreteConfigure(EntityTypeBuilder<Endereco> builder)
        {

            builder.ToTable("Enderecos");

            builder.Property(e => e.Rua)
            .IsRequired()
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);
            
            builder.Property(e => e.Numero)
            .IsRequired()
            .HasColumnType("varchar(5)")
            .HasMaxLength(5);
            
            builder.Property(e => e.Complemento)
            .HasColumnType("varchar(240)")
            .HasMaxLength(240);

            builder.Property(e => e.Bairro)
            .IsRequired()
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);

            builder.Property(e => e.Cidade)
            .IsRequired()
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);

            builder.Property(e => e.UF)
            .IsRequired()
            .HasColumnType("varchar(2)")
            .HasMaxLength(2)
            .IsFixedLength();

            builder.Property(e => e.CEP)
            .IsRequired()
            .HasColumnType("varchar(8)")
            .HasMaxLength(8)
            .IsFixedLength();

        }
    }
}