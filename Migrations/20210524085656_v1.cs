using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntryApplication.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCountry",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblLabor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    laborName = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    district = table.Column<string>(nullable: true),
                    taskDetail = table.Column<string>(nullable: true),
                    workHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLabor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblDistrict",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(nullable: true),
                    laborRatePerHour = table.Column<float>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    Countryid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDistrict", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblDistrict_tblCountry_Countryid",
                        column: x => x.Countryid,
                        principalTable: "tblCountry",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblDistrict_Countryid",
                table: "tblDistrict",
                column: "Countryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblDistrict");

            migrationBuilder.DropTable(
                name: "tblLabor");

            migrationBuilder.DropTable(
                name: "tblCountry");
        }
    }
}
