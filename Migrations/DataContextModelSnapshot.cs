﻿// <auto-generated />
using System;
using Api_Pedidos.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Pedidos.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api_Pedidos.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Empresa_Id")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Api_Pedidos.Models.Empresa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("created_at")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Api_Pedidos.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("cliente_id")
                        .HasColumnType("integer");

                    b.Property<int>("created_at")
                        .HasColumnType("integer");

                    b.Property<int>("empresa_id")
                        .HasColumnType("integer");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<int>("reponsavel_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Api_Pedidos.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("boolean");

                    b.Property<int>("amount")
                        .HasColumnType("integer");

                    b.Property<int>("create_at")
                        .HasColumnType("integer");

                    b.Property<int>("empresa_id")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Api_Pedidos.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Empresa_id")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Api_Pedidos.Models.ViewModel.ProdutoView", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Pedidoid")
                        .HasColumnType("integer");

                    b.Property<int>("amount")
                        .HasColumnType("integer");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.HasIndex("Pedidoid");

                    b.ToTable("ProdutoView");
                });

            modelBuilder.Entity("Api_Pedidos.Models.ViewModel.ProdutoView", b =>
                {
                    b.HasOne("Api_Pedidos.Models.Pedido", null)
                        .WithMany("product")
                        .HasForeignKey("Pedidoid");
                });

            modelBuilder.Entity("Api_Pedidos.Models.Pedido", b =>
                {
                    b.Navigation("product");
                });
#pragma warning restore 612, 618
        }
    }
}
