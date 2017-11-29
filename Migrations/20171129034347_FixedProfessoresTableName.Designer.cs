﻿// <auto-generated />
using AulasOnline.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AulasOnline.Migrations
{
    [DbContext(typeof(AulasOnlineDbContext))]
    [Migration("20171129034347_FixedProfessoresTableName")]
    partial class FixedProfessoresTableName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AulasOnline.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Anual");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("AulasOnline.Models.Aula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CursoId");

                    b.Property<int>("DisciplinaId");

                    b.Property<int>("Duracao");

                    b.Property<int>("MateriaId");

                    b.Property<int>("ProfessorId");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("MateriaId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("AulasOnline.Models.Compra", b =>
                {
                    b.Property<int>("AlunoId");

                    b.Property<int>("CursoId");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("AulasOnline.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("AulasOnline.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("AulasOnline.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("AulasOnline.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("AulasOnline.Models.Aula", b =>
                {
                    b.HasOne("AulasOnline.Models.Curso", "Curso")
                        .WithMany("Aulas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AulasOnline.Models.Disciplina", "Disciplina")
                        .WithMany("Aulas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AulasOnline.Models.Materia", "Materia")
                        .WithMany("Aulas")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AulasOnline.Models.Professor", "Professor")
                        .WithMany("Aulas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AulasOnline.Models.Compra", b =>
                {
                    b.HasOne("AulasOnline.Models.Aluno", "Aluno")
                        .WithMany("Compras")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AulasOnline.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}