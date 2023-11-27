using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PG3302_Eksamen.Migrations
{
    /// <inheritdoc />
    public partial class rentedmediaadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentedMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Media = table.Column<string>(type: "TEXT", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false),
                    RentedBy = table.Column<string>(type: "TEXT", nullable: false),
                    RentedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsReturned = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedMedia", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentedMedia");
        }
    }
}
