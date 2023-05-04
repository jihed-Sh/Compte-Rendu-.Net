using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotellerie_Jihed_BenZarb.Migrations
{
    /// <inheritdoc />
    public partial class AjoutPaysHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pays",
                table: "Hotels",
                type: "longtext",
                defaultValue:"Tunisie",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pays",
                table: "Hotels");
        }
    }
}
