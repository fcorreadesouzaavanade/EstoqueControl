﻿// <auto-generated />
using System;
using EstoqueControlData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstoqueControlData.Migrations
{
    [DbContext(typeof(EstoqueControlDbContext))]
    [Migration("20230814024351_AjusteCampoValorUnitario_1")]
    partial class AjusteCampoValorUnitario_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("DataRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)")
                        .IsFixedLength();

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("DataRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .IsFixedLength();

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("DataRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Fornecedores", (string)null);
                });

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAtualizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("DataRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(240)
                        .HasColumnType("varchar(240)");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("QuantidadeEmEstoque")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasPrecision(2)
                        .HasColumnType("decimal(12,5)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Fornecedor", b =>
                {
                    b.HasOne("EstoqueControlBusiness.Modelos.Endereco", "Endereco")
                        .WithOne("Fornecedor")
                        .HasForeignKey("EstoqueControlBusiness.Modelos.Fornecedor", "EnderecoId")
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Produto", b =>
                {
                    b.HasOne("EstoqueControlBusiness.Modelos.Categoria", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("EstoqueControlBusiness.Modelos.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Endereco", b =>
                {
                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("EstoqueControlBusiness.Modelos.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
