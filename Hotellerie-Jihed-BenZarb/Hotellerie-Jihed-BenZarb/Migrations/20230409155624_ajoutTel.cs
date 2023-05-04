using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotellerie_Jihed_BenZarb.Migrations
{
    /// <inheritdoc />
    public partial class ajoutTel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Hotels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Hotels");
        }
    }
}
