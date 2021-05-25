using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntryApplication.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "districtId",
                table: "tblLabor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblLabor_districtId",
                table: "tblLabor",
                column: "districtId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblLabor_tblDistrict_districtId",
                table: "tblLabor",
                column: "districtId",
                principalTable: "tblDistrict",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblLabor_tblDistrict_districtId",
                table: "tblLabor");

            migrationBuilder.DropIndex(
                name: "IX_tblLabor_districtId",
                table: "tblLabor");

            migrationBuilder.DropColumn(
                name: "districtId",
                table: "tblLabor");
        }
    }
}
