using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brava.Migrations
{
    /// <inheritdoc />
    public partial class faqMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FAQCategories",
                columns: table => new
                {
                    FAQCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQCategories", x => x.FAQCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FAQItems",
                columns: table => new
                {
                    FAQItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAQCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQItems", x => x.FAQItemId);
                    table.ForeignKey(
                        name: "FK_FAQItems_FAQCategories_FAQCategoryId",
                        column: x => x.FAQCategoryId,
                        principalTable: "FAQCategories",
                        principalColumn: "FAQCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FAQItems_FAQCategoryId",
                table: "FAQItems",
                column: "FAQCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FAQItems");

            migrationBuilder.DropTable(
                name: "FAQCategories");
        }
    }
}
