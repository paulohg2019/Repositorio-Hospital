using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.Convenios
{
    public partial class hospitaldb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    ConvID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<long>(nullable: false),
                    CNPJ = table.Column<long>(nullable: false),
                    desconto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.ConvID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convenios");
        }
    }
}
