using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronic_Collection.Migrations
{
    public partial class AddedWishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c79dae2c-7652-4561-a8e4-407c9d218690");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f612451-e580-4c01-a9de-834217e5a8e4", "d802e7f2-3b2d-442f-978a-2eb3369a28a8", "Collector", "COLLECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_Id",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Store_Id",
                table: "Item",
                column: "Id",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Store_Id",
                table: "Item");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Item_Id",
                table: "Item");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f612451-e580-4c01-a9de-834217e5a8e4");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Item");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c79dae2c-7652-4561-a8e4-407c9d218690", "be8bf309-3e01-427f-8671-220aee7351bb", "Collector", "COLLECTOR" });
        }
    }
}
