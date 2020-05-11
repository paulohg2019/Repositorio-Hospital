using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.Funcionarios
{
    public partial class hospitaldb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CPF = table.Column<long>(nullable: false),
                    Entrada = table.Column<DateTime>(nullable: false),
                    Funcao = table.Column<string>(nullable: true),
                    Turno = table.Column<string>(nullable: true),
                    Salario = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
