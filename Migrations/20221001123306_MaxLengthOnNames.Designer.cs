﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20221001123306_MaxLengthOnNames")]
    partial class MaxLengthOnNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Models.Autor", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AuthorID");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Library.Models.Livro", b =>
                {
                    b.Property<int>("LivroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlunoUsrID")
                        .HasColumnType("int");

                    b.Property<int>("AutorID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FimEmprestimo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InicioEmprestimo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UsrID")
                        .HasColumnType("int");

                    b.HasKey("LivroID");

                    b.HasIndex("AlunoUsrID");

                    b.HasIndex("AutorID")
                        .IsUnique();

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("Library.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsrID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aluno")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UsrID");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Library.Models.Livro", b =>
                {
                    b.HasOne("Library.Models.UsuarioModel", "Aluno")
                        .WithMany("Livros")
                        .HasForeignKey("AlunoUsrID");

                    b.HasOne("Library.Models.Autor", "Autor")
                        .WithOne("Livro")
                        .HasForeignKey("Library.Models.Livro", "AutorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("Library.Models.Autor", b =>
                {
                    b.Navigation("Livro");
                });

            modelBuilder.Entity("Library.Models.UsuarioModel", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
