using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AulasOnline.Migrations
{
    public partial class FixedAulaDomainModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Materias_MateriaId",
                table: "Aulas");

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "Aulas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Materias_MateriaId",
                table: "Aulas",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Materias_MateriaId",
                table: "Aulas");

            migrationBuilder.AlterColumn<int>(
                name: "MateriaId",
                table: "Aulas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Materias_MateriaId",
                table: "Aulas",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
