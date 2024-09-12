using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace marquee_backend.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    note = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rentable_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentable_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rentable_tag",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentable_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rentable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    note = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    type = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentable", x => x.id);
                    table.ForeignKey(
                        name: "fk_rentable_category_id",
                        column: x => x.type,
                        principalTable: "rentable_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_role_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "part",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    note = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    rentable_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_part", x => x.id);
                    table.ForeignKey(
                        name: "fk_part_rentable_id",
                        column: x => x.rentable_id,
                        principalTable: "rentable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rentable_tag_rentable",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    rentable_tag_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rentable_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentable_tag_rentable", x => x.id);
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
                name: "unique_name1",
                table: "item",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_part_rentable_id",
                table: "part",
                column: "rentable_id");

            migrationBuilder.CreateIndex(
                name: "unique_name2",
                table: "part",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rentable_type",
                table: "rentable",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "unique_name3",
                table: "rentable",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_name4",
                table: "rentable_category",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_name5",
                table: "rentable_tag",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rentable_tag_rentable_rentable_id",
                table: "rentable_tag_rentable",
                column: "rentable_id");

            migrationBuilder.CreateIndex(
                name: "IX_rentable_tag_rentable_unique",
                table: "rentable_tag_rentable",
                columns: new[] { "rentable_tag_id", "rentable_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_name",
                table: "role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_username",
                table: "user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_role_role_id",
                table: "user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_user_id",
                table: "user_role",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "part");

            migrationBuilder.DropTable(
                name: "rentable_tag_rentable");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "rentable_tag");

            migrationBuilder.DropTable(
                name: "rentable");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "rentable_category");
        }
    }
}
