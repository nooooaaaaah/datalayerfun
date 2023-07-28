using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WNBOT.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "seller",
                columns: table => new
                {
                    sellerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    sellerRating = table.Column<float>(type: "REAL", nullable: false),
                    followerCount = table.Column<int>(type: "INTEGER", nullable: false),
                    bio = table.Column<string>(type: "TEXT", nullable: false),
                    soldCount = table.Column<int>(type: "INTEGER", nullable: false),
                    numOfReviews = table.Column<int>(type: "INTEGER", nullable: false),
                    numOfSavedStreams = table.Column<int>(type: "INTEGER", nullable: false),
                    avgTotalViewers = table.Column<int>(type: "INTEGER", nullable: false),
                    itemsSoldDuringSavedStreams = table.Column<int>(type: "INTEGER", nullable: false),
                    avgPriceOfItemsSoldDuringSavedStreams = table.Column<float>(type: "REAL", nullable: false),
                    dateOfOldestStream = table.Column<float>(type: "REAL", nullable: false),
                    numOfUniquePurchasers = table.Column<int>(type: "INTEGER", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seller", x => x.sellerId);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryName = table.Column<string>(type: "TEXT", nullable: false),
                    sellerId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "saved_streams",
                columns: table => new
                {
                    savedStreamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    streamKey = table.Column<string>(type: "TEXT", nullable: false),
                    startTime = table.Column<float>(type: "REAL", nullable: false),
                    viewers = table.Column<int>(type: "INTEGER", nullable: false),
                    sellerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saved_streams", x => x.savedStreamId);
                    table.ForeignKey(
                        name: "FK_saved_streams_seller_sellerId",
                        column: x => x.sellerId,
                        principalTable: "seller",
                        principalColumn: "sellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sold_item",
                columns: table => new
                {
                    soldItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    price = table.Column<float>(type: "REAL", nullable: false),
                    timeStamp = table.Column<float>(type: "REAL", nullable: false),
                    quantitySold = table.Column<int>(type: "INTEGER", nullable: false),
                    currency = table.Column<string>(type: "TEXT", nullable: false),
                    orderId = table.Column<int>(type: "INTEGER", nullable: false),
                    purchaserId = table.Column<string>(type: "TEXT", nullable: false),
                    transactionType = table.Column<string>(type: "TEXT", nullable: false),
                    productName = table.Column<string>(type: "TEXT", nullable: false),
                    savedStreamId = table.Column<int>(type: "INTEGER", nullable: false),
                    savedLiveStreamsavedStreamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sold_item", x => x.soldItemId);
                    table.ForeignKey(
                        name: "FK_sold_item_saved_streams_savedLiveStreamsavedStreamId",
                        column: x => x.savedLiveStreamsavedStreamId,
                        principalTable: "saved_streams",
                        principalColumn: "savedStreamId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_sellerId",
                table: "categories",
                column: "sellerId");

            migrationBuilder.CreateIndex(
                name: "IX_saved_streams_sellerId",
                table: "saved_streams",
                column: "sellerId");

            migrationBuilder.CreateIndex(
                name: "IX_sold_item_savedLiveStreamsavedStreamId",
                table: "sold_item",
                column: "savedLiveStreamsavedStreamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "sold_item");

            migrationBuilder.DropTable(
                name: "saved_streams");

            migrationBuilder.DropTable(
                name: "seller");
        }
    }
}
