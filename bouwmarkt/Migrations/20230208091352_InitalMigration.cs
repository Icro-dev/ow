using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bouwmarktAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vestigingen",
                columns: table => new
                {
                    Vestigingsnummer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VestigingsNaam = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Plaats = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Telefoonnumer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vestigingen", x => x.Vestigingsnummer);
                });

            migrationBuilder.CreateTable(
                name: "Koopzondagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vestigingsnummer = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTijd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindTijd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Koopzondagen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Koopzondagen_Vestigingen_Vestigingsnummer",
                        column: x => x.Vestigingsnummer,
                        principalTable: "Vestigingen",
                        principalColumn: "Vestigingsnummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Koopzondagen_Vestigingsnummer",
                table: "Koopzondagen",
                column: "Vestigingsnummer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Koopzondagen");

            migrationBuilder.DropTable(
                name: "Vestigingen");
        }
    }
}
