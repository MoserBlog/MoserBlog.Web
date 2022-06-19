using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoserBlog.Persistence.Migrations
{
    public partial class UpdateReferenceForBlogEntriesAndCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BlogEntries_BlogEntryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BlogEntryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BlogEntryId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "BlogEntryCategory",
                columns: table => new
                {
                    BlogEntriesId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogEntryCategory", x => new { x.BlogEntriesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BlogEntryCategory_BlogEntries_BlogEntriesId",
                        column: x => x.BlogEntriesId,
                        principalTable: "BlogEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogEntryCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogEntryCategory_CategoriesId",
                table: "BlogEntryCategory",
                column: "CategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogEntryCategory");

            migrationBuilder.AddColumn<int>(
                name: "BlogEntryId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BlogEntryId",
                table: "Categories",
                column: "BlogEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BlogEntries_BlogEntryId",
                table: "Categories",
                column: "BlogEntryId",
                principalTable: "BlogEntries",
                principalColumn: "Id");
        }
    }
}
