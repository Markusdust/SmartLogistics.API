using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLogistics.API.Migrations
{
    /// <inheritdoc />
    public partial class addLageplatz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lagerplatz",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProduktId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerplatz", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lagerplatz");
        }
    }
}
