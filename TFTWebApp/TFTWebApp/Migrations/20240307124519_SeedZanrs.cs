using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFTWebApp.Migrations
{
    public partial class SeedZanrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Zanrovi",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
