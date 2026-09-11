using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIncomeSources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Income",
                table: "MonthlyPlans");

            migrationBuilder.CreateTable(
                name: "IncomeSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeSources_MonthlyPlans_MonthlyPlanId",
                        column: x => x.MonthlyPlanId,
                        principalTable: "MonthlyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeSources_MonthlyPlanId",
                table: "IncomeSources",
                column: "MonthlyPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeSources");

            migrationBuilder.AddColumn<decimal>(
                name: "Income",
                table: "MonthlyPlans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
