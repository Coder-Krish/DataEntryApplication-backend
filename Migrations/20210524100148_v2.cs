using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntryApplication.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDistrict_tblCountry_Countryid",
                table: "tblDistrict");

            migrationBuilder.RenameColumn(
                name: "Countryid",
                table: "tblDistrict",
                newName: "countryId");

            migrationBuilder.RenameIndex(
                name: "IX_tblDistrict_Countryid",
                table: "tblDistrict",
                newName: "IX_tblDistrict_countryId");

            migrationBuilder.AlterColumn<int>(
                name: "countryId",
                table: "tblDistrict",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblDistrict_tblCountry_countryId",
                table: "tblDistrict",
                column: "countryId",
                principalTable: "tblCountry",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDistrict_tblCountry_countryId",
                table: "tblDistrict");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "tblDistrict",
                newName: "Countryid");

            migrationBuilder.RenameIndex(
                name: "IX_tblDistrict_countryId",
                table: "tblDistrict",
                newName: "IX_tblDistrict_Countryid");

            migrationBuilder.AlterColumn<int>(
                name: "Countryid",
                table: "tblDistrict",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tblDistrict_tblCountry_Countryid",
                table: "tblDistrict",
                column: "Countryid",
                principalTable: "tblCountry",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
