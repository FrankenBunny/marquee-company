using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace marquee_backend.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRentableTagRentable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rentable_tag_rentable",
                columns: table => new
                {
                    rentable_tag_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rentable_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_rentable_tag_id",
                        column: x => x.rentable_tag_id,
                        principalTable: "rentable_tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rentable_id",
                        column: x => x.rentable_id,
                        principalTable: "rentable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rentable_tag_rentable_rentable_id",
                table: "rentable_tag_rentable",
                column: "rentable_id");

            migrationBuilder.CreateIndex(
                name: "IX_rentable_tag_rentable_rentable_tag_id",
                table: "rentable_tag_rentable",
                column: "rentable_tag_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rentable_tag_rentable");
        }
    }
}
