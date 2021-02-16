﻿// <auto-generated />
using System;
using CodeTur.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeTur.Infra.Data.Migrations
{
    [DbContext(typeof(CodeTurContext))]
    [Migration("20210213205536_Banco Inicial Tabela Usuario")]
    partial class BancoInicialTabelaUsuario
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeTur.Dominio.Entidades.Comentario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdPacote")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sentimento")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("IdPacote");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("CodeTur.Dominio.Entidades.Pacote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("Text");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Pacotes");
                });

            modelBuilder.Entity("CodeTur.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CodeTur.Dominio.Entidades.Comentario", b =>
                {
                    b.HasOne("CodeTur.Dominio.Entidades.Pacote", "Pacote")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdPacote")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeTur.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacote");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CodeTur.Dominio.Entidades.Pacote", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("CodeTur.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
