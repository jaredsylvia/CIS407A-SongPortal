using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SongManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Artist = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Our amps go to 11, 11 is louder than 10.", "Rock and Roll" },
                    { 2, "Like life, best when improvised.", "Jazz" },
                    { 3, "I got 99 problems, but this genre ain't one.", "Hip Hop" },
                    { 4, "This machine kills fascists.", "Country" },
                    { 5, "Anti-Reagan, pro youth.", "Punk" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Artist", "GenreId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Queen", 1, new DateTime(1975, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bohemian Rhapsody" },
                    { 2, "Dizzy Gillespie", 2, new DateTime(1947, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manteca" },
                    { 3, "Tupac", 3, new DateTime(1995, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "California Love" },
                    { 4, "Hank3", 4, new DateTime(2006, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Country Heroes" },
                    { 5, "Rancid", 5, new DateTime(1995, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maxwell Murder" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
