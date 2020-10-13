using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronic_Collection.Data.Migrations
{
    public partial class ChangedIdentityRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "baf37a16-8b97-4849-b4f6-9daec4ac553d");

            migrationBuilder.CreateTable(
                name: "Collector",
                columns: table => new
                {
                    CollectorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Console = table.Column<string>(nullable: true),
                    Game = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    GamingMoment = table.Column<string>(nullable: true),
                    PicturePath = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collector", x => x.CollectorId);
                    table.ForeignKey(
                        name: "FK_Collector_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c20ae07b-0185-4094-ac72-8244f29db9a2", "8e28f989-ba3f-4a0f-8d4a-c077a7db3f13", "Collector", "COLLECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Collector_IdentityUserId",
                table: "Collector",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collector");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c20ae07b-0185-4094-ac72-8244f29db9a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "baf37a16-8b97-4849-b4f6-9daec4ac553d", "3974815c-224b-4b1e-bc8a-3f2f3949b79d", "customer", "CUSTOMER" });
        }
    }
}
