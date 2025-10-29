using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OakRoom.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addNewPropToDishClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "kiloCalories",
                table: "Dishes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "kiloCalories",
                table: "Dishes");
        }
    }
}
