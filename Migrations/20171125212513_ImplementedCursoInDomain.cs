using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AulasOnline.Migrations
{
    public partial class ImplementedCursoInDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Aulas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "Aulas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_CursoId",
                table: "Aulas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_DisciplinaId",
                table: "Aulas",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Curso_CursoId",
                table: "Aulas",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Disciplina_DisciplinaId",
                table: "Aulas",
                column: "DisciplinaId",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Curso_CursoId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Disciplina_DisciplinaId",
                table: "Aulas");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Aulas_CursoId",
                table: "Aulas");

            migrationBuilder.DropIndex(
                name: "IX_Aulas_DisciplinaId",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "Aulas");
        }
    }
}
