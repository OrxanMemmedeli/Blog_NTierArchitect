using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class changeAboutTableColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyLocation",
                table: "Abouts",
                newName: "Telephone");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Abouts",
                newName: "MyLocation");
        }
    }
}
