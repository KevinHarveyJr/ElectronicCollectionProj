using Microsoft.EntityFrameworkCore.Migrations;

namespace Electronic_Collection.Data.Migrations
{
    public partial class AddedMoreDbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c20ae07b-0185-4094-ac72-8244f29db9a2");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Item",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Item",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreObjGenreId",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeObjTypeId",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "Collector",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Collector",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WishList",
                table: "Collector",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WishListId",
                table: "Collector",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ItemId");

            migrationBuilder.CreateTable(
                name: "CollectorCollection",
                columns: table => new
                {
                    CollectorId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectorCollection", x => new { x.CollectorId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CollectorCollection_Collector_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "Collector",
                        principalColumn: "CollectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectorCollection_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectorLikes",
                columns: table => new
                {
                    CollectorId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    IsDislike = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectorLikes", x => new { x.CollectorId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CollectorLikes_Collector_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "Collector",
                        principalColumn: "CollectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectorLikes_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectorWishlist",
                columns: table => new
                {
                    CollectorId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    WishListId = table.Column<int>(nullable: false),
                    WishList = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectorWishlist", x => new { x.CollectorId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_CollectorWishlist_Collector_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "Collector",
                        principalColumn: "CollectorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectorWishlist_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b43d082-9b15-4791-92ff-f9183ecb19ec", "9ae08438-7ccb-40ae-b02e-93ba9d450ba5", "Collector", "COLLECTOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_GenreObjGenreId",
                table: "Item",
                column: "GenreObjGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_TypeObjTypeId",
                table: "Item",
                column: "TypeObjTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Collector_ItemId",
                table: "Collector",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectorCollection_CollectorId",
                table: "CollectorCollection",
                column: "CollectorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollectorCollection_ItemId",
                table: "CollectorCollection",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectorLikes_ItemId",
                table: "CollectorLikes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectorWishlist_ItemId",
                table: "CollectorWishlist",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collector_Item_ItemId",
                table: "Collector",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Genre_GenreObjGenreId",
                table: "Item",
                column: "GenreObjGenreId",
                principalTable: "Genre",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Type_TypeObjTypeId",
                table: "Item",
                column: "TypeObjTypeId",
                principalTable: "Type",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collector_Item_ItemId",
                table: "Collector");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Genre_GenreObjGenreId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Type_TypeObjTypeId",
                table: "Item");

            migrationBuilder.DropTable(
                name: "CollectorCollection");

            migrationBuilder.DropTable(
                name: "CollectorLikes");

            migrationBuilder.DropTable(
                name: "CollectorWishlist");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_GenreObjGenreId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_TypeObjTypeId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Collector_ItemId",
                table: "Collector");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b43d082-9b15-4791-92ff-f9183ecb19ec");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "GenreObjGenreId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "TypeObjTypeId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Collector");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Collector");

            migrationBuilder.DropColumn(
                name: "WishList",
                table: "Collector");

            migrationBuilder.DropColumn(
                name: "WishListId",
                table: "Collector");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Item",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c20ae07b-0185-4094-ac72-8244f29db9a2", "8e28f989-ba3f-4a0f-8d4a-c077a7db3f13", "Collector", "COLLECTOR" });
        }
    }
}
