using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "ProductsMachine",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Clock = table.Column<int>(nullable: false),
                    CostPerClock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsMachine", x => x.Name);
                    table.ForeignKey(
                        name: "ForeignKey_ProductsMachine_Products",
                        column: x => x.Name,
                        principalTable: "Products",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsMachine");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
