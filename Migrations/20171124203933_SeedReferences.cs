using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AulasOnline.Migrations
{
    public partial class SeedReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Materias (Nome) VALUES ('C#')");
            migrationBuilder.Sql("INSERT INTO Materias (Nome) VALUES ('Java')");
            migrationBuilder.Sql("INSERT INTO Materias (Nome) VALUES ('Python')");

            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId) VALUES ('Variaveis em C#', 58, (SELECT Id FROM Materias WHERE Nome = 'C#'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId) VALUES ('Condicionais em C#', 48, (SELECT Id FROM Materias WHERE Nome = 'C#'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId) VALUES ('Loops em C#', 53, (SELECT Id FROM Materias WHERE Nome = 'C#'))");

            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId) VALUES ('OOP em Java', 34, (SELECT Id FROM Materias WHERE Nome = 'Java'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId) VALUES ('Herança em Java', 43, (SELECT Id FROM Materias WHERE Nome = 'Java'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId) VALUES ('Poliformismo em Java', 31, (SELECT Id FROM Materias WHERE Nome = 'Java'))");

            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId) VALUES ('Python 2 Vs Python 3', 51, (SELECT Id FROM Materias WHERE Nome = 'Python'))");
            migrationBuilder.Sql("INSERT INTO Aulas (Titulo, Duracao, MateriaId) VALUES ('Executando scripts no console', 120, (SELECT Id FROM Materias WHERE Nome = 'Python'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Materias WHERE Nome IN ('C#, 'Java', 'Python')");

        }
    }
}
