using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoptionMVC.Migrations
{
    /// <inheritdoc />
    public partial class PaymentRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Expiration",
                table: "Payments",
                newName: "ReceiptNumber");

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Payments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FailureReason",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentToken",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RefundedAmount",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailureReason",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentToken",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RefundedAmount",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "ReceiptNumber",
                table: "Payments",
                newName: "Expiration");

            migrationBuilder.AlterColumn<string>(
                name: "BankName",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
