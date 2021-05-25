using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntryApplication.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropColumn(
                name: "country",
                table: "tblLabor");

            migrationBuilder.DropColumn(
                name: "district",
                table: "tblLabor");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.AddColumn<string>(
                name: "country",
                table: "tblLabor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "tblLabor",
                type: "nvarchar(max)",
                nullable: true);*/
        }
    }
}
