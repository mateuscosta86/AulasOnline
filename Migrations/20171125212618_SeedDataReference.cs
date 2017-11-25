using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AulasOnline.Migrations
{
    public partial class SeedDataReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Materias (Nome) VALUES ('C#')");
            migrationBuilder.Sql("INSERT INTO Materias (Nome) VALUES ('Java')");
            migrationBuilder.Sql("INSERT INTO Materias (Nome) VALUES ('Python')");

            migrationBuilder.Sql("INSERT INTO Disciplina (Nome) VALUES ('Programação de Computadores')"); 
            
            migrationBuilder.Sql("INSERT INTO Curso (Nome, DataCriacao, Preco) VALUES ('Sistemas Para Internet', '2012-06-18T10:34:09', 149.9)"); 

            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId, DisciplinaId, CursoId) VALUES ('Variaveis em C#', 58, (SELECT Id FROM Materias WHERE Nome = 'C#'), (SELECT Id FROM Disciplina WHERE Nome = 'Programação de Computadores'), (SELECT Id FROM Curso WHERE Nome = 'Sistemas Para Internet'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId, DisciplinaId, CursoId) VALUES ('Condicionais em C#', 48, (SELECT Id FROM Materias WHERE Nome = 'C#'), (SELECT Id FROM Disciplina WHERE Nome = 'Programação de Computadores'), (SELECT Id FROM Curso WHERE Nome = 'Sistemas Para Internet'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId, DisciplinaId, CursoId) VALUES ('Loops em C#', 53, (SELECT Id FROM Materias WHERE Nome = 'C#'), (SELECT Id FROM Disciplina WHERE Nome = 'Programação de Computadores'), (SELECT Id FROM Curso WHERE Nome = 'Sistemas Para Internet'))");

            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId, DisciplinaId, CursoId) VALUES ('OOP em Java', 34, (SELECT Id FROM Materias WHERE Nome = 'Java'), (SELECT Id FROM Disciplina WHERE Nome = 'Programação de Computadores'), (SELECT Id FROM Curso WHERE Nome = 'Sistemas Para Internet'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId, DisciplinaId, CursoId) VALUES ('Herança em Java', 43, (SELECT Id FROM Materias WHERE Nome = 'Java'), (SELECT Id FROM Disciplina WHERE Nome = 'Programação de Computadores'), (SELECT Id FROM Curso WHERE Nome = 'Sistemas Para Internet'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId, DisciplinaId, CursoId) VALUES ('Poliformismo em Java', 31, (SELECT Id FROM Materias WHERE Nome = 'Java'), (SELECT Id FROM Disciplina WHERE Nome = 'Programação de Computadores'), (SELECT Id FROM Curso WHERE Nome = 'Sistemas Para Internet'))");

            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId, DisciplinaId, CursoId) VALUES ('Python 2 Vs Python 3', 51, (SELECT Id FROM Materias WHERE Nome = 'Python'), (SELECT Id FROM Disciplina WHERE Nome = 'Programação de Computadores'), (SELECT Id FROM Curso WHERE Nome = 'Sistemas Para Internet'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId, DisciplinaId, CursoId) VALUES ('Executando scripts no console', 120, (SELECT Id FROM Materias WHERE Nome = 'Python'), (SELECT Id FROM Disciplina WHERE Nome = 'Programação de Computadores'), (SELECT Id FROM Curso WHERE Nome = 'Sistemas Para Internet'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Aulas WHERE MateriaId IN (SELECT Id FROM Materias WHERE Nome IN ('C#', 'Java', 'Python'))");
            migrationBuilder.Sql("DELETE FROM Disciplina WHERE Nome = 'Programação de Computadores'");
            migrationBuilder.Sql("DELETE FROM Materias WHERE Nome IN ('C#', 'Java', 'Python')");
            migrationBuilder.Sql("DELETE FROM Curso WHERE Nome = 'Sistemas Para Internet'");
        }
    }
}
