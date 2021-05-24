using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntryApplication.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "laborRatePerHour",
                table: "tblDistrict",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "laborRatePerHour",
                table: "tblDistrict",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
