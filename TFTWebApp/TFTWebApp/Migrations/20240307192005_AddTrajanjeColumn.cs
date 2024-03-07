using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFTWebApp.Migrations
{
    public partial class AddTrajanjeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Trajanje",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Trajanje",
                table: "Films");
        }
    }
}
