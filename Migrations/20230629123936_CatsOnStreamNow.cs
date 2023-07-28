using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBOT.Migrations
{
    /// <inheritdoc />
    public partial class CatsOnStreamNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "saved_streams",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "saved_streams");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sellerId = table.Column<int>(type: "INTEGER", nullable: false),
                    categoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryId);
                    table.ForeignKey(
                        name: "FK_categories_seller_sellerId",
                        column: x => x.sellerId,
                        principalTable: "seller",
                        principalColumn: "sellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_sellerId",
                table: "categories",
                column: "sellerId");
        }
    }
}
