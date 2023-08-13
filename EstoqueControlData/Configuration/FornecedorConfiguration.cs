

using EstoqueControlBusiness.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueControlData.Configuration
{
    public class FornecedorConfiguration : _BaseConfiguration<Fornecedor>
    {
        public override void ConcreteConfigure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedores");

            builder.Property(f => f.Nome)
            .IsRequired()
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);

            builder.Property(f => f.Contato)
            .IsRequired()
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);

            builder.Property(f => f.CNPJ)
            .IsRequired()
            .HasColumnType("varchar(14)")
            .HasMaxLength(14)
            .IsFixedLength();
            
            builder.Property(f => f.Email)
            .IsRequired()
            .HasColumnType("varchar(80)")
            .HasMaxLength(80);
            
            builder.Property(f => f.Telefone)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasMaxLength(11);

            builder.HasOne(f => f.Endereco)
            .WithOne(e => e.Fornecedor)
            .HasForeignKey<Fornecedor>(e => e.EnderecoId);

            builder.HasMany(e => e.Produtos)
            .WithOne(p => p.Fornecedor)
            .HasForeignKey(p => p.FornecedorId);
        }
    }
}