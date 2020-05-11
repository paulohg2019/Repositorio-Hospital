using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.Despesas
{
    public partial class hospitaldb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    DespID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Aluguel = table.Column<double>(nullable: false),
                    Agua = table.Column<double>(nullable: false),
                    Luz = table.Column<double>(nullable: false),
                    Telefone = table.Column<double>(nullable: false),
                    Internet = table.Column<double>(nullable: false),
                    Pagamentos = table.Column<double>(nullable: false),
                    Materiais = table.Column<double>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.DespID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");
        }
    }
}
