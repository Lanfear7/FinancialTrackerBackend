using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialTracker.Migrations
{
    /// <inheritdoc />
    public partial class trackerIdOnTransactionsNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Trackers_TrackerId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "TrackerId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Trackers_TrackerId",
                table: "Transactions",
                column: "TrackerId",
                principalTable: "Trackers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Trackers_TrackerId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "TrackerId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Trackers_TrackerId",
                table: "Transactions",
                column: "TrackerId",
                principalTable: "Trackers",
                principalColumn: "Id");
        }
    }
}
