using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.Financeiro
{
    public partial class hospitaldb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Financeiro",
                columns: table => new
                {
                    FinancID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Medico = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Convenio = table.Column<string>(nullable: true),
                    Desconto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiro", x => x.FinancID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financeiro");
        }
    }
}
