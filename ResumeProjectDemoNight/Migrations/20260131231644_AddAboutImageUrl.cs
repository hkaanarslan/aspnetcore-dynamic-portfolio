using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeProjectDemoNight.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutImageUrl",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutImageUrl",
                table: "Abouts");
        }
    }
}
