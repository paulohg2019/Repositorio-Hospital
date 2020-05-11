using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.Exames
{
    public partial class hospitaldb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    ExameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePaciente = table.Column<string>(nullable: true),
                    ExameName = table.Column<string>(nullable: true),
                    NomeMedico = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.ExameID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exames");
        }
    }
}
